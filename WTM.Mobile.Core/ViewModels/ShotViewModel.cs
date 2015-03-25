using System;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Mobile.Core.ViewModels.Parameters;

namespace WTM.Mobile.Core.ViewModels
{
    public class ShotViewModel : ViewModelBase
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
            InvokeOnMainThread(() =>
            {
                Response = null;
                GuessTitle = null;
            });
        }

        public Shot Shot
        {
            get { return shot; }
            set
            {
                shot = value;
                RaiseAllPropertiesChanged();
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

        protected override void ExecuteSyncAction(Action action)
        {
            var actionWithReset = new Action(() =>
            {
                Reset();
                action();
            });

            base.ExecuteSyncAction(actionWithReset);
        }

        #region NavigateToFirstShotCommand

        public ICommand NavigateToFirstShotCommand
        {
            get
            {
                if (navigateToFirstShotCommand == null)
                {
                    navigateToFirstShotCommand = new MvxCommand(() =>
                    {
                        ExecuteSyncAction(() => Shot = shotService.GetById(Shot.Navigation.FirstId.Value));
                    }, () =>
                    {
                        return Shot != null
                                && Shot.Navigation != null
                                && Shot.Navigation.FirstId.HasValue
                                && Shot.Navigation.FirstId.Value != Shot.ShotId;
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
                        ExecuteSyncAction(() =>
                        {
                            // ToDo : Choose between previous and unsolved previous
                            Shot = shotService.GetById(Shot.Navigation.PreviousId.Value);
                        });
                    }, () =>
                    {
                        return Shot != null
                               && Shot.Navigation != null
                               && Shot.Navigation.PreviousId.HasValue
                               && Shot.Navigation.PreviousId.Value != Shot.ShotId;
                    });
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
                    navigateToRandomShotCommand = new MvxCommand(() => ExecuteSyncAction(() => Shot = shotService.GetRandomShot()));
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
                        ExecuteSyncAction(() =>
                        {
                            // ToDo : Choose between next and unsolved next previous
                            Shot = shotService.GetById(Shot.Navigation.NextId.Value);
                        });
                    }, () =>
                    {
                        return Shot != null
                                && Shot.Navigation != null
                                && Shot.Navigation.NextId.HasValue
                                && Shot.Navigation.NextId.Value != Shot.ShotId;
                    });
                }
                return navigateToNextShotCommand;
            }
        }
        private MvxCommand navigateToNextShotCommand;

        #endregion

        #region NavigateToLastShotCommand

        public ICommand NavigateToLastShotCommand
        {
            get
            {
                if (navigateToLastShotCommand == null)
                {
                    navigateToLastShotCommand = new MvxCommand(() =>
                    {
                        ExecuteSyncAction(() => Shot = shotService.GetById(Shot.Navigation.LastId.Value));
                    }, () =>
                    {
                        return Shot != null
                                 && Shot.Navigation != null
                                 && Shot.Navigation.LastId.HasValue
                                 && Shot.Navigation.LastId.Value != Shot.ShotId;
                    });
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
                        InvokeOnMainThread(() => Busy = true);

                        Task.Run(() =>
                        {
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
                                InvokeOnMainThread(() => Busy = false);
                            }
                        });

                    }, () =>
                    {
                        return Shot != null;
                    });
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
                        InvokeOnMainThread(() => Busy = true);

                        Task.Run(() =>
                        {
                            try
                            {
                                Response = shotService.GetSolution(Shot.ShotId);
                            }
                            finally
                            {
                                InvokeOnMainThread(() => Busy = false);
                            }
                        });
                    }, () =>
                    {
                        return Shot != null
                               && Shot.IsSolutionAvailable.GetValueOrDefault(false);
                    });
                }
                return getSolutionCommand;
            }
        }
        private MvxCommand getSolutionCommand;

        #endregion

        #region ShowMovieDetailCommand

        public ICommand ShowMovieDetailCommand
        {
            get
            {
                if (showMovieDetailCommand == null)
                {
                    showMovieDetailCommand = new MvxCommand(() =>
                    {
                        ShowViewModel<MovieViewModel>(new MovieParameters { MovieId = Response.MovieId });
                    });
                }
                return showMovieDetailCommand;
            }
        }
        private MvxCommand showMovieDetailCommand;

        #endregion
    }
}