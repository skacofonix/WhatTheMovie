namespace WTM.RestApi.Models
{
    public interface IPaginableResult
    {
        int TotalCount { get; }

        IRange Range { get; }
    }
}