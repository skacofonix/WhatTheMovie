using NFluent;
using NUnit.Framework;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Parsers;

namespace WTM.WebsiteClient.Test.Parser
{
    [TestFixture]
    public class UserParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private UserParser userParser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            userParser = new UserParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var user = userParser.Parse("alex68");

            Check.That(user).IsNotNull();
        }
    }
}