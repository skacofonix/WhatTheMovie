using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.Core.Application;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Application.Scrapper;
using NFluent;

namespace WTM.Test.Application.Scrapper
{
    [TestClass]
    public class ScrapperMovieTest
    {
        [TestMethod]
        public void WhenCallRealUrlThenParseCorrectlyMovie()
        {
            IWebClient webClient = new WebClient();
            IHtmlParser htmlParser = new HtmlParser();
            var scrapper = new MovieScrapper(webClient, htmlParser);

            IMovie movie = scrapper.Scrappe("10");

            Check.That(movie).IsNotNull();
        }
    }
}
