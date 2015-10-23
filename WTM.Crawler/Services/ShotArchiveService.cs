using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public class ShotArchiveService : ShotOverviewService
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