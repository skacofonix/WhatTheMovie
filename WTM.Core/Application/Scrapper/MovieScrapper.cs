using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Scrapper
{
    public class MovieScrapper : ScrapperT<IMovie>
    {
        protected override string Identifier
        {
            get { return "movies"; }
        }

        public MovieScrapper(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected override IMovie Scrappe()
        {
            var movie = new Movie();

            // TODO

            return movie;
        }

    }
}
