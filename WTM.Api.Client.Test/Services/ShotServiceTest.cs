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

        [Test]
        public void WhenGetShotThenReturnThisShot()
        {
            IShotService shotService = new ShotService();
            var shot = shotService.GetShotById(10);
            Check.That(shot).IsNotNull();
        }

        [Test]
        public void WhenGuessRightTitleThenReturnGuessTitleResponse()
        {
            IShotService shotService = new ShotService();
            var guessTitleResponse = shotService.GuessTitle(10, "Eternal Sunshine of the spotless mind");
            Check.That(guessTitleResponse).IsNotNull();
            Check.That(guessTitleResponse.RightGuess).IsNotNull().And.IsEqualTo(true);
        }
    }
}