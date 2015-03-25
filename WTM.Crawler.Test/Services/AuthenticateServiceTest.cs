using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class AuthenticateServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private AuthenticateService authenticateService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            authenticateService = new AuthenticateService(webClient, htmlParser);
        }

        [Test]
        public void WhenWrongAuthenticateWithLoginAndPasswordThenFail()
        {
            Check.That(authenticateService.Login("captainOblivious", "wrongPassword")).IsNull();
        }

        [Test]
        public void WhenAuthenticateWithLoginAndPasswordThenSuccess()
        {
            Check.That(authenticateService.Login("captainOblivious", "captainOblivious")).IsNotNull();
        }
    }
}