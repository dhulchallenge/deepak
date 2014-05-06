using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Events.TypeAdapter
{
       public static   class CreateBookingEventAdapter
    {



        public static CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory changeType(BookingCreatedEvent source)
        {

          CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory modelCarRentalDetail = new  CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory();

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
            modelCarRentalDetail.Status = source.Status;
            modelCarRentalDetail.CreatedDate=DateTime.Now ;
            modelCarRentalDetail.Status=typeof(BookingCreatedEvent).Name ;

            return modelCarRentalDetail;
        }

        public static CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory FromDateChange(BookingFromDateChangedEvent source)
        {
            CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory modelCarRentalDetail = new CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory();

          
            modelCarRentalDetail.RentalId = source.RentalId;
            modelCarRentalDetail.CarRentalStartDate = source.CarRentalStartDate;   
            modelCarRentalDetail.CreatedDate = DateTime.Now;
            modelCarRentalDetail.Status = typeof(BookingFromDateChangedEvent).Name;

            return modelCarRentalDetail;
        }
        public static CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory ToDateChange(BookingToDateChangedEvent source)
        {
            CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory modelCarRentalDetail = new CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory();


            modelCarRentalDetail.RentalId = source.RentalId;
            modelCarRentalDetail.CarRentalEndDate = source.CarRentalEndDate;
            modelCarRentalDetail.CreatedDate = DateTime.Now;
            modelCarRentalDetail.Status = typeof(BookingToDateChangedEvent).Name;
            return modelCarRentalDetail;
        }
        public static CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory StatusChange(BookingCanceledEvent source)
        {
            CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory modelCarRentalDetail = new CQRS.CarRental.Events.Repository.Foundation.Models.CarRentalDetailsHistory();
            modelCarRentalDetail.RentalId = source.RentalId;         
            modelCarRentalDetail.CreatedDate = DateTime.Now;
            modelCarRentalDetail.Status = typeof(BookingCanceledEvent).Name;
            return modelCarRentalDetail;
        }

    }
}
