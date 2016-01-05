namespace WTM.RestApi.Models
{
    public interface IPaginable
    {
        int? Start { get; }

        int? Limit { get; }
    } 
}