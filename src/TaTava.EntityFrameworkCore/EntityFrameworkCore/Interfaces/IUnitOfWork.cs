using TaTava.Entities;
using TaTava.EntityFrameworkCore.UnitOfWork;

namespace TaTava.EntityFrameworkCore.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity, TPrimaryKey> Repository<TEntity, TPrimaryKey>() where TEntity : class,IEntity<TPrimaryKey>;
        UowTransaction BeginTransaction();
        int SaveChanges();
    }
}