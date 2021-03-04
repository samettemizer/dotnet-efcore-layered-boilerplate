using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace TaTava.EntityFrameworkCore.UnitOfWork
{
   public class UowTransaction : IDisposable
    {
        private readonly IDbContextTransaction _transaction;
        private readonly bool _isNew;

        public UowTransaction(IDbContextTransaction transaction, bool isNew)
        {
            _transaction = transaction;
            _isNew = isNew;
        }

        public void Commit(bool force = false)
        {
            if (_isNew || force)
            {
                _transaction.Commit();
            }
        }

        public void Rollback(bool force = true)
        {
            if (_isNew || force)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose(bool force)
        {
            if (_isNew || force)
            {
                _transaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(false);
        }
    }
}