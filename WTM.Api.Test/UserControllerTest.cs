using Moq;
using NFluent;
using NUnit.Framework;
using WTM.Api.Controllers;
using WTM.Core.Services;

namespace WTM.Api.Test
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public void WhenLoginRightThenReturnToken()
        {
            var userController = new UserController(new UserServiceFake());
            var response = userController.Login("captainOblivious", "captainOblivious");

            Check.That(response.HasError).IsFalse();
            Check.That(response.Token).IsNotEmpty();
        }

        [Test]
        public void WhenLoginWrongThenReturnError()
        {
            var userController = new UserController(new UserServiceFake());
            var response = userController.Login("captainOblivious", "wrongPassword");

            Check.That(response.HasError).IsTrue();
            Check.That(response.Token).IsNull();
        }
    }
}