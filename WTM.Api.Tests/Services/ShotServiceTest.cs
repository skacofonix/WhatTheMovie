using Moq;
using NFluent;
using NUnit.Framework;
using WTM.Api.Models;
using WTM.Api.Services;

namespace WTM.Api.Tests.Services
{
    [TestFixture]
    public class ShotServiceTest
    {
        [Test]
        public void ShouldGetShotById()
        {
            var shotCrawler = new Mock<WTM.Crawler.Services.IShotService>();
            var shotService = new ShotService(shotCrawler.Object);

            var shotResponse = shotService.GetById(10, new ShotRequest());

            Check.That(shotResponse).IsNotNull();
        }

        [Test]
        public void ShouldGetRandomShot()
        {
            var shotCrawler = new Mock<WTM.Crawler.Services.IShotService>();
            var shotService = new ShotService(shotCrawler.Object);

            var shotResponse = shotService.GetRandom(new ShotRandomRequest());

            Check.That(shotResponse).IsNotNull();
        }

        [Test]
        public void ShouldGuessSolution()
        {
            var shotCrawler = new Mock<WTM.Crawler.Services.IShotService>();
            var shotService = new ShotService(shotCrawler.Object);

            var shotGuessSolutionResponse = shotService.GuessTitle(10, new GuessSolutionRequest {Title = "Eternal Sunchine and the spotless mind"});

            Check.That(shotGuessSolutionResponse).IsNotNull();
        }

        [Test]
        public void ShouldGetSolution()
        {
            var shotCrawler = new Mock<WTM.Crawler.Services.IShotService>();
            var shotService = new ShotService(shotCrawler.Object);

            var shotSolutionResponse = shotService.GetSolution(10, new ShotSolutionRequest());

            Check.That(shotSolutionResponse).IsNotNull();
        }
    }
}