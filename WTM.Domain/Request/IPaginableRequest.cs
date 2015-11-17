namespace WTM.Domain.Request
{
    public interface IPaginableRequest
    {
        int? Start { get; }

        int? Limit { get; }
    }
}