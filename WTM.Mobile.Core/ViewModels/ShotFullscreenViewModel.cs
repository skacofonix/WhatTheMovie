using System;

namespace WTM.Mobile.Core.ViewModels
{
    public class ShotFullscreenViewModel : ViewModelBase
    {
        private Uri uri;

        public ShotFullscreenViewModel(IContext context)
            : base(context)
        { }

        public Uri Uri
        {
            get { return uri; }
            set
            {
                uri = value; 
                RaisePropertyChanged(() => Uri);
            }
        }

        public void Init(string uri)
        {
            Uri = new Uri(uri);
        }
    }
}