using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaTava.Core.Security;
using TaTava.Entities;
using TaTava.Entities.Audited;
using TaTava.EntityFrameworkCore.Interfaces;

namespace TaTava.EntityFrameworkCore.Repositories
{
    public class SqlRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {

        //TODO: Bir class'ın bir interface'den inherite olduğunu öğrenmek için kullanılıyor.
        // if(typeof(TEntity).IsAssignableFrom(typeof(IFullAudited)))

        private readonly DbSet<TEntity> _dbSet;
        private readonly TaTavaDbContext _context;
        private readonly IEncryption _encryption;
        private TaTavaDbContext context;

        public SqlRepository(TaTavaDbContext context, IEncryption encryption)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _encryption = encryption;
        }

        public SqlRepository(TaTavaDbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            EntityNullCheck(entity);

            EncryptFlagedProperties(entity);

            var entityResult = await _dbSet.AddAsync(entity);

            return entityResult.Entity;
        }

        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            EntityNullCheck(entity);

            EncryptFlagedProperties(entity);

            var entityResult = await _dbSet.AddAsync(entity);

            return entityResult.Entity.Id;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            EntityNullCheck(entity);

            var updatedEntity = _dbSet.Update(entity);

            return updatedEntity.Entity;
        }

        public async Task Delete(TEntity entity)
        {
            EntityNullCheck(entity);

            _dbSet.Remove(entity);
        }

        public async Task Delete(Expression<Func<TEntity, bool>> query)
        {
            var entities = await GetQueryable()
                .Where(query)
                .ToListAsync();

            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            var newquery = _dbSet.Where(query);

            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));

            var result = newquery.FirstOrDefaultAsync(query);

            return await result;
        }

        public async Task<IQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>> query = null, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            var newquery = !(query is null) ? _dbSet.Where(query) : _dbSet.AsQueryable();

            if (includeExpressions.Any())
                newquery = includeExpressions.Aggregate(newquery, (current, includeExpression) => current.Include(includeExpression));

            return newquery;
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> query = null)
        {
            return query is null ? _dbSet.Any() : _dbSet.Any(query);
        }


        public async Task<int> Count(Expression<Func<TEntity, bool>> query = null)
        {
            return query is null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(query);
        }

        public async Task InsertRangeAsync(IQueryable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        private object EntityNullCheck(TEntity entity) => entity is null ? throw new ArgumentNullException($"Entity boş olamaz. Tip: {nameof(TEntity)}") : new object();

        protected IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        protected void EncryptFlagedProperties(TEntity entity)
        {
            System.ComponentModel.DataAnnotations.MetadataTypeAttribute[] metadataTypes = entity.GetType().GetCustomAttributes(true).OfType<System.ComponentModel.DataAnnotations.MetadataTypeAttribute>().ToArray();
            foreach (System.ComponentModel.DataAnnotations.MetadataTypeAttribute metadata in metadataTypes)
            {
                System.Reflection.PropertyInfo[] properties = metadata.MetadataClassType.GetProperties();
                //Metadata atanmış entity'nin tüm propertyleri tek tek alınır.
                foreach (System.Reflection.PropertyInfo pi in properties)
                {
                    //Eğer ilgili property ait CryptoData flag'i var ise ilgili deger encrypt edilir. 
                    if (Attribute.IsDefined(pi, typeof(Core.Entities.CryptoData)))
                    {
                        _context.Entry(entity).Property(pi.Name).CurrentValue = _encryption.EncryptText(_context.Entry(entity).Property(pi.Name).CurrentValue.ToString());
                    }
                }
            }
        }
    }

    public class SqlRepository<TEntity> : SqlRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
        public SqlRepository(TaTavaDbContext context, IEncryption encryption) : base(context, encryption)
        {
        }

        //Yukaridaki interface'den miras alındığı için buraya herhangi bir ekleme yapılmamalıdır.
    }


}