using System.Collections.Generic;

namespace TaTava.EntityFrameworkCore.Interfaces
{
    public interface IGeneratesDomainEvents
    {
        ICollection<IEventData> DomainEvents { get; }
    }
}