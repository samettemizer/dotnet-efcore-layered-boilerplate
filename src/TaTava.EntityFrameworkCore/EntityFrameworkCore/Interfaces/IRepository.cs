using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaTava.Entities;

namespace TaTava.EntityFrameworkCore.Interfaces
{
    //
    // Summary:
    //     This interface is implemented by all repositories to ensure implementation of
    //     fixed methods.
    //
    // Type parameters:
    //   TEntity:
    //     Main Entity type this repository works on
    //
    //   TPrimaryKey:
    //     Primary key type of the entity
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        Task InsertRangeAsync(IQueryable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(Expression<Func<TEntity, bool>> query);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] includeExpressions);
        Task<IQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>> query = null, params Expression<Func<TEntity, object>>[] includeExpressions);

        Task<bool> Any(Expression<Func<TEntity, bool>> query = null);
        Task<int> Count(Expression<Func<TEntity, bool>> query = null);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : IEntity<int>
    {

    }
}