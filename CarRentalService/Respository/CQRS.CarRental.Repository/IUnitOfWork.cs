using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
