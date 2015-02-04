
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
    [Activity(Label = "About Chord Helper", Icon = "@drawable/chord", ParentActivity = typeof(MainActivity))]			
    public class AboutActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FragmentManager.BeginTransaction()
                .Replace(Android.Resource.Id.Content, new AboutFragment())
                .Commit();

            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}

