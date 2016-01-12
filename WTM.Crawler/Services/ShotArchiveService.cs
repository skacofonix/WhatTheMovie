using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public class ShotArchiveService : ShotOverviewService, IShotArchiveService
    {
        public ShotArchiveService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public ShotSummaryCollection GetArchiveOneMonthOld(string token = null)
        {
            return OverviewShotParser.ParseArchiveOneMonthOld(token);
        }
    }
}   