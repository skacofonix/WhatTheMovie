using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using WTM.Core.Services;
using WTM.Domain.Interfaces;

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

        public IShot Shot
        {
            get { return shot; }
            set
            {
                shot = value;
                RaisePropertyChanged(() => Shot);
            }
        }
        private IShot shot;

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
                    });
                }
                return randomShotCommand;
            }
        }
        private MvxCommand randomShotCommand;

        #endregion
    }
}
