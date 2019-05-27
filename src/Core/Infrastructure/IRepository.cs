using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
        IQueryable<T> All<T>() where T : BaseEntity;

        T Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        bool Contains<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        void Add(T entity);
        void Update(T entity);
        Task<T> GetAsync(int id);
        void Remove(int id);
        


    }

}