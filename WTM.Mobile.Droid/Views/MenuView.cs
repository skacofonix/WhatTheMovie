using Android.App;
using Android.OS;
using Android.Views;

namespace WTM.Mobile.Droid.Views
{
    [Activity]
    public class MenuView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.MenuView);                                                                                           
        }
    }
}