using WTM.Domain;

namespace WTM.Crawler.Services
{
    internal class ShotArchiveService : ShotOverviewService
    {
        public ShotArchiveService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public ShotSummaryCollection GetArchiveOneMonthOld()
        {
            return OverviewShotParser.ParseArchiveOneMonthOld();
        }
    }
}   