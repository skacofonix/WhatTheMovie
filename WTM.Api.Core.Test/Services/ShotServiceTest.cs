using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Api.Core.Services;

namespace WTM.Api.Core.Test.Services
{
    [TestFixture]
    public class ShotServiceTest
    {
        private IShotService shotService;

        [SetUp]
        public void BeforTest()
        {
            var context = new Context();
            shotService = new ShotService(context);
        }

        [Test]
        public void WhenInstanciateShotServiceThenReturnInstance()
        {
            Check.That(shotService).IsNotNull();
        }

        [Test]
        public void WhenGetRandomShotThenReturnShot()
        {
            var shot = shotService.GetRandomShot();
            Check.That(shot).IsNotNull();
        }

        [Test]
        public void WhenGetShotByIdThenReturnRightShot()
        {
            var shot = shotService.GetShotById(10);
            Check.That(shot.ShotId).Equals(10);
        }
    }
}