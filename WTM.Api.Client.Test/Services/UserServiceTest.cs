using NFluent;
using NUnit.Framework;
using WTM.Api.Client.Services;
using WTM.Core.Services;

namespace WTM.Api.Client.Test.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService userService;

        [SetUp]
        public void BeforeTest()
        {
            userService = new UserService(new SettingsProxy());
        }

        [Test]
        public void WhenGetSpecificUserThenReturnOneValidEntity()
        {
            var user = userService.GetUser("alex68");
            Check.That(user).IsNotNull();
        }

        [Test]
        public void Blop()
        {
            var users = userService.Search("alex");
            Check.That(users).IsNotNull();
            Check.That(users.Count()).IsGreaterThan(0);
        }
    }
}