using Android.App;
using Android.OS;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "Authenticate")]
    public class AboutView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.About);
        }
    }
}