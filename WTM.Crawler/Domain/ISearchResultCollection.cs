namespace WTM.Crawler.Domain
{
    public interface ISearchResultCollection
    {
        int Count { get; }
        Range RangeItem { get;  }
    }
}