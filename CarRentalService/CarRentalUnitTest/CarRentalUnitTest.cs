using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRentalService.CarRental.Service;
using CQRS.CarRental.Infrastructure;
using CQRS.CarRental.Infrastructure.Utils;
using System.Net.Http;
using System.Net;
using Microsoft.Practices.Unity;
using CarRentalService;
using CQRS.CarRental.Events.Repository.Foundation;
using System.Data.Entity.Infrastructure;
using CQRS.CarRental.Repository;
using System.Web.Http;
using CQRS.CarRental.Repository.Foundation.Models;
using CQRS.CarRental.Events.Repository;
using System.Web.Http.Hosting;
using System.Web.Http.Controllers;

namespace CarRentalUnitTest
{
    [TestClass]
    public class CarRentalUnitTest
    {
        CommandBus commandBus;
        HttpConfiguration config = new HttpConfiguration();
        HttpRequestMessage request = new HttpRequestMessage();
        CarRentalBookingController controller;
        public CarRentalUnitTest()
        {
            this.loadUnity();
            commandBus = new CommandBus(new CommandHandlerFactory());
            controller = new CarRentalBookingController(commandBus);
            controller.ControllerContext = new HttpControllerContext();

            CarModelRepository repository2 = new CarModelRepository();
            CarRentalRepository repository = new CarRentalRepository();
            CarRentalHistoryRepository repository1 = new CarRentalHistoryRepository();
           

            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
        }
        [TestMethod]
        public void CarRentalPostUnitTest()
        {



            CQRS.CarRental.Contracts.CarRentalDetail objDetail = new CQRS.CarRental.Contracts.CarRentalDetail();
          
            objDetail.CarModelId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.Address = "Aditi Technologies,Chennai";
            objDetail.CarRentalEndDate = DateTime.Now.AddDays(10);
            objDetail.CarRentalStartDate = DateTime.Now;
            objDetail.ContactNumber = 90787833;
            objDetail.DriverName = "Robert";
            objDetail.EmailId = "Robert@sample.com";
            objDetail.LicenseneNumber = "IPQR908678";
            objDetail.LocationId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.status = "Active";
            var httpMessage = controller.PostCarRental(objDetail);
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);

        }
        [TestMethod]
        public void CarRentalPutUnitCancelStatusTest()
        {
           
            CQRS.CarRental.Contracts.CarRentalDetail objDetail = new CQRS.CarRental.Contracts.CarRentalDetail();
           
            objDetail.CarModelId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.Address = "Aditi Technologies,Chennai";
            objDetail.CarRentalEndDate = DateTime.Now.AddDays(10);
            objDetail.CarRentalStartDate = DateTime.Now;
            objDetail.ContactNumber = 90787833;
            objDetail.DriverName = "Robert";
            objDetail.EmailId = "Robert@sample.com";
            objDetail.LicenseneNumber = "IPQR908678";
            objDetail.LocationId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.status = "cancel";
            var httpMessage = controller.PutCarRental(objDetail);
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);
        }

        [TestMethod]
        public void CarRentalPutUnitFromDateChangeTest()
        {
            //commandBus = new CommandBus(new CommandHandlerFactory());
            //CarRentalBookingController controller = new CarRentalBookingController(commandBus);
            CQRS.CarRental.Contracts.CarRentalDetail objDetail = new CQRS.CarRental.Contracts.CarRentalDetail();
            // objDetail.RentalId = Guid.Parse("16b578f8-8948-481e-8ac5-c7bd3be6e27c");
            objDetail.CarModelId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.Address = "Aditi Technologies,Chennai";
            objDetail.CarRentalEndDate = DateTime.Now.AddDays(10);
            objDetail.CarRentalStartDate = DateTime.Now;
            objDetail.ContactNumber = 90787833;
            objDetail.DriverName = "Robert";
            objDetail.EmailId = "Robert@sample.com";
            objDetail.LicenseneNumber = "IPQR908678";
            objDetail.LocationId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.status = "Active";
            var httpMessage = controller.PutCarRental(objDetail);
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);
        }
        [TestMethod]
        public void CarRentalPutUnitToDateChangeTest()
        {
            //commandBus = new CommandBus(new CommandHandlerFactory());
            //CarRentalBookingController controller = new CarRentalBookingController(commandBus);
            CQRS.CarRental.Contracts.CarRentalDetail objDetail = new CQRS.CarRental.Contracts.CarRentalDetail();
            // objDetail.RentalId = Guid.Parse("16b578f8-8948-481e-8ac5-c7bd3be6e27c");
            objDetail.CarModelId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.Address = "Aditi Technologies,Chennai";
            objDetail.CarRentalEndDate = DateTime.Now.AddDays(10);
            objDetail.CarRentalStartDate = DateTime.Now;
            objDetail.ContactNumber = 90787833;
            objDetail.DriverName = "Robert";
            objDetail.EmailId = "Robert@sample.com";
            objDetail.LicenseneNumber = "IPQR908678";
            objDetail.LocationId = Guid.Parse("782f5a69-02e5-4da4-a52e-ddf06a0c97b2");
            objDetail.status = "Active";
            var httpMessage = controller.PutCarRental(objDetail);
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);
        }


        [TestMethod]
        public void CarRentalTodayGetcarDetailsTest()
        {
       
            var httpMessage = controller.GetcarDetails("T");
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);
        }

        [TestMethod]
        public void CarRentalReturnTodayGetcarDetailsTest()
        {
            commandBus = new CommandBus(new CommandHandlerFactory());
            CarRentalBookingController controller = new CarRentalBookingController(commandBus);
            var httpMessage = controller.GetcarDetails("R");
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);
        }

        [TestMethod]
        public void CarRentalPrefferdTodayGetcarDetailsTest()
        {
            commandBus = new CommandBus(new CommandHandlerFactory());
            CarRentalBookingController controller = new CarRentalBookingController(commandBus);
            var httpMessage = controller.GetcarDetails("F");
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);
        }


        [TestMethod]
        public void CarRentalleastTodayGetcarDetailsTest()
        {
            commandBus = new CommandBus(new CommandHandlerFactory());
            CarRentalBookingController controller = new CarRentalBookingController(commandBus);
            var httpMessage = controller.GetcarDetails("L");
            Assert.AreEqual(HttpStatusCode.Created, httpMessage.StatusCode);
        }

        private void loadUnity()
        {

            var container = new UnityContainer();

            container.RegisterType<IObjectContextAdapter, CarRentalDatabaseContext>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<ICarRentalRepository, CarRentalRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<CQRS.CarRental.Repository.Foundation.IUnitOfWork, CQRS.CarRental.Repository.Foundation.UnitOfWork>(new HierarchicalLifetimeManager());
            //
            container.RegisterType(typeof(CQRS.CarRental.Events.Repository.Foundation.IRepository<>), typeof(CQRS.CarRental.Events.Repository.Foundation.IRepository<>));
            container.RegisterType<IEventBus, EventBus>(new HierarchicalLifetimeManager());
            container.RegisterType<IEventHandlerFactory, EventHandlerFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandBus, CommandBus>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>(new HierarchicalLifetimeManager());
            // container.RegisterType<Interface1, test>();
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityResolver(container);


        }
    }
}
