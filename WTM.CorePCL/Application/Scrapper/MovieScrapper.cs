using System;
using System.Linq;
using WTM.CorePCL.Domain.WebsiteEntities;
using WTM.CorePCL.Domain.WebsiteEntities;

namespace WTM.CorePCL.Application.Scrapper
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

            var headerTitleSection = document.GetElementbyId("main_white")
                                             .Descendants("div")
                                             .FirstOrDefault(d => d.Attributes.Any(attr => attr.Name == "class" && attr.Value == "header clearfix"));

            var titleSection = headerTitleSection.Descendants("h1")
                                                 .FirstOrDefault();

            var dateSection = titleSection.Descendants("span")
                                          .FirstOrDefault()
                                          .InnerText;

            movie.OriginalTitle = GetOriginalTitle();

            // TODO

            return movie;
        }

        private string GetOriginalTitle()
        {
            throw new NotImplementedException();
        }

    }
}
