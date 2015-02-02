using System.Net;
using NFluent;
using NUnit.Framework;
using WTM.WebsiteClient.Application;

namespace WTM.WebsiteClient.Test
{
    [TestFixture]
    public class AuthentifierTest
    {
        [Test]
        public void WhenWrongAuthenticateWithLoginAndPasswordThenFail()
        {
            var authentifier = new Authentifier(new WebClientWTM(), new HtmlParser());

            BooleanCheckExtensions.IsFalse(Check.That(authentifier.Login("captainOblivious", "wrongPassword")));
            ObjectCheckExtensions.IsNull<Cookie>(Check.That(authentifier.CookieSession));
        }

        [Test]
        public void WhenAuthenticateWithLoginAndPasswordThenSuccess()
        {
            var authentifier = new Authentifier(new WebClientWTM(), new HtmlParser());

            BooleanCheckExtensions.IsTrue(Check.That(authentifier.Login("captainOblivious", "captainOblivious")));
            ObjectCheckExtensions.IsNotNull<Cookie>(Check.That(authentifier.CookieSession));
        }
    }
}
