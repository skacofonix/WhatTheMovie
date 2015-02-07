using System;
using System.Collections;

namespace WTM.WebsiteClient.Domain
{
    public class SearchResultCollection : ISearchResultCollection
    {
        public DateTime ParseDateTime { get; private set; }
        public TimeSpan ParseDuration { get; private set; }

        public IList Items { get; set; }

        public SearchResultCollection()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}