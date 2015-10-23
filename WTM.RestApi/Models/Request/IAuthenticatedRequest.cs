namespace WTM.RestApi.Models.Request
{
    public interface IAuthenticableRequest
    {
        string Token { get; }
    }
}