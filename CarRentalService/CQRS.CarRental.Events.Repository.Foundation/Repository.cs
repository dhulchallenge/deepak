using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Events.Repository.Foundation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public static IObjectContextAdapter _ObjectContextAdapter;
        IObjectSet<T> _ObjectSet;
        private IUnitOfWork unitofWork;

        public Repository(IObjectContextAdapter objectContextAdapter)
        {

            _ObjectContextAdapter = objectContextAdapter;
            _ObjectSet = objectContextAdapter.ObjectContext.CreateObjectSet<T>();
            UnitOfWork objwork = new Foundation.UnitOfWork();
                //= new CarRental.Repository.Foundation.UnitOfWork();
            objwork._ObjectContextAdapter = _ObjectContextAdapter;
            unitofWork = objwork;
        }


        public IQueryable<T> GetQueryable()
        {
            return _ObjectSet;
        }

        public IEnumerable<T> GetAll()
        {
            return _ObjectSet.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, Boolean>> where)
        {
            return _ObjectSet.Where(where);
        }

        public T Single(Expression<Func<T, Boolean>> where)
        {
            return _ObjectSet.Single(where);
        }

        public T First(Expression<Func<T, Boolean>> where)
        {
            return _ObjectSet.First(where);
        }

        public void Delete(T entity)
        {
            _ObjectSet.DeleteObject(entity);
        }

        public void Add(T entity)
        {
            _ObjectSet.AddObject(entity);
        }

        public void Attach(T entity)
        {
            Attach(entity, EntityStatus.Unchanged);
        }

        public void Attach(T entity, EntityStatus status)
        {
            _ObjectSet.Attach(entity);
            _ObjectContextAdapter.ObjectContext.ObjectStateManager.ChangeObjectState(entity, GetEntityState(status));
        }

        public void Dispose()
        {
            if (_ObjectContextAdapter != null)
                _ObjectContextAdapter.ObjectContext.Dispose();

            GC.SuppressFinalize(this);
        }

        private EntityState GetEntityState(EntityStatus status)
        {
            switch (status)
            {
                case EntityStatus.Added:
                    return EntityState.Added;
                case EntityStatus.Deleted:
                    return EntityState.Deleted;
                case EntityStatus.Detached:
                    return EntityState.Detached;
                case EntityStatus.Modified:
                    return EntityState.Modified;
                default:
                    return EntityState.Unchanged;
            }
        }


        public IUnitOfWork UnitOfWork
        {
            get { return this.unitofWork; }
        }
    }
    public enum EntityStatus : int
    {
        Added,
        Deleted,
        Detached,
        Modified,
        Unchanged
    }
}
