using Android.App;
using Android.OS;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "Menu")]
    public class MenuView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MenuView);
        }
    }
}