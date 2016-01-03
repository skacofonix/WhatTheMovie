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

        public IList<UserSummary> UserSummaries => this.searchResultCollection.Items.Cast<UserSummary>().ToList();
        public int Count => this.searchResultCollection.Count;
        public Range RangeItem => this.searchResultCollection.RangeItem;
    }
}