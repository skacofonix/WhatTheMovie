namespace WTM.Domain.Request
{
    public interface IAuthenticableRequest
    {
        string Token { get; }
    }
}