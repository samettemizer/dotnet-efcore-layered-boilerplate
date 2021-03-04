using System;

namespace TaTava.Entities.Audited
{
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited, IHasCreationTime
    {
        public virtual DateTime CreationTime { get; set; }

        public virtual Guid? CreatorUserId { get; set; }
    }
}