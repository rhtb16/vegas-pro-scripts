using System;
using System.Collections.Generic;
using Sony.Vegas;

public class EntryPoint {

    Vegas myVegas;

    public void FromVegas(Vegas vegas){
        myVegas = vegas;
        foreach (Track tr in vegas.Project.Tracks){
            if (tr.IsAudio()){
			    foreach (AudioEvent audioEvent in tr.Events){
                    if (audioEvent.Selected){
                        if (audioEvent.Normalize == false){
                            audioEvent.Normalize = true;
                            audioEvent.NormalizeGain = 1.0F;
                        }
                        audioEvent.NormalizeGain += 0.125F;
                        }
                    }
                }
            }
		}

}