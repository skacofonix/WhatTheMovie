namespace WTM.Domain.Request
{
    public class GetSolutionRequest : IAuthenticableRequest
    {
        public string Token { get; set; }
    }
}