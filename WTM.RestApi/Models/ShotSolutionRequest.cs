namespace WTM.RestApi.Models
{
    public class ShotSolutionRequest : IRequest, IAuthenticable
    {
        public string Token { get; set; }
    }
}