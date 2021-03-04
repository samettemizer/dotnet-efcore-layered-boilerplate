using System;

namespace TaTava.Entities.Audited
{
    public class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAudited, ICreationAudited, IHasCreationTime, IModificationAudited, IHasModificationTime
    {
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual Guid? LastModifierUserId { get; set; }
    }
}