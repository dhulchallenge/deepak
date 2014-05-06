using CQRS.CarRental.Events.Repository.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Events.Repository
{
   public class CarRentalHistoryRepository: Repository<CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory>, CQRS.CarRental.Infrastructure.ICarRentalHistoryRepository
    {




       public CarRentalHistoryRepository()
            : base(new CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalHistoryDatabaseContext())     
     
        {          
           

        }      



    }
}
