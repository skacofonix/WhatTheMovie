using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using WTM.Domain;

namespace WTM.Mobile.Core.ViewModels
{
    public class ShotSummaryViewModel : ViewModelBase
    {
        public ShotSummary ShotSummary { get; private set; }

        public ShotSummaryViewModel(IContext context)
            : base(context)
        { }

        public void Init(ShotSummary shotSummary)
        {
            ShotSummary = shotSummary;
        }

        #region NavigateToShotCommand

        private MvxCommand<ShotSummary> navigateToShotCommand;

        public ICommand NavigateToShotCommand
        {
            get
            {
                if (navigateToShotCommand == null)
                {
                    navigateToShotCommand = new MvxCommand<ShotSummary>(shotSummary =>
                    {
                        ShowViewModel<ShotViewModel>(new { shotId = shotSummary.ShotId });
                    });
                }
                return navigateToShotCommand;
            }
        }

        #endregion
    }
}
