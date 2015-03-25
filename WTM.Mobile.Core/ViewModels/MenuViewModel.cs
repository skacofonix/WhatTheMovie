using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace WTM.Mobile.Core.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        #region NavigateToFeatureFilmsCommand

        public ICommand NavigateToFeatureFilmsCommand
        {
            get
            {
                if (navigateToFeatureFilmsCommand == null)
                {
                    navigateToFeatureFilmsCommand = new MvxCommand(() => ShowViewModel<ShotViewModel>());
                }
                return navigateToFeatureFilmsCommand;
            }
        }
        private ICommand navigateToFeatureFilmsCommand;

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
                    navigateToSettingsCommand = new MvxCommand(() => ShowViewModel<MovieViewModel>());
                }
                return navigateToSettingsCommand;
            }
        }
        private ICommand navigateToSettingsCommand;

        #endregion
    }
}