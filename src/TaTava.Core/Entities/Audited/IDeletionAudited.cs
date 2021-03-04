using System;

namespace TaTava.Entities.Audited
{
    public interface IDeletionAudited : IHasDeletionTime, ISoftDelete
    {
         Guid? DeleterUserId { get; set; }
    }
}