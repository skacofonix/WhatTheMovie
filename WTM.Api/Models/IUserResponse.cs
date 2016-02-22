using WTM.Crawler.Domain;

namespace WTM.Api.Models
{
    public interface IUserResponse : IResponse
    {
        User User { get; }
    }
}