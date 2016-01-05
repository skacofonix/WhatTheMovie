namespace WTM.RestApi.Models
{
    public interface ISearchResult
    {
        int TotalCount { get; }

        IRange Range { get; }
    }
}