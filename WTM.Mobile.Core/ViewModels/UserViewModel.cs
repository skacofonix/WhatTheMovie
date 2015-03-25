using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly IUserService userService;

        public User User { get; private set; }

        public UserViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public void Init(string userId)
        {
            ExecuteSyncAction(() =>
            {
                User = userService.GetByUsername(userId);
            });
        }
    }
}