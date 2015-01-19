using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Test.Properties;

namespace WTM.Core.Test.Application.Parser
{
    [TestFixture]
    public class SearchMovieTvParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private SearchMovieTvParser parser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientFake(Resources.FeatureFilms20141201);
            htmlParser = new HtmlParser();
            parser = new SearchMovieTvParser(webClient, htmlParser);
        }

        [Test]
        public void TestMethod1()
        {
            var results = parser.Search("eternal");

            Check.That(results).IsNotNull();
            Check.That(results.Items).IsNotNull();
            Check.That(results.Items.Count).IsGreaterThan(0);
        }
    }
}