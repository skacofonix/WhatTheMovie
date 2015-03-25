using System;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;

namespace WTM.Mobile.Core.ViewModels
{
    public abstract class ViewModelBase : MvxViewModel
    {
        public IContext Context
        {
            get { return context; }
            protected set
            {
                context = value;
                RaisePropertyChanged(() => Context);
            }
        }
        private IContext context;

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

        public ViewModelBase(IContext context)
        {
            Context = context;
        }

        protected virtual void ExecuteSyncAction(Action action)
        {
            InvokeOnMainThread(() => Busy = true);
            Task.Run(action).ContinueWith(task => InvokeOnMainThread(() => Busy = false));
        }
    }
}