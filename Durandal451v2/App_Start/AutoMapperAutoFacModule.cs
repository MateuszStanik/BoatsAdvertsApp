using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoatsAdvertsApp.App_Start
{
    public class AutoMapperAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(x => typeof(Profile).IsAssignableFrom(x) && !x.IsAbstract && x.IsPublic)
                .As<Profile>();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>()
            .CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();

        }
    }
}