using System.Collections.Generic;
using System.Linq;

namespace WTM.Crawler.Domain
{
    public class ShotSearchResult : ISearchResultCollection
    {
        private readonly SearchResultCollection searchResultCollection;

        public ShotSearchResult(SearchResultCollection searchResultCollection)
        {
            this.searchResultCollection = searchResultCollection;
        }

        public IList<ShotSummary> ShotSummaries => searchResultCollection.Items.Cast<ShotSummary>().ToList();
        public int Count => searchResultCollection.Count;
        public Range RangeItem => searchResultCollection.RangeItem;
    }
}