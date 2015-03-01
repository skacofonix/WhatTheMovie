using System;
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
            var settings = new Settings();
            //settings.Host = new UriBuilder("http", "localhost", 56369, "api/").Uri;
            settings.Host = new UriBuilder("https", "wtmapi.azurewebsites.net", 443, "api/").Uri;
            shotService = new ShotService(settings);
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
            var shot = shotService.GetShotById(10);
            Check.That(shot).IsNotNull();
        }

        [Test]
        public void WhenGuessRightTitleThenReturnGuessTitleResponse()
        {
            var guessTitleResponse = shotService.GuessTitle(10, "Eternal Sunshine of the spotless mind");
            Check.That(guessTitleResponse).IsNotNull();
            Check.That(guessTitleResponse.RightGuess).IsNotNull().And.IsEqualTo(true);
        }
    }
}