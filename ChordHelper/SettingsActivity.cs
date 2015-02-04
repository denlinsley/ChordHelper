using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ChordHelper
{
    [Activity(Label = "Settings", Icon = "@drawable/chord", ParentActivity = typeof(MainActivity))]			
    public class SettingsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // NOTE: preferences don't need an axml layout so we don't need to call SetContentView

            FragmentManager.BeginTransaction()
                .Replace(Android.Resource.Id.Content, new SettingsFragment())
                .Commit();

            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}

