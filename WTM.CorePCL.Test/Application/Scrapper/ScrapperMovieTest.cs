using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using WTM.CorePCL.Application;
using WTM.CorePCL.Application.Scrapper;
using WTM.CorePCL.Domain.WebsiteEntities;

namespace WTM.CorePCL.Test.Application.Scrapper
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
