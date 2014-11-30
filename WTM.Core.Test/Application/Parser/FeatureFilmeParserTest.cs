using NFluent;
using NUnit.Framework;
using System.Linq;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;

namespace WTM.Core.Test.Application.Parser
{
    [TestFixture]
    public class FeatureFilmeParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private FeatureFilmParser parser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            parser = new FeatureFilmParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var featureFilm = parser.Parse();

            Check.That(featureFilm.Shots).IsNotNull();
            Check.That(featureFilm.Shots.Any()).IsTrue();
        }
    }
}
