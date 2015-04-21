using System;

namespace WTM.Mobile.Core.ViewModels
{
    public class ShotFullscreenViewModel : ViewModelBase
    {
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
        private Uri uri;

        public void Init(string uri)
        {
            Uri = new Uri(uri);
        }
    }
}