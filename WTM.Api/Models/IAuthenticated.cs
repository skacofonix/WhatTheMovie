namespace WTM.Api.Models
{
    public interface IAuthenticated
    {
        IUserSummary User { get; }
    }
}