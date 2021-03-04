using System;

namespace TaTava.Entities.Audited
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}