using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public class UserResponse : IUserResponse
    {
        public UserResponse(User user)
        {
            this.User = user;
        }

        public User User { get; }
    }
}