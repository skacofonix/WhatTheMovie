using NFluent;
using NUnit.Framework;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Test.Parser
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
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            parser = new SearchMovieTvParser(webClient, htmlParser);
        }

        [Test]
        public void WhenSearchTagThenReturnResults()
        {
            var results = parser.Search("eternal");

            Check.That(results).IsNotNull();
            Check.That(results.Items).IsNotNull();
            Check.That(results.Items.Count).IsGreaterThan(0);
        }
    }
}