using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Parsers;
using WTM.Crawler.Test.Properties;

namespace WTM.Crawler.Test.Parser
{
    [TestFixture]
    public class OverviewShotParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private OverviewShotParser parser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientFake(Resources.FeatureFilms20141201);
            htmlParser = new HtmlParser();
            parser = new OverviewShotParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var featureFilm = parser.ParseOverviewShotByDate();

            Check.That(featureFilm).IsNotNull();
            Check.That(featureFilm.Date).IsNotNull();
            Check.That(featureFilm.Shots).IsNotNull();
            Check.That(featureFilm.Shots.Any()).IsTrue();
        }
    }
}
