using CoffeeShop.Components.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CoffeeShop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configure dependency injection
            ConfigureDepdendencyInjection(config);

            // Configure attribute routing
            config.MapHttpAttributeRoutes();

            
            // Routes
            ConfigureRoutes(config);

            // Response Formatters
            // ConfigureMediaFormatters(config);

            // Misc Configurations
            // ConfigureOthers(config);

            config.EnsureInitialized();
        }


        private static void ConfigureDepdendencyInjection(HttpConfiguration config)
        {
            // Create the container as usual.
            var container = new Container();

            // Register types
            container.RegisterWebApiRequest<IBeveragesRepository, BeveragesRepository>();
            container.RegisterWebApiRequest<IBeverageSizesRepository, BeverageSizesRepository>();
            container.RegisterWebApiRequest<IBeveragePricesRepository, BeveragePricesRepository>();
            container.RegisterWebApiRequest<IOrdersRepository, OrdersRepository>();
            // Register controllers with container
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Verify Container
            container.Verify();

            config.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void ConfigureRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "service/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
