    using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WTM.RestApi.Services;

namespace WTM.RestApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			//var container = new UnityContainer();

   //         // register all your components with the container here
   //         // it is NOT necessary to register your controllers

   //         // e.g. container.RegisterType<ITestService, TestService>();

   //         container.RegisterType<IMovieService, MovieService>();
   //         container.RegisterType<IShotBookmarkService, ShotBookmarkService>();
   //         container.RegisterType<IShoteRateService, ShoteRateService>();
   //         container.RegisterType<IShotFavouriteService, ShotFavouriteService>();
   //         container.RegisterType<IShotSummaryService, ShotSummaryService>();
   //         container.RegisterType<IShotService, ShotService>();
            
   //         GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}