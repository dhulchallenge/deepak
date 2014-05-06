
using CQRS.CarRental.Repository;
using CQRS.CarRental.Repository.Foundation.Foundation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public interface ICarRentalRepository : IRepository<CQRS.CarRental.Repository.Foundation.Models.CarRentalDetail>
    {

         //IEnumerable<@Type>  GetCarDetials(string queryMode);
    }
}
