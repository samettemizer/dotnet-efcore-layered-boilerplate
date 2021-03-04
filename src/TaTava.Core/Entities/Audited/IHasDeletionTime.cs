using System;

namespace TaTava.Entities.Audited
{
    public interface IHasDeletionTime : ISoftDelete
    {
         DateTime? DeletionTime { get; set; }
    }
}