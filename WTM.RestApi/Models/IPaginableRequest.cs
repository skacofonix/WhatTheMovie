namespace WTM.RestApi.Models
{
    public interface IPaginableRequest
    {
        int? Start { get; }

        int? Limit { get; }
    } 
}