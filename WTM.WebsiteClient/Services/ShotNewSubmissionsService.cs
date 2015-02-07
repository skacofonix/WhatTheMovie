using WTM.Domain;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Services
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