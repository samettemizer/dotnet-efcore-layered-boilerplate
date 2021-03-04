using Microsoft.EntityFrameworkCore.Infrastructure;
using TaTava.EntityFrameworkCore.UnitOfWork;

namespace TaTava.EntityFrameworkCore.Extensions
{
    public static class EfCoreExtensions
    {
        public static bool HasActiveTransaction(this DatabaseFacade databaseFacade)
        {
            return databaseFacade.CurrentTransaction != null;
        }

        public static UowTransaction CreateOrGetCurrentTransaction(this DatabaseFacade databaseFacade)
        {
            return !databaseFacade.HasActiveTransaction()
                ? new UowTransaction(databaseFacade.BeginTransaction(), true)
                : new UowTransaction(databaseFacade.CurrentTransaction, false);
        }
    }
}