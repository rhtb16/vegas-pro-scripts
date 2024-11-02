using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Sony.Vegas;

public class EntryPoint {

    Vegas myVegas;
    
    public void FromVegas(Vegas vegas) {

        myVegas = vegas;

        Timecode oneSecond = Timecode.FromSeconds(1);

        foreach (Track tr in vegas.Project.Tracks){
			    foreach (TrackEvent ev in tr.Events){
                    if (ev.Selected){
                        if(ev.IsVideo()){
                            VideoEvent videoEvent = (VideoEvent) ev;

                            Timecode OneFrame = Timecode.FromNanos((long)((double)oneSecond.Nanos / videoEvent.ActiveTake.Media.GetVideoStreamByIndex(0).FrameRate));
                            ev.AdjustStartLength(Timecode.FromNanos((ev.Start.Nanos+=OneFrame.Nanos)),ev.Length,false);
                            ev.AdjustStartLength(Timecode.FromNanos((ev.Start.Nanos-=OneFrame.Nanos)),ev.Length,true);
                            }
                        }
                    }
                }
		}
}