namespace WTM.RestApi.Models
{
    public class ShotRandomRequest : IRequest, IAuthenticable
    {
        public string Token { get; }
    }
}