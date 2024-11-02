using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ScriptPortal.Vegas;

public class Item {   
    private String start;
    public String Start  { get {return start;} set {start = value;}}
    private String length;
    public String Length  { get {return length;} set {length = value;}}

    public Item(String start_, String length_) {
        start = start_;
        length = length_;
    }
}

public class EntryPoint {


    Vegas myVegas;

    public void FromVegas(Vegas vegas) {
        myVegas = vegas;

        foreach (Track tr in vegas.Project.Tracks){
        List<TrackEvent> layerSelection = new List<TrackEvent>();
        List<Item> toScramble = new List<Item>();
		
			foreach (TrackEvent ev in tr.Events)
			{
				if (ev.Selected){
					layerSelection.Add(ev);
                    toScramble.Add(new Item(ev.Start.ToString(RulerFormat.Nanoseconds), ev.Length.ToString(RulerFormat.Nanoseconds)));
                }
			}

            Shuffle(toScramble);

            for(int i = 0; i < layerSelection.Count; i++){
                Timecode tc_start = Timecode.FromString(toScramble[i].Start,RulerFormat.Nanoseconds);
                Timecode tc_length = Timecode.FromString(toScramble[i].Length,RulerFormat.Nanoseconds);
                layerSelection[i].Start = tc_start;
                layerSelection[i].Length = tc_length;
            }

		}
    }

    public static void Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }   
}