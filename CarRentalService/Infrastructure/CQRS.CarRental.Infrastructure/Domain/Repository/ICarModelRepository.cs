
using CQRS.CarRental.Repository.Foundation.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
   public  interface  ICarModelRepository : IRepository<CQRS.CarRental.Repository.Foundation.Models.CarModel>
    {
       
    }
}
