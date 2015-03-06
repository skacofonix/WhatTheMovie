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

        #region RandomShotCommand

        public ICommand RandomShotCommand
        {
            get
            {
                if (randomShotCommand == null)
                {
                    randomShotCommand = new MvxCommand(() =>
                    {
                        Shot = shotService.GetRandomShot();
                        Response = null;
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
                if (guessTitle == null)
                {
                    guessTitle = new MvxCommand<string>(title =>
                    {
                        Response = shotService.GuessTitle(shot.ShotId, title);
                    }, title =>
                    {
                        return Shot != null;
                    });
                }
                return guessTitle;
            }
        }
        private MvxCommand<string> guessTitle;

        #endregion

        #region GetSolution

        public ICommand GetSolution
        {
            get
            {
                if (getSolution == null)
                {
                    getSolution = new MvxCommand(() =>
                    {
                        Response = shotService.GetSolution(Shot.ShotId);
                    }, () =>
                    {
                        return Shot != null;
                    });
                }
                return getSolution;
            }
        }
        private MvxCommand getSolution;

        #endregion
    }
}