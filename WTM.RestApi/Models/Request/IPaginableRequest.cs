namespace WTM.RestApi.Models.Request
{
    public interface IPaginableRequest
    {
        int? Start { get; }

        int? Limit { get; }
    }
}