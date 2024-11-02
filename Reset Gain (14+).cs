using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ScriptPortal.Vegas;

public class EntryPoint {

    Vegas myVegas;
    
    public void FromVegas(Vegas vegas) {

        myVegas = vegas;
        foreach (Track tr in vegas.Project.Tracks){
            if (tr.IsAudio()){
			    foreach (AudioEvent audioEvent in tr.Events){
                    if (audioEvent.Selected){
                        audioEvent.FadeIn.Gain = 1.0F;
                        }
                    }
                }
            }
		}
}