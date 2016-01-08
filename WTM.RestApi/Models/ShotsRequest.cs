namespace WTM.RestApi.Models
{
    public class ShotsRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}