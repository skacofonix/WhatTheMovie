using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public class ShotFeatureFilmsService : ShotOverviewService
    {
        public ShotFeatureFilmsService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public ShotSummaryCollection GetShotSummaryToday()
        {
            return OverviewShotParser.ParseFeatureFilmsToday();
        }
    }
}