using System;

namespace TaTava.Entities.Audited
{
    public interface IHasModificationTime
    {
         DateTime? LastModificationTime { get; set; }
    }
}