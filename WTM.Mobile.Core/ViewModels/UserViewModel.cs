using System.Collections.Generic;
using System.Text;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly IUserService userService;

        public User User { get; private set; }

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

        public void Init(string userId = null)
        {
            if (userId == null)
            {
                // Juste fo dev
                User = new User
                {
                    Name = "Skacofonix",
                    About = "Hello everybody, everybody hello. Lorem Ipsum Dolor",
                    Age = 27,
                    Country = "France",
                    FeatureFilmsSolved = 23654,
                    SnapshotSolved = 87656,
                    Gender = Gender.Male,
                    Score = 35679,
                    Level = "Set Decorator"
                };

                return;
            }

            ExecuteSyncAction(() =>
            {
                User = userService.GetByUsername(userId);
            });
        }
    }
}