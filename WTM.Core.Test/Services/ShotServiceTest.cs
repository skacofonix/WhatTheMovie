using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Services;

namespace WTM.Core.Test.Services
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
            shotService = new ShotService(webClient, htmlParser);
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
    }
}
