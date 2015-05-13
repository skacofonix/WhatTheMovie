using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace WTM.Mobile.Droid.Views
{
    [Activity(Label = "Test")]
    public class TestView : BaseView
    {
        private String[] mPlanetTitles;
        private MvxListView listViewLeftDrawer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TestView);

            //Android.Resource.Id.M

          // Android.Resource.Id.List

            //// Set the adapter for the list view
            //listViewLeftDrawer.setAdapter(new ArrayAdapter<String>(this, R.layout.drawer_list_item, mPlanetTitles));
            //// Set the list's click listener
            //listViewLeftDrawer.setOnItemClickListener(new DrawerItemClickListener());



            //mPlanetTitles = GetResources().getStringArray(R.array.planets_array);
            //mDrawerLayout = (DrawerLayout)FindViewById(R.id.drawer_layout);
            //listViewLeftDrawer = (MvxListView)FindViewById(R.id.left_drawer);

            
        }
    }
}