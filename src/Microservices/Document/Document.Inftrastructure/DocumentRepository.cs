using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Infrastructure;
using Document.Domain;
using Microsoft.EntityFrameworkCore;

namespace Document.Inftrastructure
{
    public class BaseRepository<TContext, T> : IRepository<T>
        where TContext: DbContext, IUnitOfWork
        where T : BaseEntity
    {
        TContext context;

        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public void Add(T entity) => context.Set<T>().Add(entity);

        public IQueryable<T> All<T>() where T : BaseEntity
        {
            return context.Set<T>().AsQueryable();
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return context.Set<T>().Any(predicate);
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
             return context.Set<T>().FirstOrDefault<T>(predicate);
        }

        public Task<T> GetAsync(int id) => context.Set<T>().FindAsync(id);

        private T Get(int id) => context.Set<T>().Find(id);

        public void Remove(int id) => context.Set<T>().Remove(Get(id));

        public void Update(T entity) => context.Set<T>().Update(entity);

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    context.Dispose();
            }
            disposed=true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class DocumentRepository : BaseRepository<DocumentDbContext, CustomerDocument>, ICustomerDocumentRepository
    {
        public DocumentRepository(DocumentDbContext context) : base(context)
        {
        }
    }

    // public class DocumentRepository : ICustomerDocumentRepository
    // {
    //     DocumentDbContext context;

    //     public DocumentRepository(DocumentDbContext context)
    //     {
    //         this.context = context;
    //     }

    //     public IUnitOfWork UnitOfWork => context;

    //     public void Add(CustomerDocument entity)
    //     {
    //         context.Add(entity);
    //     }

    //     public IQueryable<T> All<T>() where T : BaseEntity
    //     {
    //         return context.Set<T>().AsQueryable();
    //     }

    //     public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
    //     {         
    //         return context.Set<T>().Any(predicate);
    //     }

    //     public T Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
    //     {
    //         return context.Set<T>().FirstOrDefault<T>(predicate);
    //     }

    //     public Task<CustomerDocument> GetAsync(int id)
    //     {
    //         return context.CustomerDocuments.FindAsync(id);
    //     }

    //     public CustomerDocument Get(int id) => context.CustomerDocuments.Find(id);

    //     public void Remove(int id) => context.CustomerDocuments.Remove(Get(id));

    //     public void Update(CustomerDocument entity)
    //     {
    //         context.Update(entity);
    //     }
    // }
}