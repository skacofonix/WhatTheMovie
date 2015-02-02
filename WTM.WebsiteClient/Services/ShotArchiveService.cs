using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Services
{
    internal class ShotArchiveService : ShotService
    {
        protected override string PageIdentifier { get { return "overview"; } }

        public ShotArchiveService(IWebClient webClient, IHtmlParser htmlParser) : base(webClient, htmlParser)
        {
            overviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        private readonly OverviewShotParser overviewShotParser;

        public OverviewShotCollection GetArhciveOneMonthOld()
        {
            return overviewShotParser.ParseArchiveOneMonthOld();
        }
    }
}
