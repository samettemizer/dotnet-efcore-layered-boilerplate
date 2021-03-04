using System;
using TaTava.Entities.Audited;

namespace TaTava.Entities.Audited
{
    public interface ICreationAudited : IHasCreationTime
    {
        Guid? CreatorUserId { get; set; }
    }
}