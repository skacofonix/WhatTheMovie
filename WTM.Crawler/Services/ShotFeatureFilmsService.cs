using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Crawler.Services
{
    internal class ShotFeatureFilmsService : ShotOverviewService
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