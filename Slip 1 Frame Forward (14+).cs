using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ScriptPortal.Vegas;

public class EntryPoint {

    Vegas myVegas;
    
    public void FromVegas(Vegas vegas) {

        myVegas = vegas;
        foreach (Track tr in vegas.Project.Tracks){
			    foreach (TrackEvent ev in tr.Events){
                    if (ev.Selected){
                        ev.AdjustStartLength(ev.Start--,ev.Length,true);
                        }
                    }
                }
		}
}