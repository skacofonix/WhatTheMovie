using NFluent;
using NUnit.Framework;
using WTM.Api.Client.Services;
using WTM.Core.Services;

namespace WTM.Api.Client.Test.Services
{
    [TestFixture]
    public class ShotServiceTest
    {
        private IShotService shotService;

        [SetUp]
        public void BeforeTest()
        {
            shotService = new ShotService(new SettingsProxy());
        }

        [Test]
        public void WhenGetRandomShotThenReturnShot()
        {
            var shot = shotService.GetRandomShot();
            Check.That(shot).IsNotNull();
        }

        [Test]
        public void WhenGetShotThenReturnThisShot()
        {
            var shot = shotService.GetById(10);
            Check.That(shot).IsNotNull();
        }

        [Test]
        public void WhenGuessRightTitleThenReturnGuessTitleResponse()
        {
            var guessTitleResponse = shotService.GuessTitle(10, "Eternal Sunshine of the spotless mind");
            Check.That(guessTitleResponse).IsNotNull();
            Check.That(guessTitleResponse.RightGuess).IsNotNull().And.IsEqualTo(true);
        }

        [Test]
        public void WhenGuessWrongTitleThenReturnGuessTitleResponse()
        {
            var guessTitleResponse = shotService.GuessTitle(10, "Nimportenawak");
            Check.That(guessTitleResponse).IsNotNull();
            Check.That(guessTitleResponse.RightGuess).IsNotNull().And.IsEqualTo(false);
        }

        [Test]
        public void WhenDoRateThenReturnNewRateResult()
        {
            var rate = shotService.Rate(10, 5);
            Check.That(rate).IsNotNull();
        }

        [Test]
        public void WhenAskSOlutionThenReturnIt()
        {
            var guessTitleResponse = shotService.GetSolution(10);
            Check.That(guessTitleResponse).IsNotNull();
        }
    }
}