namespace WTM.RestApi.Models
{
    public interface IPaginableResult
    {
        int DisplayCount { get; }
        int TotalCount { get; }
        IRange Range { get; }
    }
}