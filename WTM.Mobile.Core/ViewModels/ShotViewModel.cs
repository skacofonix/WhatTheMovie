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
                            Shot = null;
                            Response = null;

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
                            Response = shotService.GuessTitle(shot.ShotId, GuessTitle);
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
        private bool busy;

        #endregion
    }
}