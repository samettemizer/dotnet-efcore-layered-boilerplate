using System;

namespace TaTava.Entities.Audited
{
    public interface IModificationAudited : IHasModificationTime
    {
         Guid? LastModifierUserId { get; set; }
    }
}