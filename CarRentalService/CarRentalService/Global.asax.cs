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
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarRentalService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          

           WebApiConfig.Register(GlobalConfiguration.Configuration);
          
        }

       
    }

    
}