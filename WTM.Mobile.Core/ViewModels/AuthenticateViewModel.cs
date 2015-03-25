﻿using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using WTM.Core.Services;

namespace WTM.Mobile.Core.ViewModels
{
    public class AuthenticateViewModel : ViewModelBase
    {
        private readonly IUserService userService;

        public AuthenticateViewModel(IContext context, IUserService userService)
            : base(context)
        {
            this.userService = userService;
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
                        Context.CurrentUser = userService.Login(Username, Password);

                        if (Context.CurrentUser == null)
                        {
                            Password = null;
                        }
                        else
                        {
                            Close(this);
                        }
                    }), () => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password));
                }
                return authenticateCommand;
            }
        }
        private MvxCommand authenticateCommand;

        #endregion
    }
}