using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Preferences;

namespace ChordHelper
{
    [Activity(Label = "Chord Helper", MainLauncher = true, Icon = "@drawable/chord")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Set default values defined in preferences when the Activity starts
            PreferenceManager.SetDefaultValues(this, Resource.Xml.Preferences, false);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            var generatorTab = ActionBar.NewTab();
            generatorTab.SetText("generator");
            generatorTab.TabSelected += (object sender, ActionBar.TabEventArgs e) =>
            {
                e.FragmentTransaction.Replace(Android.Resource.Id.Content, new ChordGeneratorFragment());
            };
            ActionBar.AddTab(generatorTab); // NOTE: this line of code must go after the event handler (throws exception - no callback)


            var trainerTab = ActionBar.NewTab();
            trainerTab.SetText("trainer");
            trainerTab.TabSelected += (object sender, ActionBar.TabEventArgs e) =>
            {
                e.FragmentTransaction.Replace(Android.Resource.Id.Content, new ChordTrainerFragment());
            };
            ActionBar.AddTab(trainerTab);


            // Keep the current tab selected after rotation
            if (bundle != null)
            {
                int currentTab = bundle.GetInt("currentTab");
                if (currentTab == 0)
                    ActionBar.SelectTab(generatorTab);
                else
                    ActionBar.SelectTab(trainerTab);
            }
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_settings:
                    StartActivity(typeof(SettingsActivity));
                    return true;
                case Resource.Id.action_about:
                    StartActivity(typeof(AboutActivity));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }


        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("currentTab", ActionBar.SelectedNavigationIndex);
        }
    }
}


