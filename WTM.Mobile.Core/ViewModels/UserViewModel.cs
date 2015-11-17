using System.Collections.Generic;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.OldSchool;

namespace WTM.Mobile.Core.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly IUserService userService;

        public User User
        {
            get { return user; }
            private set
            {
                user = value; 
                RaisePropertyChanged(() => User);
                RaisePropertyChanged(() => PersonalInformations);
            }
        }
        private User user;

        public string PersonalInformations
        {
            get
            {
                var items = new List<string>();
                if (User.Age.HasValue)
                {
                    items.Add(User.Age.Value.ToString());
                }

                items.Add(User.Gender.ToString());

                if (!string.IsNullOrWhiteSpace(User.Country))
                {
                    items.Add(User.Country);
                }

                return string.Join(", ", items);
            }
        }

        public UserViewModel(IContext context, IUserService userService)
            : base(context)
        {
            this.userService = userService;
        }

        public void Init(string username = null)
        {
            if (Context.CurrentUser != null && Context.CurrentUser.Name == username)
            {
                User = Context.CurrentUser;
            }
            else
            {
                User = GetUserByName(username);
            }
        }

        private User GetUserByName(string name)
        {
            User tempUser = null;

            ExecuteSyncAction(() =>
            {
                tempUser = userService.GetByUsername(name);
            });

            return tempUser;
        }
    }
}