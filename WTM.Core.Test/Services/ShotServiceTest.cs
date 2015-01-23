using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
{
    [TestFixture]
    public class ShotServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotService shotService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            shotService = new ShotArchiveService(webClient, htmlParser);
        }

        [Test]
        public void WhenGuessRightTitleThenReturnTrue()
        {
            var response = shotService.GuessTitle(10, "Eternal sunshine of the splotless mind");
            Check.That(response).IsNotNull();
            Check.That(response.Guess).IsNotNull();
            Check.That(response.MovieId).IsNotNull();
            Check.That(response.OriginalTitle).IsNotNull();
            Check.That(response.Year).IsNotNull();
        }

        [Test]
        public void WhenGuessWrongTitleThenReturnFalse()
        {
            var response = shotService.GuessTitle(10, "Truman show");
            Check.That(response).IsNull();
        }

        [Test]
        public void WhenShowSolutionThenReceiveSolution()
        {
            var response = shotService.ShowSolution(10);
            Check.That(response).IsNotNull();
            Check.That(response.OriginalTitle).IsNotNull();
            Check.That(response.Year).IsNotNull();
            Check.That(response.MovieLink).IsNotNull();
        }

        [Test]
        public void WhenRandomizeShotThenReturnValidEntity()
        {
            var shot = shotService.GetRandomShot();

            Check.That(shot).IsNotNull();
            Check.That(shot.ShotId).IsNotNull();
        }

        [Test]
        public void WhenParseSpecificIdThenReturnShot()
        {
            const int expectedShotId = 10;

            var shot = shotService.GetShotById(expectedShotId);

            Check.That(shot).IsNotNull();
            Check.That(shot.ShotId).Equals(expectedShotId);
        }

        [Test]
        public void WhenGetFirstShotThenReturnShot()
        {
            var shot = shotService.GetFirstShot();
            Check.That(shot).IsNotNull();
            Check.That(shot.FirstShotId).IsNull();
        }

        [Test]
        public void WhenGetLastShotThenReturnLast()
        {
            var shot = shotService.GetFirstShot();
            Check.That(shot).IsNotNull();
            Check.That(shot.FirstShotId).IsNull();
        }

        [Test]
        public void WhenGetPreviousShotThenReturnPreviousShot()
        {
            var lastShot = shotService.GetLastShot();
            var shot = shotService.GetPreviousShot(lastShot);
            Check.That(shot).IsNotNull();
            Check.That(shot.ShotId < lastShot.ShotId);
        }

        [Test]
        public void WhenGetNextShotThenReturnShot()
        {
            var firstShot = shotService.GetFirstShot();
            var shot = shotService.GetNextShot(firstShot);
            Check.That(shot).IsNotNull();
            Check.That(shot.ShotId > firstShot.ShotId);
        }
    }
}
