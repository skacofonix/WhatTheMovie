using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "Shot")]
    public class ShotView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ShotView);
        }
    }
}