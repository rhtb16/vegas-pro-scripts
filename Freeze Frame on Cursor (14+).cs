using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ScriptPortal.Vegas;

public class EntryPoint {

    Vegas myVegas;
    TransportControl cursor;
    
    public void FromVegas(Vegas vegas) {

        myVegas = vegas;
        Timecode cursorPosition = vegas.Transport.CursorPosition;

        foreach (Track tr in vegas.Project.Tracks){
            if (tr.IsVideo()){
			    foreach (TrackEvent trackEvent in tr.Events){
                    VideoEvent videoEvent = (VideoEvent) trackEvent;
                    
                    if (videoEvent.Selected){
                        Envelope startEnvelope = new Envelope(EnvelopeType.Velocity);
                        
                        if(trackEvent.Start <= cursorPosition && (trackEvent.End > cursorPosition)){
                            if (!videoEvent.Envelopes.HasEnvelope(EnvelopeType.Velocity)){
                                videoEvent.Envelopes.Add(startEnvelope);
                            } else{
                                videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points.Clear();
                            }
                            EnvelopePoint freezeEnvelope = new EnvelopePoint(cursorPosition - trackEvent.Start, 0, CurveType.None);

                            videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points.Add(freezeEnvelope);
                            videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points[0].Curve = CurveType.None;       
                            videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points[0].Y = 1;
                        } else {
                            if (!videoEvent.Envelopes.HasEnvelope(EnvelopeType.Velocity)){
                                Envelope envelope = new Envelope(EnvelopeType.Velocity);
                                videoEvent.Envelopes.Add(envelope);
                                videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points[0].Y = 0;
                            } else{
                                videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points.Clear();
                                videoEvent.Envelopes.FindByType(EnvelopeType.Velocity).Points[0].Y = 0;
                            }   
                        }
                    }
                }
            }
		}
}
}