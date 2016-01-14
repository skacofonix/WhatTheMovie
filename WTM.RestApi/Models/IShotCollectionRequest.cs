namespace WTM.RestApi.Models
{
    public interface IShotCollectionRequest
    {
        int? Start { get; set; }
        int? Limit { get; set; }
        string Token { get; set; }
    }
}