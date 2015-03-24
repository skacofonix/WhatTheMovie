using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "Menu")]
    public class MenuView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MenuView);
        }
    }
}