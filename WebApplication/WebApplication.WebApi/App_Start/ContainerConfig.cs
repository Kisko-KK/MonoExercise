using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebApplication.Repository;
using WebApplication.Repository.Common;
using WebApplication.Service;
using WebApplication.Service.Common;

namespace WebApplication.WebApi.App_Start
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            IContainer container =  builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}