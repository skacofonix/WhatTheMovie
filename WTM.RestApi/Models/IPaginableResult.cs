namespace WTM.RestApi.Models
{
    public interface IPaginableResult
    {
        int TotalCount { get; }
        int DisplayCount { get; }
        IRange DisplayRange { get; }
    }
}