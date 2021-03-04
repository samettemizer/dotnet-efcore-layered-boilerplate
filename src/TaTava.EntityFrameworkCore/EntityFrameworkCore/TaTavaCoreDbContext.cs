using Microsoft.EntityFrameworkCore;
using TaTava.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaTava.EntityFrameworkCore.Events;
using TaTava.Entities.Audited;
using System;
using System.Collections.Generic;
using TaTava.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using TaTava.EntityFrameworkCore.EntityFrameworkCore.Extensions;
using TaTava.EntityFrameworkCore.Helpers;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Extensions;
using Microsoft.AspNetCore.Http;

namespace TaTava.EntityFrameworkCore
{
    public class TaTavaCoreDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected TaTavaCoreDbContext(DbContextOptions<TaTavaDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            var changeReport = ApplyConcepts();

            return base.SaveChanges();
        }

        protected virtual EntityChangeReport ApplyConcepts()
        {
            var changeReport = new EntityChangeReport();

            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "Id");

            var userId = userIdClaim is null ? new Guid() : new Guid(userIdClaim.Value);

            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                if (entry.State != EntityState.Modified && entry.CheckOwnedEntityChange())
                {
                    Entry(entry.Entity).State = EntityState.Modified;
                }

                ApplyConcepts(entry, userId, changeReport);
            }

            return changeReport;
        }

        protected virtual void ApplyConcepts(EntityEntry entry, Guid? userId, EntityChangeReport changeReport)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    ApplyConceptsForAddedEntity(entry, userId, changeReport);
                    break;
                case EntityState.Modified:
                    ApplyConceptsForModifiedEntity(entry, userId, changeReport);
                    break;
                case EntityState.Deleted:
                    ApplyConceptsForDeletedEntity(entry, userId, changeReport);
                    break;
            }

            AddDomainEvents(changeReport.DomainEvents, entry.Entity);
        }

        protected virtual void ApplyConceptsForAddedEntity(EntityEntry entry, Guid? userId, EntityChangeReport changeReport)
        {
            CheckAndSetId(entry);
            SetCreationAuditProperties(entry.Entity, userId);
            changeReport.ChangedEntities.Add(new EntityChangeEntry(entry.Entity, EntityChangeType.Created));
        }

        protected virtual void ApplyConceptsForModifiedEntity(EntityEntry entry, Guid? userId, EntityChangeReport changeReport)
        {
            SetModificationAuditProperties(entry.Entity, userId);
            if (entry.Entity is ISoftDelete && entry.Entity.As<ISoftDelete>().IsDeleted)
            {
                SetDeletionAuditProperties(entry.Entity, userId);
                changeReport.ChangedEntities.Add(new EntityChangeEntry(entry.Entity, EntityChangeType.Deleted));
            }
            else
            {
                changeReport.ChangedEntities.Add(new EntityChangeEntry(entry.Entity, EntityChangeType.Updated));
            }
        }

        protected virtual void ApplyConceptsForDeletedEntity(EntityEntry entry, Guid? userId, EntityChangeReport changeReport)
        {
            if (IsHardDeleteEntity(entry))
            {
                changeReport.ChangedEntities.Add(new EntityChangeEntry(entry.Entity, EntityChangeType.Deleted));
                return;
            }

            CancelDeletionForSoftDelete(entry);
            SetDeletionAuditProperties(entry.Entity, userId);
            changeReport.ChangedEntities.Add(new EntityChangeEntry(entry.Entity, EntityChangeType.Deleted));
        }

        protected virtual bool IsHardDeleteEntity(EntityEntry entry)
        {
            if (entry.Entity is ISoftDelete)
                return false;
            else
                return true;

            //TODO: Bu alana gozden gecirilecek.
            // if (CurrentUnitOfWorkProvider?.Current?.Items == null)
            // {
            //     return false;
            // }

            // if (!CurrentUnitOfWorkProvider.Current.Items.ContainsKey(UnitOfWorkExtensionDataTypes.HardDelete))
            // {
            //     return false;
            // }

            // var hardDeleteItems = CurrentUnitOfWorkProvider.Current.Items[UnitOfWorkExtensionDataTypes.HardDelete];
            // if (!(hardDeleteItems is HashSet<string> objects))
            // {
            //     return false;
            // }

            // var hardDeleteKey = EntityHelper.GetHardDeleteKey(entry.Entity);
            // return objects.Contains(hardDeleteKey);
        }

        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (!(entry.Entity is ISoftDelete))
            {
                return;
            }

            entry.Reload();
            entry.State = EntityState.Modified;
            entry.Entity.As<ISoftDelete>().IsDeleted = true;
        }

        protected void SetDeletionAuditProperties(object entityAsObj, Guid? userId)
        {
            if (entityAsObj is IHasDeletionTime)
            {
                var entity = entityAsObj.As<IHasDeletionTime>();

                if (entity.DeletionTime == null)
                {
                    entity.DeletionTime = DateTime.Now;
                }
            }

            if (entityAsObj is IDeletionAudited)
            {
                var entity = entityAsObj.As<IDeletionAudited>();

                if (!entity.DeleterUserId.Equals(new Guid()))
                {
                    return;
                }

                if (userId == null)
                {
                    entity.DeleterUserId = null;
                    return;
                }


                entity.DeleterUserId = userId;
            }
        }

        protected void CheckAndSetId(EntityEntry entry)
        {
            //Set GUID Ids
            var entity = entry.Entity as IEntity<Guid>;
            if (entity != null && entity.Id == Guid.Empty)
            {
                var idPropertyEntry = entry.Property("Id");

                if (idPropertyEntry != null && idPropertyEntry.Metadata.ValueGenerated == ValueGenerated.Never)
                {
                    entity.Id = new Guid();
                }
            }
        }

        protected virtual void SetCreationAuditProperties(object entityAsObj, Guid? userId)
        {
            EntityAuditingHelper.SetCreationAuditProperties(entityAsObj, userId);
        }

        protected virtual void SetModificationAuditProperties(object entityAsObj, Guid? userId)
        {
            EntityAuditingHelper.SetModificationAuditProperties(entityAsObj, userId);
        }


        protected virtual void AddDomainEvents(List<DomainEventEntry> domainEvents, object entityAsObj)
        {
            var generatesDomainEventsEntity = entityAsObj as IGeneratesDomainEvents;
            if (generatesDomainEventsEntity == null)
            {
                return;
            }

            if (generatesDomainEventsEntity.DomainEvents is null)
            {
                return;
            }

            domainEvents.AddRange(generatesDomainEventsEntity.DomainEvents.Select(eventData => new DomainEventEntry(entityAsObj)));
            generatesDomainEventsEntity.DomainEvents.Clear();
        }

    }
}