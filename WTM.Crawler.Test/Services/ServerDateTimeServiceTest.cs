using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class ServerDateTimeServiceTest
    {
        private IWebClient webClient;
        private IServerDateTimeService serverDateTimeService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            serverDateTimeService = new ServerDateTimeService(webClient);
        }

        [Test]
        public void WhenGetDateTimeThenReturnDateTimeOfWtmServer()
        {
            Check.That(serverDateTimeService.GetDateTime()).IsNotNull();
        }
    }
}