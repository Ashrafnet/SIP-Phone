using System;
using System.Collections.Generic;
using System.Text;
using WaveLib.AudioMixer;

namespace SIPProvider.VolumeControl
{

   public class Volume
    {
       public Mixer PlayMixer { get; private set; }
       public Mixer MicMixer { get; private set; }
       public Volume()
       {
           PlayMixer = new Mixer(MixerType.Playback);
           MicMixer = new Mixer(MixerType.Recording);
           
       }

       public int PlaybackVolume
       {
           get
           {
                return PlayMixer.UserLines[0].Volume; 
           }
           set
           {
               PlayMixer.UserLines[0].Volume = value;
           }
       }

       public int MicVolume
       {
           get
           {
               return MicMixer.UserLines[0].Volume;
           }
           set
           {
               MicMixer.UserLines[0].Volume = value;
           }
       }

       public int PlaybackMaxVolume
       {
           get
           {
               return PlayMixer.UserLines[0].VolumeMax;
           }
       }

       public int PlaybackMinVolume
       {
           get
           {
               return PlayMixer.UserLines[0].VolumeMin;
           }
       }

       public int MicMaxVolume
       {
           get
           {
               return MicMixer.UserLines[0].VolumeMax;
           }
       }

       public int MicMinVolume
       {
           get
           {
               return MicMixer.UserLines[0].VolumeMin;
           }
       }
    }
}
