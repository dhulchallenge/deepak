using CQRS.CarRental.Infrastructure;
using CQRS.CarRental.Infrastructure.Utils;
using CQRS.CarRental.Repository;
using CQRS.CarRental.Repository.Foundation;
using CQRS.CarRental.Repository.Foundation.Foundation;
using CQRS.CarRental.Repository.Foundation.Models;
using CQRS.CarRental.Repository.Foundation.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;

namespace CarRentalService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            // : Repository<CarRentalDetail>, 

            var container = new UnityContainer();
       
            container.RegisterType<IObjectContextAdapter, CarRentalDatabaseContext>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<ICarRentalRepository, CarRentalRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            //
            container.RegisterType(typeof(CQRS.CarRental.Events.Repository.Foundation.IRepository<>), typeof(CQRS.CarRental.Events.Repository.Foundation.IRepository<>));
            container.RegisterType<IEventBus, EventBus>(new HierarchicalLifetimeManager());
            container.RegisterType<IEventHandlerFactory, EventHandlerFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandBus, CommandBus>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>(new HierarchicalLifetimeManager());
           // container.RegisterType<Interface1, test>();

            config.DependencyResolver = new UnityResolver(container);


            config.Routes.MapHttpRoute(
            name: "CarRental",
              routeTemplate: "service/CarRentalBooking",
              defaults: new { controller = "CarRentalBooking", id = RouteParameter.Optional});



            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
