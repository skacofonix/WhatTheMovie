using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.WebsiteClient.Test.Application.Parser
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
            var authentifier = new Authentifier(webClient, htmlParser);
            if (authentifier.Login("captainOblivious", "captainOblivious"))
                webClient.SetCookie(authentifier.CookieSession);

            var settings = parser.Parse();

            Check.That(settings.ShowGore).IsNotNull();
            Check.That(settings.ShowNudity).IsNotNull();
        }
    }
}
