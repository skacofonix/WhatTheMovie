using NFluent;
using NUnit.Framework;
using WTM.Api.Client.Services;
using WTM.Core.Services;

namespace WTM.Api.Client.Test.Services
{
    [TestFixture]
    public class ShotServiceTest
    {
        [Test]
        public void WhenInitializeShotServiceThenReturnEntity()
        {
            IShotService shotService = new ShotService();
            Check.That(shotService).IsNotNull();
        }

        [Test]
        public void WhenGetRandomShotThenReturnShot()
        {
            IShotService shotService = new ShotService();
            var shot = shotService.GetRandomShot();
            Check.That(shot).IsNotNull();
        }
    }
}