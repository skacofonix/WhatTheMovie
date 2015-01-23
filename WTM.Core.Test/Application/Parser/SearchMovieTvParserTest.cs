using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.WebsiteClient.Test.Application.Parser
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
        public void TestMethod1()
        {
            var results = parser.Search("eternal");

            Check.That(results).IsNotNull();
            Check.That(results.Items).IsNotNull();
            Check.That(results.Items.Count).IsGreaterThan(0);
        }
    }
}