using WTM.Domain.Interfaces;

namespace WTM.WebsiteClient.Services
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