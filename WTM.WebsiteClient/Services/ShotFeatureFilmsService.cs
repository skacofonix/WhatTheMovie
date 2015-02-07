using System;
using WTM.Domain;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Services
{
    internal class ShotFeatureFilmsService : ShotService
    {
        public ShotFeatureFilmsService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        {
            shotParser = new ShotParser(webClient, htmlParser);
            overviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        private readonly ShotParser shotParser;
        private readonly OverviewShotParser overviewShotParser;

        public ShotSummaryCollection GetTodayShots()
        {
            return overviewShotParser.ParseFeatureFilmsToday();
        }

        public ShotSummaryCollection GetShotyByDate(DateTime date)
        {
            return overviewShotParser.ParseByDate(date);
        }
    }
}