using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ScriptPortal.Vegas;

public class EntryPoint {

    Vegas myVegas;
    
    public void FromVegas(Vegas vegas) {

        myVegas = vegas;
        Timecode interval_length = myVegas.Transport.LoopRegionLength;

        foreach (Track tr in vegas.Project.Tracks){
            if (tr.IsVideo()){
			    foreach (VideoEvent videoEvent in tr.Events){
                    if (videoEvent.Selected){
                        if (!videoEvent.Envelopes.HasEnvelope(EnvelopeType.Velocity)){
                            Envelope envelope = new Envelope(EnvelopeType.Velocity);
                            videoEvent.Envelopes.Add(envelope);
                        } else{
                            videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points.Clear();
                        }

                        
                        videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points[0].Y = 0;
                    }
                }
            }
		}
}
}