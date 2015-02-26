using WTM.Domain.Interfaces;

namespace WTM.WebsiteClient.Services
{
    internal class ShotArchiveService : ShotOverviewService
    {
        public ShotArchiveService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public IShotSummaryCollection GetArchiveOneMonthOld()
        {
            return OverviewShotParser.ParseArchiveOneMonthOld();
        }
    }
}   