using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Services
{
    internal class ShotNewSubmissionsService : ShotService
    {
        protected override string PageIdentifier { get { return "newsubmissions"; } }

        public ShotNewSubmissionsService(IWebClient webClient, IHtmlParser htmlParser) : base(webClient, htmlParser)
        {
            overviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        private readonly OverviewShotParser overviewShotParser;

        public OverviewShotCollection GetShots()
        {
            return overviewShotParser.ParseNewSubmission();
        }
    }
}