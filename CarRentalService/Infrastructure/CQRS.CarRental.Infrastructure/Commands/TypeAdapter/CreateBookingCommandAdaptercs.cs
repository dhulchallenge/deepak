using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Commands
{
     public static class CreateBookingCommandAdapter
    {

         public static CQRS.CarRental.Repository.Foundation.Models.CarRentalDetail changeType(CarRentalDetail source)
        {

            CQRS.CarRental.Repository.Foundation.Models.CarRentalDetail modelCarRentalDetail = new Repository.Foundation.Models.CarRentalDetail();

            modelCarRentalDetail.Address = source.Address;
            modelCarRentalDetail.RentalId = Guid.NewGuid();
            modelCarRentalDetail.CarModelId = source.CarModelId;
            modelCarRentalDetail.CarRentalStartDate = source.CarRentalStartDate;
            modelCarRentalDetail.CarRentalEndDate = source.CarRentalEndDate;
            modelCarRentalDetail.LocationId = source.LocationId;
            modelCarRentalDetail.TotalCost = source.TotalCost;
            modelCarRentalDetail.DriverName = source.DriverName;
            modelCarRentalDetail.LicenseneNumber = source.LicenseneNumber;
            modelCarRentalDetail.ContactNumber = source.ContactNumber;
            modelCarRentalDetail.EmailId = source.EmailId;
            modelCarRentalDetail.Status = source.Status ;


            return modelCarRentalDetail;
        }


         //public static CQRS.CarRental.Repository.Foundation.Models.CarRentalDetail changeType(CarRentalDetail source)
         //{

         //    CQRS.CarRental.Repository.Foundation.Models.CarRentalDetail modelCarRentalDetail = new Repository.Foundation.Models.CarRentalDetail();

         //    modelCarRentalDetail.Address = source.Address;
         //    modelCarRentalDetail.RentalId = Guid.NewGuid();
         //    modelCarRentalDetail.CarModelId = source.CarModelId;
         //    modelCarRentalDetail.CarRentalStartDate = source.CarRentalStartDate;
         //    modelCarRentalDetail.CarRentalEndDate = source.CarRentalEndDate;
         //    modelCarRentalDetail.LocationId = source.LocationId;
         //    modelCarRentalDetail.TotalCost = source.TotalCost;
         //    modelCarRentalDetail.DriverName = source.DriverName;
         //    modelCarRentalDetail.LicenseneNumber = source.LicenseneNumber;
         //    modelCarRentalDetail.ContactNumber = source.ContactNumber;
         //    modelCarRentalDetail.EmailId = source.EmailId;
         //    modelCarRentalDetail.Status = "Active";


         //    return modelCarRentalDetail;
         //}



    }
}
