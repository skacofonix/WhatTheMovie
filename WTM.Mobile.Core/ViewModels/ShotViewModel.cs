using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.ViewModels
{
    public class ShotViewModel : MvxViewModel
    {
        private readonly IShotService shotService;

        public ShotViewModel(IShotService shotService)
        {
            this.shotService = shotService;
        }

        public void Init(Shot shot = null)
        {
            NavigateToRandomShotCommand.Execute(shot);
        }

        private void Reset()
        {
            Response = null;
            GuessTitle = null;
        }

        public Shot Shot
        {
            get { return shot; }
            set
            {
                shot = value;
                RaisePropertyChanged(() => Shot);
            }
        }
        private Shot shot;

        public string GuessTitle
        {
            get { return guessTitle; }
            set
            {
                guessTitle = value;
                RaisePropertyChanged(() => GuessTitle);
            }
        }
        private string guessTitle;

        public GuessTitleResponse Response
        {
            get { return response; }
            set
            {
                response = value;
                RaisePropertyChanged(() => Response);
            }
        }
        private GuessTitleResponse response;

        public bool Busy
        {
            get { return busy; }
            set
            {
                busy = value;
                RaisePropertyChanged(() => Busy);
            }
        }
        private bool busy;

        #region NavigateToFirstShotCommand

        public ICommand NavigateToFirstShotCommand
        {
            get
            {
                if (navigateToFirstShotCommand == null)
                {
                    navigateToFirstShotCommand = new MvxCommand(() =>
                    {
                        Busy = true;

                        try
                        {
                            Reset();
                            Shot = shotService.GetById(Shot.Navigation.FirstId.Value);
                        }
                        finally
                        {
                            Busy = false;
                        }
                    }, () => 
                    {
                        if (Shot != null && Shot.Navigation != null && Shot.Navigation.FirstId.HasValue && Shot.Navigation.FirstId.Value != Shot.ShotId)
                            return true;
                        return false;
                    });
                }
                return navigateToFirstShotCommand;
            }
        }
        private MvxCommand navigateToFirstShotCommand;

        #endregion

        #region NavigateToPreviousShotCommand

        public ICommand NavigateToPreviousShotCommand
        {
            get
            {
                if (navigateToPreviousShotCommand == null)
                {
                    navigateToPreviousShotCommand = new MvxCommand(() =>
                    {
                        Busy = true;

                        try
                        {
                            Reset();
                            // ToDo : Choose between previous and unsolved previous
                            Shot = shotService.GetById(Shot.Navigation.PreviousId.Value);
                        }
                        finally
                        {
                            Busy = false;
                        }
                    }, () => Shot != null && Shot.Navigation != null && Shot.Navigation.PreviousId.HasValue && Shot.Navigation.PreviousId.Value != Shot.ShotId);
                }
                return navigateToPreviousShotCommand;
            }
        }
        private MvxCommand navigateToPreviousShotCommand;

        #endregion

        #region NavigateToRandomShotCommand

        public ICommand NavigateToRandomShotCommand
        {
            get
            {
                if (navigateToRandomShotCommand == null)
                {
                    navigateToRandomShotCommand = new MvxCommand(() =>
                    {
                        Busy = true;

                        try
                        {
                            Reset();
                            Shot = shotService.GetRandomShot();
                        }
                        finally
                        {
                            Busy = false;
                        }
                    });
                }
                return navigateToRandomShotCommand;
            }
        }
        private MvxCommand navigateToRandomShotCommand;

        #endregion

        #region NavigateToNextShotCommand

        public ICommand NavigateToNextShotCommand
        {
            get
            {
                if (navigateToNextShotCommand == null)
                {
                    navigateToNextShotCommand = new MvxCommand(() =>
                    {
                        Busy = true;

                        try
                        {
                            Reset();
                            // ToDo : Choose between next and unsolved next previous
                            Shot = shotService.GetById(Shot.Navigation.NextId.Value);
                        }
                        finally
                        {
                            Busy = false;
                        }
                    }, () => Shot != null && Shot.Navigation != null && Shot.Navigation.NextId.HasValue && Shot.Navigation.NextId.Value != Shot.ShotId);
                }
                return navigateToNextShotCommand;
            }
        }
        private MvxCommand navigateToNextShotCommand;

        #endregion

        #region NavigateToNextShotCommand

        public ICommand NavigateToLastShotCommand
        {
            get
            {
                if (navigateToLastShotCommand == null)
                {
                    navigateToLastShotCommand = new MvxCommand(() =>
                    {
                        Busy = true;
                        try
                        {
                            Reset();
                            Shot = shotService.GetById(Shot.Navigation.LastId.Value);
                        }
                        finally
                        {
                            Busy = false;
                        }
                    }, () => Shot != null && Shot.Navigation != null && Shot.Navigation.LastId.HasValue && Shot.Navigation.LastId.Value != Shot.ShotId);
                }
                return navigateToLastShotCommand;
            }
        }
        private MvxCommand navigateToLastShotCommand;

        #endregion

        #region GuessTitleCommand

        public ICommand GuessTitleCommand
        {
            get
            {
                if (guessTitleCommand == null)
                {
                    guessTitleCommand = new MvxCommand(() =>
                    {
                        Busy = true;

                        try
                        {
                            if (!string.IsNullOrWhiteSpace(GuessTitle))
                            {
                                Response = shotService.GuessTitle(shot.ShotId, GuessTitle);
                            }
                            else
                            {
                                Response = null;
                            }
                        }
                        finally
                        {
                            Busy = false;
                        }
                    }, () => Shot != null);
                }
                return guessTitleCommand;
            }
        }
        private MvxCommand guessTitleCommand;

        #endregion

        #region GetSolutionCommand

        public ICommand GetSolutionCommand
        {
            get
            {
                if (getSolutionCommand == null)
                {
                    getSolutionCommand = new MvxCommand(() =>
                    {
                        Busy = true;

                        try
                        {
                            Response = shotService.GetSolution(Shot.ShotId);
                        }
                        finally
                        {
                            Busy = false;
                        }

                    }, () => Shot != null);
                }
                return getSolutionCommand;
            }
        }
        private MvxCommand getSolutionCommand;

        #endregion
    }
}