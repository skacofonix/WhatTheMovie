using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler;
using WTM.RestApi.Models;
using WTM.RestApi.Services;

namespace WTM.RestApi.Tests.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService userService;

        [SetUp]
        public void Initialize()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            var crawlerServie = new Crawler.Services.UserService(webClient, htmlParser);
            this.userService = new UserService(crawlerServie);
        }

        [Test]
        public void ShouldSearchUserByFilter()
        {
            var simpleResult = this.userService.Search(new UserSearchRequest {Filter = "ama"});

            Check.That(simpleResult).IsNotNull();
            Check.That(simpleResult.DisplayMin).Equals(1);
            Check.That(simpleResult.DisplayMax).Equals(31);
        }

        [Test]
        public void ShouldSearchUserByFilterWithStart()
        {
            var simpleResult = this.userService.Search(new UserSearchRequest { Filter = "ama", Start = 102});

            Check.That(simpleResult).IsNotNull();
            Check.That(simpleResult.DisplayMin).Equals(102);
            Check.That(simpleResult.DisplayMax).Equals(132);
        }

        [Test]
        public void ShouldSearchUserByFilterWithRange()
        {
            var simpleResult = this.userService.Search(new UserSearchRequest { Filter = "ama", Start = 102, Limit = 100});

            Check.That(simpleResult.DisplayMin).Equals(102);
            Check.That(simpleResult.DisplayMax).Equals(202);
        }

        [Test]
        public void ShouldSearchUserByFilterWithOutOfRange()
        {
            var simpleResult = this.userService.Search(new UserSearchRequest { Filter = "ama", Start = 400, Limit = 100 });

            Check.That(simpleResult.DisplayMin).Equals(400);
            Check.That(simpleResult.DisplayMax).IsLessThan(500);
        }

        [Test]
        public void ShouldSearchUserWithNeitherResut()
        {
            var simpleResult = this.userService.Search(new UserSearchRequest { Filter = "azezaeezarazerzearazr" });

            Check.That(simpleResult.DisplayMin).Equals(0);
            Check.That(simpleResult.DisplayMax).Equals(0);
            Check.That(simpleResult.TotalCount).Equals(0);
        }

        [Test]
        public void ShouldSearchUserWithOneResut()
        {
            var simpleResult = this.userService.Search(new UserSearchRequest { Filter = "captainOblivious" });

            Check.That(simpleResult.DisplayMin).Equals(1);
            Check.That(simpleResult.DisplayMax).Equals(1);
            Check.That(simpleResult.TotalCount).Equals(1);
            Check.That(simpleResult.Items.First().Username).Equals("captainOblivious");
        }
    }
}
