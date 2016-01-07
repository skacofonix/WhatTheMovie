using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public interface IUserResponse : IResponse
    {
        User User { get; }
    }
}