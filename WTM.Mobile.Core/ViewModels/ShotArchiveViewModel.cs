using System;
using WTM.Core.Services;

namespace WTM.Mobile.Core.ViewModels
{
    public class ShotArchiveViewModel : ShotOverviewViewModel
    {
        public ShotArchiveViewModel(IContext context, IShotOverviewService shotOverviewService)
            : base(context, shotOverviewService)
        {}

        protected override void InitializeDate(DateTime? date = null)
        {
            var lastArchiveDate = DateTime.Now.Date.AddDays(-31);

            if (date.HasValue && date <= lastArchiveDate)
                Date = date.Value;

            Date = lastArchiveDate;
        }

        protected override bool CanExecuteToNextDate()
        {
            return Date.Date.AddDays(1) <= DateTime.Now.Date.AddDays(-31);
        }
    }
}