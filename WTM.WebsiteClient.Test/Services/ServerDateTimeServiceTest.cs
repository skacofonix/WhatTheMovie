using NFluent;
using NUnit.Framework;
using WTM.Core.Services;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
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