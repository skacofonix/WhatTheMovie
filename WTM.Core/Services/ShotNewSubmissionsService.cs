using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
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