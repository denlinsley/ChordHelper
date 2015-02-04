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
using Android.Preferences;

namespace ChordHelper
{
    public class ChordTrainerFragment : Fragment
    {
        private TextView spellingTextView;
        private string userSpelling;
        private ChordLibrary chordLib;
        private int numClicks; // accumulator for UI-specific display logic
        private string chordType;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RetainInstance = true; // from BNR ch. 14
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FragmentChordTrainer, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this.Activity);

            chordLib = new ChordLibrary();
            // Include specific triads/sevenths based on preferences (all included by default)
            if (prefs.GetBoolean("select_major_triads", true))
                chordLib.AddMajorTriads();
            if (prefs.GetBoolean("select_minor_triads", true))
                chordLib.AddMinorTriads();
            if (prefs.GetBoolean("select_augmented_triads", true))
                chordLib.AddAugmentedTriads();
            if (prefs.GetBoolean("select_diminished_triads", true))
                chordLib.AddDiminishedTriads();
            if (prefs.GetBoolean("select_major_sevenths", true))
                chordLib.AddMajorSevenths();
            if (prefs.GetBoolean("select_minor_sevenths", true))
                chordLib.AddMinorSevenths();
            if (prefs.GetBoolean("select_dominant_sevenths", true))
                chordLib.AddDominantSevenths();
            if (prefs.GetBoolean("select_half_diminished_sevenths", true))
                chordLib.AddHalfDiminishedSevenths();
            if (prefs.GetBoolean("select_fully_diminished_sevenths", true))
                chordLib.AddFullyDiminishedSevenths();
  

            var newChordButton = this.Activity.FindViewById<Button>(Resource.Id.newChordButton);
            var checkSpellingButton = this.Activity.FindViewById<Button>(Resource.Id.checkSpellingButton);
            var tryAgainButton = this.Activity.FindViewById<Button>(Resource.Id.tryAgainButton);
            var showAnswerButton = this.Activity.FindViewById<Button>(Resource.Id.showAnswerButton);

            var newChordTextView = this.Activity.FindViewById<TextView>(Resource.Id.newChordTextView);
            spellingTextView = this.Activity.FindViewById<TextView>(Resource.Id.spellingTextView);
            var resultTextView = this.Activity.FindViewById<TextView>(Resource.Id.resultTextView);


            var cButton = this.Activity.FindViewById<Button>(Resource.Id.cButton);
            var dButton = this.Activity.FindViewById<Button>(Resource.Id.dButton);
            var eButton = this.Activity.FindViewById<Button>(Resource.Id.eButton);
            var fButton = this.Activity.FindViewById<Button>(Resource.Id.fButton);
            var gButton = this.Activity.FindViewById<Button>(Resource.Id.gButton);
            var aButton = this.Activity.FindViewById<Button>(Resource.Id.aButton);
            var bButton = this.Activity.FindViewById<Button>(Resource.Id.bButton);

            cButton.Click += noteButton_Click;
            dButton.Click += noteButton_Click;
            eButton.Click += noteButton_Click;
            fButton.Click += noteButton_Click;
            gButton.Click += noteButton_Click;
            aButton.Click += noteButton_Click;
            bButton.Click += noteButton_Click;

            var sharpButton = this.Activity.FindViewById<Button>(Resource.Id.sharpButton);
            var flatButton = this.Activity.FindViewById<Button>(Resource.Id.flatButton);

            sharpButton.Click += accidentalButton_Click;
            flatButton.Click += accidentalButton_Click;

            newChordButton.Click += (sender, e) =>
            {
                chordLib.GetRandomChord();
                newChordTextView.Text = chordLib.ChordName;
                // reset for next chord
                spellingTextView.Text = "";
                resultTextView.Text = "";
                userSpelling = "";
                numClicks = 0;
            };

            checkSpellingButton.Click += (sender, e) =>
            {
                bool result = chordLib.CheckChordSpelling(userSpelling, chordLib.ChordSpelling);
                if (result)
                    resultTextView.Text = "CORRECT!";
                else
                    resultTextView.Text = "INCORRECT";
            };

            tryAgainButton.Click += (sender, e) =>
            {
                userSpelling = "";
                spellingTextView.Text = userSpelling;
                resultTextView.Text = "";
                numClicks = 0;
            };

            showAnswerButton.Click += (sender, e) =>
            {
                resultTextView.Text = chordLib.ChordSpelling;
            };

            // Quick-and-easy EXCEPTION HANDLING (as opposed to disabling/enabling all those buttons)
            // Set a default C major chord to prevent exceptions when note or accidental buttons are clicked
            // (the checkSpelling, tryAgain, showAnswer buttons don't throw an exception) 
            chordLib.ChordName = "C major";
            chordLib.ChordSpelling = "C-E-G";
        }

        // To set the onClick property of a button you need a single (View v) parameter [see tool tip in properties]
        // This seems totally different than regular C# where you have the object and EventArgs parameters
        public void noteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            numClicks++;

            // set a chordType for hyphen concatenation logic
            if (chordLib.ChordName.Contains("triad"))
                chordType = "triad";
            else
                chordType = "seventh";

            switch (chordType)
            {
                case "triad":
                    if (numClicks < 3)
                        userSpelling += button.Text + "-";
                    else
                        userSpelling += button.Text;
                    spellingTextView.Text = userSpelling;
                    break;
                case "seventh":
                    if (numClicks < 4)
                        userSpelling += button.Text + "-";
                    else
                        userSpelling += button.Text;
                    spellingTextView.Text = userSpelling;
                    break;
            }
        }


        public void accidentalButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // if adding a sharp or flat, remove the hyphen...
            string temp = userSpelling.Remove(userSpelling.Length - 1);

            // ...then reformat to "C#-" (use substring to only get the "#" or "b" from the button text)
            switch (chordType)
            {
                case "triad":
                    if (numClicks < 3)
                        userSpelling = temp + button.Text.Substring(0, 1) + "-";
                    else
                        userSpelling += button.Text.Substring(0, 1); // if 3rd note don't add temp (no hyphen was added in noteClick)
                    spellingTextView.Text = userSpelling;
                    break;
                case "seventh":
                    if (numClicks < 4)
                        userSpelling = temp + button.Text.Substring(0, 1) + "-";
                    else
                        userSpelling += button.Text.Substring(0, 1); // if 4th note don't add temp (no hyphen was added in noteClick)
                    spellingTextView.Text = userSpelling;
                    break;
            }
        }
    }
}

