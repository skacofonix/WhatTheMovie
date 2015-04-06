using System;
using WTM.Core.Services;

namespace WTM.Mobile.Core.ViewModels
{
    public class ShotFeatureFilmsViewModel : ShotOverviewViewModel
    {
        public ShotFeatureFilmsViewModel(IContext context, IShotOverviewService shotOverviewService)
            : base(context, shotOverviewService)
        {}

        protected override bool CanExecuteNavitageToPreviousDate()
        {
            return Date.AddDays(-1) >= DateTime.Now.Date.AddDays(-30);
        }
    }
}