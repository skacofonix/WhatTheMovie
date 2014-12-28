using NFluent;
using NUnit.Framework;
using System.Linq;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Test.Properties;

namespace WTM.Core.Test.Application.Parser
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
            var featureFilm = parser.Parse();

            Check.That(featureFilm).IsNotNull();
            Check.That(featureFilm.Date).IsNotNull();
            Check.That(featureFilm.Shots).IsNotNull();
            Check.That(featureFilm.Shots.Any()).IsTrue();
        }
    }
}
