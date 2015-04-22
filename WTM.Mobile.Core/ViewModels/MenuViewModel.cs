using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace WTM.Mobile.Core.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel(IContext context)
            : base(context)
        { }

        #region NavigateToFeatureFilmsCommand

        public ICommand NavigateToFeatureFilmsCommand
        {
            get
            {
                if (navigateToFeatureFilmsCommand == null)
                {
                    navigateToFeatureFilmsCommand = new MvxCommand(() => ShowViewModel<ShotFeatureFilmsViewModel>());
                }
                return navigateToFeatureFilmsCommand;
            }
        }
        private ICommand navigateToFeatureFilmsCommand;

        #endregion

        #region NavigateToArchiveCommand

        public ICommand NavigateToArchiveCommand
        {
            get
            {
                if (navigateToArchiveCommand == null)
                {
                    navigateToArchiveCommand = new MvxCommand(() => ShowViewModel<ShotArchiveViewModel>());
                }
                return navigateToArchiveCommand;
            }
        }
        private ICommand navigateToArchiveCommand;

        #endregion

        #region NavigateToUserCommand

        public ICommand NavigateToUserCommand
        {
            get
            {
                if (navigateToUserCommand == null)
                {
                    navigateToUserCommand = new MvxCommand(() => ShowViewModel<UserViewModel>(new { username = (Context != null && Context.CurrentUser != null) ? Context.CurrentUser.Name : null }));
                }
                return navigateToUserCommand;
            }
        }
        private ICommand navigateToUserCommand;

        #endregion

        #region NavigateToSettingsCommand

        public ICommand NavigateToSettingsCommand
        {
            get
            {
                if (navigateToSettingsCommand == null)
                {
                    navigateToSettingsCommand = new MvxCommand(() => ShowViewModel<SettingsViewModel>());
                }
                return navigateToSettingsCommand;
            }
        }
        private ICommand navigateToSettingsCommand;

        #endregion

        #region NavigateToAuthenticateCommand

        public ICommand NavigateToAuthenticateCommand
        {
            get
            {
                if (navigateToAuthenticateCommand == null)
                {
                    navigateToAuthenticateCommand = new MvxCommand(() => ShowViewModel<AuthenticateViewModel>());
                }
                return navigateToAuthenticateCommand;
            }
        }
        private ICommand navigateToAuthenticateCommand;

        #endregion

        #region NavigateToAboutCommand

        public ICommand NavigateToAboutCommand
        {
            get
            {
                if (navigateToAboutCommand == null)
                {
                    navigateToAboutCommand = new MvxCommand(() => ShowViewModel<AboutViewModel>());
                }
                return navigateToAboutCommand;
            }
        }
        private ICommand navigateToAboutCommand;

        #endregion

        #region NavigateToTestCommand

        public ICommand NavigateToTestCommand
        {
            get
            {
                if (navigateToTestCommand == null)
                {
                    navigateToTestCommand = new MvxCommand(() => ShowViewModel<TestViewModel>());
                }
                return navigateToTestCommand;
            }
        }
        private ICommand navigateToTestCommand;

        #endregion
    }
}