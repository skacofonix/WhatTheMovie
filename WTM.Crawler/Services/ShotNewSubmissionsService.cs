using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class ShotNewSubmissionsService : ShotService
    {
        public ShotNewSubmissionsService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        {
            overviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        private readonly OverviewShotParser overviewShotParser;

        public ShotSummaryCollection GetShots()
        {
            return overviewShotParser.ParseNewSubmission();
        }
    }
}