using Cirrious.MvvmCross.ViewModels;
using System;
using System.Windows.Input;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.ViewModels
{
    public abstract class ShotOverviewViewModel : ViewModelBase
    {
        protected readonly IShotOverviewService ShotOverviewService;

        protected ShotOverviewViewModel(IContext context, IShotOverviewService shotOverviewService)
            : base(context)
        {
            this.ShotOverviewService = shotOverviewService;
        }

        public DateTime Date
        {
            get { return date; }
            protected set
            {
                date = value; 
                RaisePropertyChanged(() => Date);
            }
        }
        private DateTime date;

        public ShotSummaryCollection ShotSummaryCollection
        {
            get { return shotSummaryCollection; }
            set
            {
                shotSummaryCollection = value;
                RaiseAllPropertiesChanged();
            }
        }
        private ShotSummaryCollection shotSummaryCollection;

        public void Init(DateTime? date = null)
        {
            InitializeDate(date);
        }

        protected virtual void InitializeDate(DateTime? date = null)
        {
             Date = date ?? DateTime.Now.Date;
             ChangeDate();
        }

        private void ChangeDate()
        {
            ExecuteSyncAction(() =>
            {
                ShotSummaryCollection = ShotOverviewService.GetShotSummaryByDate(Date);
            });
        }

        #region ChangeDateCommand

        private MvxCommand changeDateCommand;

        public ICommand ChangeDateCommand
        {
            get
            {
                if (changeDateCommand == null)
                {
                    changeDateCommand = new MvxCommand(ChangeDate);
                }
                return changeDateCommand;
            }
        }

        #endregion

        #region OpenDatePickerCommand

        private MvxCommand openDatePickerCommand;

        public ICommand OpenDatePickerCommand
        {
            get
            {
                if (openDatePickerCommand == null)
                {
                    openDatePickerCommand = new MvxCommand(() =>
                    {
                        // ToDo
                    });
                }
                return openDatePickerCommand;
            }
        }

        #endregion

        #region NavigateToPreviousDateCommand

        private MvxCommand navigateToPreviousDateCommand;

        public ICommand NavigateToPreviousDateCommand
        {
            get
            {
                if (navigateToPreviousDateCommand == null)
                {
                    navigateToPreviousDateCommand = new MvxCommand(() =>
                    {
                        Date = Date.AddDays(-1);
                        ChangeDate();
                    }, CanExecuteNavitageToPreviousDate);
                }
                return navigateToPreviousDateCommand;
            }
        }

        protected virtual bool CanExecuteNavitageToPreviousDate()
        {
            return true;
        }

        #endregion

        #region NavigateToNextDateCommand

        private MvxCommand navigateToNextDateCommand;

        public ICommand NavigateToNextDateCommand
        {
            get
            {
                if (navigateToNextDateCommand == null)
                {
                    navigateToNextDateCommand = new MvxCommand(() =>
                    {
                        Date = Date.AddDays(1);
                        ChangeDate();
                    }, CanExecuteToNextDate);
                }
                return navigateToNextDateCommand;
            }
        }

        protected virtual bool CanExecuteToNextDate()
        {
            return Date.AddDays(1) <= DateTime.Now.Date;
        }

        #endregion

        #region NavigateToShotCommand

        private MvxCommand<ShotSummary> navigateToShotCommand;

        public ICommand NavigateToShotCommand
        {
            get
            {
                if (navigateToShotCommand == null)
                {
                    navigateToShotCommand = new MvxCommand<ShotSummary>(shotSummary => ShowViewModel<ShotViewModel>(new { shotId = shotSummary.ShotId }));
                }
                return navigateToShotCommand;
            }
        }

        #endregion
    }
}