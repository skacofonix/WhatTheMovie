using Cirrious.MvvmCross.ViewModels;
using System;
using System.Windows.Input;

namespace WTM.Mobile.Core.ViewModels
{
    public class AuthenticationViewModel : ViewModelBase
    {
        private readonly IContext context;

        public AuthenticationViewModel(IContext context)
        {
            this.context = context;
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged(() => Username);
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
                    authenticateCommand = new MvxCommand(() =>
                    {
                        // ToDo
                        throw new NotImplementedException();
                    });
                }
                return authenticateCommand;
            }
        }
        private ICommand authenticateCommand;

        #endregion
    }
}