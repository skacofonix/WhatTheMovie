using System.Web.Http;
using Microsoft.Practices.Unity;
using WTM.Api.Resolver;
using WTM.Api.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using IMovieService = WTM.Api.Services.IMovieService;
using IShotService = WTM.Api.Services.IShotService;
using IUserService = WTM.Api.Services.IUserService;
using MovieService = WTM.Api.Services.MovieService;
using ShotService = WTM.Api.Services.ShotService;
using UserService = WTM.Api.Services.UserService;

namespace WTM.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            var container = new UnityContainer();

            container.RegisterType<IWebClient, WebClientWTM>(new HierarchicalLifetimeManager());
            container.RegisterType<IHtmlParser, HtmlParser>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<Crawler.Services.IUserService, Crawler.Services.UserService>(new HierarchicalLifetimeManager());

            container.RegisterType<IImageRepository, ImageRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IImageDownloader, ImageDownloader>(new HierarchicalLifetimeManager());

            container.RegisterType<IShotService, ShotService>(new HierarchicalLifetimeManager());
            container.RegisterType<IShotSummaryService, ShotSummaryService>(new HierarchicalLifetimeManager());
            container.RegisterType<IShoteRateService, ShoteRateService>(new HierarchicalLifetimeManager());
            container.RegisterType<IShotFavouriteService, ShotFavouriteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IShotBookmarkService, ShotBookmarkService>(new HierarchicalLifetimeManager());
            container.RegisterType<IShotTagService, ShotTagService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMovieService, MovieService>(new HierarchicalLifetimeManager());
            container.RegisterType<Crawler.Services.IShotService, Crawler.Services.ShotService>(new HierarchicalLifetimeManager());
            container.RegisterType<Crawler.Services.IShotOverviewService, Crawler.Services.ShotOverviewService>(new HierarchicalLifetimeManager());
            container.RegisterType<Crawler.Services.IShotFeatureFilmsService, Crawler.Services.ShotFeatureFilmsService>(new HierarchicalLifetimeManager());
            container.RegisterType<Crawler.Services.IShotArchiveService, Crawler.Services.ShotArchiveService>(new HierarchicalLifetimeManager());
            container.RegisterType<Crawler.Services.IShotNewSubmissionsService, Crawler.Services.ShotNewSubmissionsService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDateTimeService, DateTimeService>(new HierarchicalLifetimeManager());

            container.RegisterType<IImageResourceService, ImageResourceService>(new HierarchicalLifetimeManager());

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
