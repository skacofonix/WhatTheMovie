using System;
using System.Collections;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class SearchResultCollection : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        public IList Items { get; set; }

        public SearchResultCollection()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}