using CQRS.CarRental.Infrastructure;
using CQRS.CarRental.Repository.Foundation;
using CQRS.CarRental.Repository.Foundation.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Repository
{
    public class CarRentalRepository : Repository<CQRS.CarRental.Repository.Foundation.Models.CarRentalDetail>, ICarRentalRepository
    {
     
        public CarRentalRepository()
            : base(new CQRS.CarRental.Repository.Foundation.Models.CarRentalDatabaseContext())     
     
        {          
           

        }





     
    }
}
