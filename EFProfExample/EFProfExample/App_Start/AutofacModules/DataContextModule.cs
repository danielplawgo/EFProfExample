using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using EFProfExample.Models;
using EFProfExample.Repositories;

namespace EFProfExample.App_Start.AutofacModules
{
    public class DataContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                .InstancePerRequest()
                ;

            builder.RegisterAssemblyTypes(typeof(Repository<>).Assembly)
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>)))
                .AsImplementedInterfaces();
        }
    }
}