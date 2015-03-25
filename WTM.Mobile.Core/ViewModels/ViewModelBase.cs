using System;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace WTM.Mobile.Core.ViewModels
{
    public abstract class ViewModelBase : MvxViewModel
    {
        public bool Busy
        {
            get { return busy; }
            protected set
            {
                busy = value;
                RaisePropertyChanged(() => Busy);
            }
        }
        private bool busy;

        protected virtual void ExecuteSyncAction(Action action)
        {
            InvokeOnMainThread(() => Busy = true);
            Task.Run(action).ContinueWith(task => InvokeOnMainThread(() => Busy = false));
        }
    }
}