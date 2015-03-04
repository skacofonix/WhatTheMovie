using NFluent;
using NUnit.Framework;
using System.Linq;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private UserService userService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            userService = new UserService(webClient, htmlParser);
        }

        [Test]
        public void WhenGetUserThenReturnEntity()
        {
            var user = userService.GetByUsername("alex68");

            Check.That(user).IsNotNull();
        }

        [Test]
        public void WhenSearchUserThenRetuenSomeResults()
        {
            var results = userService.Search("alex");

            Check.That(results).IsNotNull();
            Check.That(results.ToList().Count).IsGreaterThan(0);
        }
    }
}
