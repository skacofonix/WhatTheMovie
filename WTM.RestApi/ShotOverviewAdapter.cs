﻿using WTM.Crawler.Domain;
using WTM.Domain;

namespace WTM.RestApi
{
    internal class ShotOverviewAdapter : IShotOverview
    {
        private ShotSummary shotSummary;

        public ShotOverviewAdapter(ShotSummary shotSummary)
        {
            this.shotSummary = shotSummary;
        }

        public int Id
        {
            get
            {
                return this.shotSummary.ShotId;
            }
        }
    }
}