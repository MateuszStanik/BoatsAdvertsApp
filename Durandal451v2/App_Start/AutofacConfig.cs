using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
//using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UnitOfWork;


namespace BoatsAdvertsApp.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<EFDbContext>().AsImplementedInterfaces();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new AutoMapperAutoFacModule());

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}