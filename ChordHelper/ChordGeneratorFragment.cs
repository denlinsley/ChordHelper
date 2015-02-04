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
    public class ChordGeneratorFragment : Fragment
    {
        private string selectedRoot;
        private KeyValuePair<string, string> chordToSpell;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FragmentChordGenerator, container, false);
            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            // Triad libraries
            var majorTriads = new ChordLibrary();
            majorTriads.AddMajorTriads();
            var minorTriads = new ChordLibrary();
            minorTriads.AddMinorTriads();
            var augmentedTriads = new ChordLibrary();
            augmentedTriads.AddAugmentedTriads();
            var diminishedTriads = new ChordLibrary();
            diminishedTriads.AddDiminishedTriads();

            // Seventh libraries
            var majorSevenths = new ChordLibrary();
            majorSevenths.AddMajorSevenths();
            var minorSevenths = new ChordLibrary();
            minorSevenths.AddMinorSevenths();
            var dominantSevenths = new ChordLibrary();
            dominantSevenths.AddDominantSevenths();
            var halfDiminishedSevenths = new ChordLibrary();
            halfDiminishedSevenths.AddHalfDiminishedSevenths();
            var fullyDiminishedSevenths = new ChordLibrary();
            fullyDiminishedSevenths.AddFullyDiminishedSevenths();


            // set up the spinner
            var spinner = this.Activity.FindViewById<Spinner>(Resource.Id.rootSpinner);
            var adapter = ArrayAdapter<String>.CreateFromResource(this.Activity, Resource.Array.roots, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            spinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                spinner = (Spinner)sender;
                selectedRoot = (string)spinner.GetItemAtPosition(e.Position);
            };


            // toggle buttons to show either triads or sevenths radio groups
            var showTriadsButton = this.Activity.FindViewById<Button>(Resource.Id.showTriadsButton);
            var showSeventhsButton = this.Activity.FindViewById<Button>(Resource.Id.showSeventhsButton);
            var triadsRadioGroup = this.Activity.FindViewById<RadioGroup>(Resource.Id.triadsRadioGroup);
            var seventhsRadioGroup = this.Activity.FindViewById<RadioGroup>(Resource.Id.seventhsRadioGroup);


            showTriadsButton.Click += (object sender, EventArgs e) =>
            {
                triadsRadioGroup.Visibility = ViewStates.Visible;
                seventhsRadioGroup.Visibility = ViewStates.Invisible;
            };


            showSeventhsButton.Click += (object sender, EventArgs e) =>
            {
                seventhsRadioGroup.Visibility = ViewStates.Visible;
                triadsRadioGroup.Visibility = ViewStates.Invisible;
            };


            // set up the show spelling button
            var showSpellingButton = this.Activity.FindViewById<Button>(Resource.Id.showSpellingButton);
            var chordNameTextView = this.Activity.FindViewById<TextView>(Resource.Id.chordNameTextView);
            var chordSpellingTextView = this.Activity.FindViewById<TextView>(Resource.Id.chordSpellingTextView);


            showSpellingButton.Click += (object sender, EventArgs e) =>
            {
                // set the chordToSpell based on which radio group is visible (triads/sevenths), and which radio button is checked
                if (triadsRadioGroup.Visibility == ViewStates.Visible)
                {
                    
                    switch (triadsRadioGroup.CheckedRadioButtonId)
                    {
                        case Resource.Id.majorTriadRadioButton:
                            chordToSpell = majorTriads.SpellChord(selectedRoot);
                            break;
                        case Resource.Id.minorTriadRadioButton:
                            chordToSpell = minorTriads.SpellChord(selectedRoot);
                            break;
                        case Resource.Id.augmentedTriadRadioButton:
                            chordToSpell = augmentedTriads.SpellChord(selectedRoot);
                            break;
                        case Resource.Id.diminishedTriadRadioButton:
                            chordToSpell = diminishedTriads.SpellChord(selectedRoot);
                            break;
                    }
                }
                else // seventhsRadioGroup is visible
                {
                    switch (seventhsRadioGroup.CheckedRadioButtonId)
                    {
                        case(Resource.Id.major7RadioButton):
                            chordToSpell = majorSevenths.SpellChord(selectedRoot);
                            break;
                        case(Resource.Id.minor7RadioButton):
                            chordToSpell = minorSevenths.SpellChord(selectedRoot);
                            break;
                        case(Resource.Id.dominant7RadioButton):
                            chordToSpell = dominantSevenths.SpellChord(selectedRoot);
                            break;
                        case(Resource.Id.halfDim7RadioButton):
                            chordToSpell = halfDiminishedSevenths.SpellChord(selectedRoot);
                            break;
                        case(Resource.Id.fullyDim7RadioButton):
                            chordToSpell = fullyDiminishedSevenths.SpellChord(selectedRoot);
                            break;
                    }
                }
                
                chordNameTextView.Text = chordToSpell.Key;
                chordSpellingTextView.Text = chordToSpell.Value;
            };
        }
    }
}

