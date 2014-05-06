using CQRS.CarRental.Repository.Foundation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Repository.Foundation.Foundation
{
    public interface IRepository<T> : IDisposable where T : class
    {
        
        IQueryable<T> GetQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, Boolean>> where);
        T Single(Expression<Func<T, Boolean>> where);
        T First(Expression<Func<T, Boolean>> where);
        void Delete(T entity);
        void Add(T entity);
        void Attach(T entity);
        void Attach(T entity, EntityStatus status);
        IUnitOfWork UnitOfWork { get; }
    }
}
