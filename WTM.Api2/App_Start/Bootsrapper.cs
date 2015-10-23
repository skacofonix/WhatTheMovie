using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using WTM.Api2.Services;
using System.Web.Http;

namespace WTM.Api2
{
    public class Bootsrapper
    {
        public static void Configure(HttpConfiguration config)
        {
            var container = new LightInject.ServiceContainer();

            container.Register<IMovieService, MovieService>(new PerContainerLifetime());
            container.Register<IShotBookmarkService, ShotBookmarkService>(new PerContainerLifetime());
            container.Register<IShoteRateService, ShoteRateService>(new PerContainerLifetime());
            container.Register<IShotFavouriteService, ShotFavouriteService>(new PerContainerLifetime());
            container.Register<IShotOverviewService, ShotOverviewService>(new PerContainerLifetime());
            container.Register<IShotService, ShotService>(new PerContainerLifetime());
            container.Register<IShotTagService, ShotTagService>(new PerContainerLifetime());

            config.DependencyResolver = new DependencyResolver(container);
        }
    }
}
