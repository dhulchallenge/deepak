using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
   public class CarRentalDetailValidation
    {
       public static string ValidateDetail(CQRS.CarRental.Contracts.CarRentalDetail careRentalDetail)
       {
           string errorInput = string.Empty;
           StringBuilder errorBuilder = new StringBuilder();
           if (String.IsNullOrEmpty(careRentalDetail.CarModelId.ToString()) == true)
           {
               errorBuilder.AppendFormat("{0}{1}","car model: ","Select the car model");
           }
           if(String.IsNullOrEmpty(careRentalDetail.CarRentalEndDate.ToString())==true)
           {
                 errorBuilder.AppendFormat("{0}{1}","EndDate: ","Select the end date");
           }
            if(String.IsNullOrEmpty(careRentalDetail.CarRentalStartDate.ToString())==true )
           {
                errorBuilder.AppendFormat("{0}{1}","StartDate: ","Select the start date");
           }
           if(String.IsNullOrEmpty(careRentalDetail.ContactNumber.ToString())==true)
           {
                errorBuilder.AppendFormat("{0}{1}","contact number: ","enter the contact number");
           }
           if(String.IsNullOrEmpty(careRentalDetail.DriverName.ToString())==true)
           {
                errorBuilder.AppendFormat("{0}{1}","driver name: ","enter the driver name");
           }
           if(String.IsNullOrEmpty(careRentalDetail.EmailId.ToString())==true)
           {
                errorBuilder.AppendFormat("{0}{1}","email Id: ","enter the email Id");
           }
           if(String.IsNullOrEmpty(careRentalDetail.LicenseneNumber.ToString())==true)
           {
                errorBuilder.AppendFormat("{0}{1}","license number: ","enter the license number");
           }
           if(String.IsNullOrEmpty(careRentalDetail.LocationId.ToString())==true)
           {
                errorBuilder.AppendFormat("{0}{1}","location: ","select the location");
           }

           if(careRentalDetail.CarRentalStartDate >careRentalDetail.CarRentalEndDate)
           {
               errorBuilder.AppendFormat("{0}{1}","date range:","start date should be less than end date");
           }
           //
           var carModel = RepositoryFactory.Current.Get<ICarModelRepository>();
           //&& s.Status == true
           // 
           //
           int countModel = carModel.GetAll().Where(s => s.CarModelId == careRentalDetail.CarModelId && s.AvailabilityEndDate.Value.Subtract(careRentalDetail.CarRentalEndDate).Days >= 0 &&  s.AvailabilityStartDate.Value.Subtract(careRentalDetail.CarRentalStartDate).Days <=0).Count();
           if (countModel == 0)
           {
               errorBuilder.AppendFormat("{0}{1}", "car availability:", "selected model is not available in selected date range");
           }

           if (carModel.GetAll().Where(s => s.CarModelId == careRentalDetail.CarModelId && s.Status == true).Count() == 0)
           {
               errorBuilder.AppendFormat("{0}{1}", "car availability:", "selected model is not available");
           }

           return errorBuilder.ToString();
       }

     

       public static string Responsemessage = "Data has been saved successfully ,Booking Id will be send to your email Id";
    }
}
