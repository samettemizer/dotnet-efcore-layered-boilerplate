using System;

namespace TaTava.EntityFrameworkCore.Events
{
    [Serializable]
    public class DomainEventEntry
    {
        public object SourceEntity { get; }

        public DomainEventEntry(object sourceEntity)
        {
            SourceEntity = sourceEntity;
        }
    }
}