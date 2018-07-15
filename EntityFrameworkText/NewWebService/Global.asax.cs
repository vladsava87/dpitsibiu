using AutoMapper;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using Newtonsoft.Json;
using NewWebService.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NewWebService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
            
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

        }

        public static class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.CreateMap<t_clasa, ClasaDTO>();
                Mapper.CreateMap<t_observatie, ObservatieDTO>();
                Mapper.CreateMap<t_profesor, ProfesorDTO>();
            }
        }
    }
}
