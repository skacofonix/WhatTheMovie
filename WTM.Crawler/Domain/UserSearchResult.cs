using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WTM.Crawler.Domain
{
    public class UserSearchResult : ISearchResultCollection
    {
        private readonly SearchResultCollection searchResultCollection;

        public UserSearchResult(SearchResultCollection searchResultCollection)
        {
            this.searchResultCollection = searchResultCollection;
        }

        public IList<UserSummary> UserSummaries => searchResultCollection.Items.Cast<UserSummary>().ToList();
        public int Count => searchResultCollection.Count;
        public Range RangeItem => searchResultCollection.RangeItem;
    }
}