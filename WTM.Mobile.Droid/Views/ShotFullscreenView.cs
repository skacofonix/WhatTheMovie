using Android.App;
using Android.OS;
using Android.Views;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "Shot")]
    public class ShotFullscreenView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.ShotFullscreenView);

        }
    }
}