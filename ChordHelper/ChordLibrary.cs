using System;
using System.Collections.Generic;
using System.Linq;


public class ChordLibrary
{
    private Dictionary<string, string> chords;

    Random rand = new Random();

    public string ChordName { get; set; }
    public string ChordSpelling { get; set; }
    public string ChordType { get; set; }
    

    public ChordLibrary()
    {
        chords = new Dictionary<string, string>();
    }
        

    public void AddMajorTriads() 
    {
        // naturals
        chords.Add("C major triad", "C-E-G");
        chords.Add("D major triad", "D-F#-A");
        chords.Add("E major triad", "E-G#-B");
        chords.Add("F major triad", "F-A-C");
        chords.Add("G major triad", "G-B-D");
        chords.Add("A major triad", "A-C#-E");
        chords.Add("B major triad", "B-D#-F#");
//        // sharps
//        chords.Add("C# major triad", "C#-E#-G#");
//        chords.Add("D# major triad", "D#-F##-A");
//        chords.Add("F# major triad", "F#-A#-C#");
//        chords.Add("G# major triad", "G#-B#-D#");
//        chords.Add("A# major triad", "A#-C##-E#");
//        // flats
//        chords.Add("Db major triad", "Db-F-Ab");
//        chords.Add("Eb major triad", "Eb-G-Bb");
//        chords.Add("Gb major triad", "Gb-Bb-Db");
//        chords.Add("Ab major triad", "Ab-C-Eb");
//        chords.Add("Bb major triad", "Bb-D-F");
    }

    public void AddMinorTriads()
    {
        // naturals
        chords.Add("C minor triad", "C-Eb-G");
        chords.Add("D minor triad", "D-F-A");
        chords.Add("E minor triad", "E-G-B");
        chords.Add("F minor triad", "F-Ab-C");
        chords.Add("G minor triad", "G-Bb-D");
        chords.Add("A minor triad", "A-C-E");
        chords.Add("B minor triad", "B-D-F#");
//        // sharps
//        chords.Add("C# minor triad", "C#-E-G#");
//        chords.Add("D# minor triad", "D#-F#-A#");
//        chords.Add("F# minor triad", "F#-A-C#");
//        chords.Add("G# minor triad", "G#-B-D#");
//        chords.Add("A# minor triad", "A#-C#-E#");
//        // flats
//        chords.Add("Db minor triad", "Db-Fb-Ab");
//        chords.Add("Eb minor triad", "Eb-Gb-Bb");
//        chords.Add("Gb minor triad", "Gb-Bbb-Db");
//        chords.Add("Ab minor triad", "Ab-Cb-Eb");
//        chords.Add("Bb minor triad", "Bb-Db-F");
    }

    public void AddAugmentedTriads()
    {
        chords.Add("C augmented triad", "C-E-G#");
        chords.Add("D augmented triad", "D-F#-A#");
        chords.Add("E augmented triad", "E-G#-B#");
        chords.Add("F augmented triad", "F-A-C#");
        chords.Add("G augmented triad", "G-B-D#");
        chords.Add("A augmented triad", "A-C#-E#");
        chords.Add("B augmented triad", "B-D#-F##");
    }

    public void AddDiminishedTriads()
    {
        chords.Add("C diminished triad", "C-Eb-Gb");
        chords.Add("D diminished triad", "D-F-Ab");
        chords.Add("E diminished triad", "E-G-Bb");
        chords.Add("F diminished triad", "F-Ab-Cb");
        chords.Add("G diminished triad", "G-Bb-Db");
        chords.Add("A diminished triad", "A-C-Eb");
        chords.Add("B diminished triad", "B-D-F");
    }

    public void AddMajorSevenths()
    {
        chords.Add("C major 7", "C-E-G-B");
        chords.Add("D major 7", "D-F#-A-C#");
        chords.Add("E major 7", "E-G#-B-D#");
        chords.Add("F major 7", "F-A-C-E");
        chords.Add("G major 7", "G-B-D-F#");
        chords.Add("A major 7", "A-C#-E-G#");
        chords.Add("B major 7", "B-D#-F#-A#");
    }

    public void AddMinorSevenths()
    {
        chords.Add("C minor 7", "C-Eb-G-Bb");
        chords.Add("D minor 7", "D-F-A-C");
        chords.Add("E minor 7", "E-G-B-D");
        chords.Add("F minor 7", "F-Ab-C-Eb");
        chords.Add("G minor 7", "G-Bb-D-F");
        chords.Add("A minor 7", "A-C-E-G");
        chords.Add("B minor 7", "B-D-F#-A");
    }

    public void AddDominantSevenths()
    {
        chords.Add("C dominant 7", "C-E-G-Bb");
        chords.Add("D dominant 7", "D-F#-A-C");
        chords.Add("E dominant 7", "E-G#-B-D");
        chords.Add("F dominant 7", "F-A-C-Eb");
        chords.Add("G dominant 7", "G-B-D-F");
        chords.Add("A dominant 7", "A-C#-E-G");
        chords.Add("B dominant 7", "B-D#-F#-A");
    }

    public void AddHalfDiminishedSevenths()
    {
        chords.Add("C half-diminished 7", "C-Eb-Gb-Bb");
        chords.Add("D half-diminished 7", "D-F-Ab-C");
        chords.Add("E half-diminished 7", "E-G-Bb-D");
        chords.Add("F half-diminished 7", "F-Ab-Cb-Eb");
        chords.Add("G half-diminished 7", "G-Bb-Db-F");
        chords.Add("A half-diminished 7", "A-C-Eb-G");
        chords.Add("B half-diminished 7", "B-D-F-A");
    }

    public void AddFullyDiminishedSevenths()
    {
        chords.Add("C fully-diminished 7", "C-Eb-Gb-Bbb");
        chords.Add("D fully-diminished 7", "D-F-Ab-Cb");
        chords.Add("E fully-diminished 7", "E-G-Bb-Db");
        chords.Add("F fully-diminished 7", "F-A-Cb-Ebb");
        chords.Add("G fully-diminished 7", "G-Bb-Db-Fb");
        chords.Add("A fully-diminished 7", "A-C-Eb-Gb");
        chords.Add("B fully-diminished 7", "B-D-F-Ab");
    }

    public void GetRandomChord()
    {
        // Get a random chord to spell out of the dictionary
        var randChord = chords.ElementAt(rand.Next(0, chords.Count));
        // Set 2 properties based on this random chord
        this.ChordName = randChord.Key;
        this.ChordSpelling = randChord.Value;
    }

    public bool CheckChordSpelling(string attempt, string answer)
    {
        if (attempt == answer)
            return true;
        else
            return false;
    }


    // New method for Chord Generator
    public KeyValuePair<string, string> SpellChord(string root)
    {
        // get a chord based on the root
        var chordToSpell = (from c in chords
                            where c.Value.StartsWith(root)
                            select c).Single();
        return chordToSpell;
    }


    // New helper method for Chord Trainer
    public void SetChordType(KeyValuePair<string, string> chord)
    {
        // Sets the Type property to triad or seventh
        if (chord.Key.Contains("triad"))
            this.ChordType = "triad";
        else
            this.ChordType = "seventh";
      
    }
}