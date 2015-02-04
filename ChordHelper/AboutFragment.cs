
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace ChordHelper
{
    public class AboutFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FragmentAbout, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            var aboutTextView = this.Activity.FindViewById<TextView>(Resource.Id.aboutTextView);
            aboutTextView.Text = "Chord Trainer version 1.1\n\n" +
            "Written by Dennis Linsley, December 2014\n\n" +
            "denlinsley@gmail.com\n\n" +
            "A web version of the Chord Trainer also exists. Click the button below to visit my website.";

            // from Xamarin recipe http://developer.xamarin.com/recipes/android/fundamentals/intent/open_a_webpage_in_the_browser_application/
            var button = this.Activity.FindViewById<Button>(Resource.Id.theoryTrainerButton);
            button.Click += (object sender, EventArgs e) =>
            {
                var uri = Android.Net.Uri.Parse("http://theorytrainer.azurewebsites.net");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };

        }
    }
}

