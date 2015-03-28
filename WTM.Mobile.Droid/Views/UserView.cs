using Android.App;
using Android.OS;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "User")]
    public class UserView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.UserView);
        }
    }
}