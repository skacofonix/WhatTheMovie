namespace WTM.RestApi.Models
{
    public class ShotRequest : IRequest, IAuthenticable
    {
        public string Token { get; set; }
    }
}