namespace WTM.RestApi.Models
{
    public interface IAuthenticated
    {
        IUserSummary User { get; }
    }
}