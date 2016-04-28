using Autofac;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zad7.Interfaces;
using Autofac.Integration.WebApi;
using Zad7.Services;

namespace Zad7
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<Zad7.DbCRUD.LiteDB.ArtistsRepository>().As<IArtistsRepository>().InstancePerRequest();
            builder.RegisterType<Zad7.DbCRUD.PostgreSQL.PaintingsRepository>().As<IPaintingsRepository>().InstancePerRequest();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
