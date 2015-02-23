using NFluent;
using NUnit.Framework;
using WTM.WebsiteClient.Parsers;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Parser
{
    [TestFixture]
    public class SettingsParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private SettingsParser parser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            parser = new SettingsParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var authenticateService = new AuthenticateService(webClient, htmlParser);
            authenticateService.Login("captainOblivious", "captainOblivious");

            var settings = parser.Parse();

            Check.That(settings.ShowGore).IsNotNull();
            Check.That(settings.ShowNudity).IsNotNull();
        }
    }
}
