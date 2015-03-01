using WTM.Crawler.Parsers;
using WTM.Domain;

namespace WTM.Crawler.Services
{
    internal class ShotNewSubmissionsService : ShotService
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