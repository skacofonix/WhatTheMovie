using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class ShotNewSubmissionsService : ShotService, IShotNewSubmissionsService
    {
        public ShotNewSubmissionsService(IWebClient webClient, IHtmlParser htmlParser, IImageDownloader imageDownloader, IImageRepository imageRepository)
            : base(webClient, htmlParser)
        {
            overviewShotParser = new OverviewShotParser(webClient, htmlParser, imageDownloader, imageRepository);
        }

        private readonly OverviewShotParser overviewShotParser;

        public ShotSummaryCollection GetShots(string token)
        {
            return overviewShotParser.ParseNewSubmission(token);
        }
    }
}