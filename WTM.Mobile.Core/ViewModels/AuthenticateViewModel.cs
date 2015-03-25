using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using WTM.Crawler.Services;

namespace WTM.Mobile.Core.ViewModels
{
    public class AuthenticateViewModel : ViewModelBase
    {
        private readonly IAuthenticateService authenticateService;

        public AuthenticateViewModel(IContext context, IAuthenticateService authenticateService)
            : base(context)
        {
            this.authenticateService = authenticateService;
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged(() => Username);
                authenticateCommand.RaiseCanExecuteChanged();
            }
        }
        private string username;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
                authenticateCommand.RaiseCanExecuteChanged();
            }
        }
        private string password;

        #region AuthenticateCommand

        public ICommand AuthenticateCommand
        {
            get
            {
                if (authenticateCommand == null)
                {
                    authenticateCommand = new MvxCommand(() => this.ExecuteSyncAction(() =>
                    {
                        var token = authenticateService.Login(Username, Password);
                        if (token == null)
                        {
                            // Wrong password
                            Password = null;
                            Context.UserToken = null;
                            Context.UserName = null;
                        }
                        else
                        {
                            // Right password
                            // Navigate to other view
                            Context.UserToken = token;
                            Context.UserName = Username;
                            Close(this);
                        }
                    }), () =>
                    {
                        return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
                    });
                }
                return authenticateCommand;
            }
        }
        private MvxCommand authenticateCommand;

        #endregion
    }
}