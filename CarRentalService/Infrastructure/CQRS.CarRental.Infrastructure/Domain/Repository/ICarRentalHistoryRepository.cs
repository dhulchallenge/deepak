using CQRS.CarRental.Events.Repository.Foundation;
using CQRS.CarRental.Events.Repository.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public interface ICarRentalHistoryRepository : IRepository<CarRentalDetailsHistory>
    {
    }
}
