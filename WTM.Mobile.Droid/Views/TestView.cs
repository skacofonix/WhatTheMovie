using Android.App;
using Android.OS;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "Test")]
    public class TestView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TestView);
        }
    }
}