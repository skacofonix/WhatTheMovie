using System.ComponentModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
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

        public void Init()
        {
            RandomShotCommand.Execute(null);
        }

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

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
                RaisePropertyChanged(() => ImageUrl);
            }
        }
        private string imageUrl;

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

        public string GuessTitle
        {
            get { return guessTitle1; }
            set
            {
                guessTitle1 = value;
                RaisePropertyChanged(() => GuessTitle);
            }
        }
        private string guessTitle1;

        private void Reset()
        {
            Shot = null;
            ImageUrl = null;
            Response = null;
            GuessTitle = null;
        }

        #region RandomShotCommand

        public ICommand RandomShotCommand
        {
            get
            {
                if (randomShotCommand == null)
                {
                    randomShotCommand = new MvxCommand(() =>
                    {
                        Busy = true;

                        try
                        {
                            Reset();

                            Shot = shotService.GetRandomShot();
                            ImageUrl = Shot.ImageUri.ToString();
                        }
                        finally
                        {
                            Busy = false;
                        }
                    });
                }
                return randomShotCommand;
            }
        }
        private MvxCommand randomShotCommand;

        #endregion

        #region GuessTitle

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
                                Response = shotService.GuessTitle(shot.ShotId, GuessTitle);
                            else
                                Response = null;

                            if (Response != null)
                                GuessTitle = Response.OriginalTitle;
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

        #region GetSolution

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
                            GuessTitle = Response != null ? Response.OriginalTitle : null;
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