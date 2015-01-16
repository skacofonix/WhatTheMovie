using System;
using System.Collections.Generic;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal class ShotFeatureFilmsService : ShotService
    {
        protected override string PageIdentifier { get { return "overview"; } }

        public ShotFeatureFilmsService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        {
            shotParser = new ShotParser(webClient, htmlParser);
            overviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        private readonly ShotParser shotParser;
        private readonly OverviewShotParser overviewShotParser;

        public OverviewShotCollection GetTodayShots()
        {
            return overviewShotParser.ParseFeatureFilmsToday();
        }

        public OverviewShotCollection GetShotyByDate(DateTime date)
        {
            return overviewShotParser.ParseByDate(date);
        }
    }
}
