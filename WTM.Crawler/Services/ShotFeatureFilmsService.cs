using WTM.Domain.Interfaces;

namespace WTM.Crawler.Services
{
    internal class ShotFeatureFilmsService : ShotOverviewService
    {
        public ShotFeatureFilmsService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public IShotSummaryCollection GetShotSummaryToday()
        {
            return OverviewShotParser.ParseFeatureFilmsToday();
        }
    }
}