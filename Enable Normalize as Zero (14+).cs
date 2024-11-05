using System;
using System.Collections.Generic;
using ScriptPortal.Vegas;

public class EntryPoint {

    Vegas myVegas;

    public void FromVegas(Vegas vegas){
        myVegas = vegas;
        foreach (Track tr in vegas.Project.Tracks){
            if (tr.IsAudio()){
			    foreach (AudioEvent audioEvent in tr.Events){
                    if (audioEvent.Selected){
                        audioEvent.Normalize = true;
                        audioEvent.NormalizeGain = 1.0F;
                        }
                    }
                }
            }
		}

}