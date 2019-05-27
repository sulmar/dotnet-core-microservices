using System;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        Task<bool> SaveChangesAsync();
    }

}