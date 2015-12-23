using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using WTM.Crawler;
using WTM.RestApi.Resolver;

namespace WTM.RestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            var container = new UnityContainer();
            container.RegisterType<IWebClient, WebClientWTM>(new HierarchicalLifetimeManager());
            container.RegisterType<IHtmlParser, HtmlParser>(new HierarchicalLifetimeManager());
            container.RegisterType<WTM.RestApi.Services.IUserService, WTM.RestApi.Services.UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<Crawler.Services.IUserService, Crawler.Services.UserService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
