using CQRS.CarRental.Infrastructure;
using CQRS.CarRental.Repository.Foundation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Repository
{
    public class CarModelRepository : Repository<CQRS.CarRental.Repository.Foundation.Models.CarModel>, ICarModelRepository
    {

        public CarModelRepository()
            : base(new CQRS.CarRental.Repository.Foundation.Models.CarRentalDatabaseContext())
        {


        }


    }
}
