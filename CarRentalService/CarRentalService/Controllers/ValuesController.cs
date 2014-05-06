
using CQRS.CarRental.Events.Repository.Foundation;
using CQRS.CarRental.Infrastructure;
using CQRS.CarRental.Infrastructure.Utils;
using CQRS.CarRental.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentalService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values


        ICommandBus excuteCommand;


        public ValuesController(ICommandBus excuteCommand)
        {
        
            this.excuteCommand = excuteCommand;
        }
        public void Get()
        {
            try
            {
                var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
              var rentalDetail=  carRentalRepository.GetAll();
                Guid newGuid = new Guid("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
                CreateBookingCommand obj = new CreateBookingCommand(Guid.NewGuid(), newGuid, DateTime.Now,
                    DateTime.Now, newGuid, 5, "deepak", "deepak", 3434, "dfdf", "dsffgdf");
                excuteCommand.Send<CreateBookingCommand>(obj);

            }
            catch (Exception ex)
            {
                string ex1 = ex.Message;
            }

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}