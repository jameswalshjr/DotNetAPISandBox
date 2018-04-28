using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Data.Repository;
using DotNetAPISandBox.Data.Resource;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace DotNetAPISandBox
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register Repositories
            container.Register<IMaintenanceRepository, MaintenanceRepository>();

            // Register DB Contexts
            container.Register<BillingContext, BillingContext>(new AsyncScopedLifestyle());

            // Register Controller
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
