using CQRS.CarRental.Contracts;
using CQRS.CarRental.Infrastructure;
using CQRS.CarRental.Infrastructure.Commands;
using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentalService.CarRental.Service
{
    public class CarRentalBookingController : ApiController
    {


        ICommandBus commandBus;
        public CarRentalBookingController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
         /// < summary>
                 ///T: Query what are all the cars are going out on rental today
                ///R:Query what are all the cars are returning today
               ///F:Query which is most favorite / preferred model
              ///E:Retrieve least expensive rental car
        /// </summary>
        /// <returns>
        /// 
        /// It returns the data based on the user input
        /// </returns>
        public HttpResponseMessage GetcarDetails(string queryMode)
        {

            HttpResponseMessage httpresponseMessage = new HttpResponseMessage();
            var rentalModel = RepositoryFactory.Current.Get<ICarRentalRepository>();
            var carModel = RepositoryFactory.Current.Get<ICarModelRepository>();

            try
            {
                switch (queryMode)
                {
                   
                    case "T":
                var todayCarResult = (from rentalModel1 in rentalModel.GetAll()
                              join carModel1 in carModel.GetAll() on
                                  rentalModel1.CarModelId equals carModel1.CarModelId
                              where rentalModel1.CarRentalStartDate.Year == DateTime.Now.Year && rentalModel1.CarRentalStartDate.Day == DateTime.Now.Day &&
                              rentalModel1.CarRentalStartDate.Month == DateTime.Now.Month
                              select new { ModelName = carModel1.ModelName, TariffRate = carModel1.RentalTariff, DriverName = rentalModel1.DriverName, ContactNumber = rentalModel1.ContactNumber }).ToList();

                httpresponseMessage = Request.CreateResponse(HttpStatusCode.Created, todayCarResult);
                break;

                    case "R":
                var returnCaResult = (from rentalModel1 in rentalModel.GetAll()
                              join carModel1 in carModel.GetAll() on
                                  rentalModel1.CarModelId equals carModel1.CarModelId
                              where rentalModel1.CarRentalEndDate.Year == DateTime.Now.Year && rentalModel1.CarRentalEndDate.Day == DateTime.Now.Day &&
                              rentalModel1.CarRentalEndDate.Month == DateTime.Now.Month
                              select new { ModelName = carModel1.ModelName, TariffRate = carModel1.RentalTariff, DriverName = rentalModel1.DriverName, ContactNumber = rentalModel1.ContactNumber }).ToList();

                httpresponseMessage = Request.CreateResponse(HttpStatusCode.Created, returnCaResult);
                break;

                //    case "L":
                //var returnCaResult = (from rentalModel1 in rentalModel.GetAll()
                //                      join carModel1 in carModel.GetAll() on
                //                          rentalModel1.CarModelId equals carModel1.CarModelId
                //                      where rentalModel1.CarRentalEndDate.Year == DateTime.Now.Year && rentalModel1.CarRentalEndDate.Day == DateTime.Now.Day &&
                //                      rentalModel1.CarRentalEndDate.Month == DateTime.Now.Month
                //                      select new { ModelName = carModel1.ModelName, TariffRate = carModel1.RentalTariff, DriverName = rentalModel1.DriverName, ContactNumber = rentalModel1.ContactNumber }).ToList();

                //httpresponseMessage = Request.CreateResponse(HttpStatusCode.Created, returnCaResult);
                //break;



                   // case "F":

                //var returnFavouriteResult = (from rentalModel1 in rentalModel.GetAll()
                //                            join carModel1 in carModel.GetAll() on
                //                                rentalModel1.CarModelId equals carModel1.CarModelId
                //                            group carModel1 by carModel1.ModelName into favouriteModel)
                //                            select new { Key = favouriteModel.Key, count = favouriteModel.Count };





        //                //from c in dsEC09.Employee
        //group c by c.DepartMent into g
        //select new { g.Key, Count = g.Count() };

                }
            }
            catch (Exception ex)
            {

                httpresponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return httpresponseMessage;
            
        }            

        /// <summary>
        /// Controller process the request and send to command handler for saving the data
        /// </summary>
        /// <param name="carRentalDetail">details of the car which is been rented out to the customer</param>
        /// <returns></returns>
        public HttpResponseMessage PostCarRental(CQRS.CarRental.Contracts.CarRentalDetail carRentalDetail)
        {
            string httpMessage=string.Empty ;
            string validationErrorMessage = string.Empty;
            try
            {
                validationErrorMessage = CarRentalDetailValidation.ValidateDetail(carRentalDetail);
                if (string.IsNullOrEmpty(validationErrorMessage)==true)
                {
                    commandBus.Send<CreateBookingCommand>(new CreateBookingCommand(Guid.NewGuid(), carRentalDetail.CarModelId, carRentalDetail.CarRentalEndDate,
                                                          carRentalDetail.CarRentalStartDate, carRentalDetail.LocationId, 100, carRentalDetail.DriverName,
                                                          carRentalDetail.LicenseneNumber, carRentalDetail.ContactNumber, carRentalDetail.EmailId, carRentalDetail.Address));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK , validationErrorMessage);
                }
            }
            catch (Exception exceptionMessage)
            {
                httpMessage = exceptionMessage.Message;
               return Request.CreateResponse(HttpStatusCode.BadRequest,httpMessage);
            }
            return Request.CreateResponse(HttpStatusCode.Created, CarRentalDetailValidation.Responsemessage);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carRentalDetail"></param>
        public HttpResponseMessage PutCarRental(CQRS.CarRental.Contracts.CarRentalDetail carRentalDetail)
        {
            string httpMessage = string.Empty;
            string validationErrorMessage = string.Empty;
            try
            {
                validationErrorMessage = CarRentalDetailValidation.ValidateDetail(carRentalDetail);
                if (string.IsNullOrEmpty(validationErrorMessage) == true)
                {
                    commandBus.Send<ChangeBookingCommand>(new ChangeBookingCommand(carRentalDetail.RentalId, carRentalDetail.CarModelId, carRentalDetail.CarRentalEndDate,
                                                          carRentalDetail.CarRentalStartDate, carRentalDetail.LocationId, 100, carRentalDetail.DriverName,
                                                          carRentalDetail.LicenseneNumber, carRentalDetail.ContactNumber, carRentalDetail.EmailId, carRentalDetail.Address, carRentalDetail.status));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, validationErrorMessage);
                }
            }
            catch (Exception exceptionMessage)
            {
                httpMessage = exceptionMessage.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, httpMessage);
            }
            return Request.CreateResponse(HttpStatusCode.Created, CarRentalDetailValidation.Responsemessage);




        }

       
    }
}