namespace WTM.Api.Models
{
    public interface IPaginableResult
    {
        int TotalCount { get; }
        int DisplayCount { get; }
        int DisplayMin { get; }
        int DisplayMax { get; }
    }
}