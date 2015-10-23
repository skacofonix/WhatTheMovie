namespace WTM.RestApi.Models.Request
{
    public class GetSolutionRequest : IAuthenticableRequest
    {
        public string Token { get; set; }
    }
}