using System;
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
            webClient = new WebClient(new Uri("http://whatthemovie.com"));
            htmlParser = new HtmlParser();
            shotService = new ShotService(webClient, htmlParser);
        }

        [Test]
        public void WhenGuessRightTitleThenReturnTrue()
        {
            var success = shotService.GuessTitle(10, "Eternal sunshine of the splotless mind");
            Check.That(success).IsTrue();
        }

        [Test]
        public void WhenGuessWrongTitleThenReturnFalse()
        {
            var success = shotService.GuessTitle(10, "Truman show");
            Check.That(success).IsFalse();
        }

        [Test]
        public void WhenShowSolutionThenReceiveSolution()
        {
            var success = shotService.ShowSolution(10);
            Check.That(success).IsTrue();
        }
    }
}
