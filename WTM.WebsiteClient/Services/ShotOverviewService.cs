﻿using System;
using WTM.Core.Services;
using WTM.Domain.Interfaces;
using WTM.WebsiteClient.Parsers;

namespace WTM.WebsiteClient.Services
{
    public abstract class ShotOverviewService : ShotService, IShotOverview
    {
        protected ShotOverviewService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        {
            shotParser = new ShotParser(webClient, htmlParser);
            OverviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        private readonly ShotParser shotParser;
        protected readonly OverviewShotParser OverviewShotParser;

        public IShotSummaryCollection GetShotSummaryByDate(DateTime date)
        {
            return OverviewShotParser.ParseByDate(date);
        }
    }
}