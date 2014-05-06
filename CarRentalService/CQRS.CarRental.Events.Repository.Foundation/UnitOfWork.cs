using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Events.Repository.Foundation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IObjectContextAdapter _ObjectContextAdapter { get; set; }


        public void SaveChanges()
        {
            try
            {
                int affectedRecord = _ObjectContextAdapter.ObjectContext.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                throw;
            }
            catch (DataException)
            {
                throw;
            }
        }

        public void Dispose()
        {
            if (_ObjectContextAdapter != null)
                _ObjectContextAdapter.ObjectContext.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
