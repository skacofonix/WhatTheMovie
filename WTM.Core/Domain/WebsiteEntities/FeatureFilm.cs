using System;
using System.Collections.Generic;
using WTM.Core.Application.Attributes;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class FeatureFilm : IWebsiteEntityBase
    {
        public DateTime? DateTime { get; set; }

        [StringParser(@"//a[@id='first_shot_link']/@href", @"/shot/(\d*)")]
        public IList<OverviewShot> Shots { get; set; }
    }
}
