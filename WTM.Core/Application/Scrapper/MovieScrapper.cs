using System;
using System.Linq;
using WTM.Core.Application.Scrapper.Base;
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

        protected override void Scrappe(IMovie instance)
        {
            var movie = new Movie();

            var headerTitleSection = Document.GetElementbyId("main_white")
                                             .Descendants("div")
                                             .FirstOrDefault(d => d.Attributes.Any(attr => attr.Name == "class" && attr.Value == "header clearfix"));

            var titleSection = headerTitleSection.Descendants("h1")
                                                 .FirstOrDefault();

            var dateSection = titleSection.Descendants("span")
                                          .FirstOrDefault()
                                          .InnerText;

            movie.OriginalTitle = GetOriginalTitle();

            // TODO
        }

        private string GetOriginalTitle()
        {
            throw new NotImplementedException();
        }

    }
}
