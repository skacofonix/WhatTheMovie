using System;
using System.Collections;

namespace WTM.WebsiteClient.Domain
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