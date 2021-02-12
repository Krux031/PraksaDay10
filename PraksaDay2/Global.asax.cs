using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using CityService;
using CityServiceCommon;
using CityRepository;
using CityRepositoryCommon;
using CityModel;
using CityModelCommon;
using AutoMapper;

namespace PraksaDay2
{
    public class Global : System.Web.HttpApplication
    {

        private static IContainer container { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(PraksaDay2Config.Register);

            var builder = new ContainerBuilder();

            builder.RegisterModule<CityServiceModule>();
            builder.RegisterModule<CityRepositoryModule>();
            builder.RegisterModule<CityModelModule>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ICity, GetViewModel>();
                cfg.CreateMap<PostViewModel, IResidents>();
            })).AsSelf().SingleInstance(); 

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            //po defaultu ako se ne odabere specificni scope, on ce biti InstancePerDependency

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }

}