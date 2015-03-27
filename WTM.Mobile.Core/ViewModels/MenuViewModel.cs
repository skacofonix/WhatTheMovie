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
                    navigateToFeatureFilmsCommand = new MvxCommand(() => ShowViewModel<FeatureFilmsViewModel>());
                }
                return navigateToFeatureFilmsCommand;
            }
        }
        private ICommand navigateToFeatureFilmsCommand;

        #endregion

        #region NavigateToShotCommand

        public ICommand NavigateToShotCommand
        {
            get
            {
                if (navigateToShotCommand == null)
                {
                    navigateToShotCommand = new MvxCommand(() => ShowViewModel<ShotViewModel>());
                }
                return navigateToShotCommand;
            }
        }
        private ICommand navigateToShotCommand;

        #endregion

        #region NavigateToMovieCommand

        public ICommand NavigateToMovieCommand
        {
            get
            {
                if (navigateToMovieCommand == null)
                {
                    navigateToMovieCommand = new MvxCommand(() => ShowViewModel<MovieViewModel>());
                }
                return navigateToMovieCommand;
            }
        }
        private ICommand navigateToMovieCommand;

        #endregion

        #region NavigateToMovieCommand

        public ICommand NavigateToUserCommand
        {
            get
            {
                if (navigateToUserCommand == null)
                {
                    navigateToUserCommand = new MvxCommand(() => ShowViewModel<UserViewModel>());
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
    }
}