using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using WTM.CorePCL.Application;
using WTM.CorePCL.Domain.WebsiteEntities;
using WTM.CorePCL.Test.Application;

namespace WTM.CorePCL.Test.Application.Scrapper
{
    [TestClass]
    public class ScrapperShotTest
    {
        [TestMethod]
        public void WhenCallRealUrlThenParseCorrectlyShot()
        {
            IWebClient webClient = new WebClient();
            IHtmlParser htmlParser = new HtmlParser();
            var scrapper = new ShotScrapper(webClient, htmlParser);

            IShot shot = scrapper.Scrappe("10");

            Check.That(shot).IsNotNull();
        }


        [TestMethod]
        public void WhenStubWebClientThenParseCorrectlyShot()
        {
            IWebClient webClient = new StubWebClientShot();
            IHtmlParser htmlParser = new HtmlParser();
            var scrapper = new ShotScrapper(webClient, htmlParser);

            IShot shot = scrapper.Scrappe("10");

            Check.That(shot).IsNotNull();
        }
    }
}
