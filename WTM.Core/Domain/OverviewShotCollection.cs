using System;
using System.Collections.Generic;
using WTM.Core.Application.Attributes;

namespace WTM.WebsiteClient.Domain
{
    internal class OverviewShotCollection : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        [StringParser(@"//div[@id='hidden_date']")]
        public DateTime? Date { get; set; }

        [StringParser(@"//ul[@id='overview_movie_list']/li/div[@class='box']/div")]
        public IList<OverviewShot> Shots { get; set; }

        public OverviewShotType? OverviewShotType { get; set; }
    }
}
