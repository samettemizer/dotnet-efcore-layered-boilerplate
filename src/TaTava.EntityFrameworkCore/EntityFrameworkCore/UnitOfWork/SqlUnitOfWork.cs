using System.Collections.Generic;
using TaTava.Entities;
using TaTava.EntityFrameworkCore.Extensions;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.EntityFrameworkCore.Repositories;

namespace TaTava.EntityFrameworkCore.UnitOfWork
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly TaTavaDbContext _context;

        private readonly Dictionary<string, dynamic> _repositoryDictionary;

        public SqlUnitOfWork(TaTavaDbContext context)
        {
            _context = context;
            _repositoryDictionary = new Dictionary<string, dynamic>();
        }
        public IRepository<TEntity, TPrimaryKey> Repository<TEntity, TPrimaryKey>() where TEntity : class ,IEntity<TPrimaryKey>
        {
            var entityName = typeof(TEntity).Name;

            var repositoryCreated = _repositoryDictionary.ContainsKey(entityName);

            if (!repositoryCreated)
            {
                var newRepository = new SqlRepository<TEntity, TPrimaryKey>(_context);
                _repositoryDictionary.Add(entityName, newRepository);
            }

            return _repositoryDictionary[entityName];
        }
        public UowTransaction BeginTransaction()
        {
            return _context.Database.CreateOrGetCurrentTransaction();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}