using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore;
using System.Media;
using SIPProvider.SIPCore.Interfaces;
using System.Windows.Forms;

namespace Softphone.MediaFolder
{
    public class CMediaPlayerProxy : IMediaProxyInterface
    {
        SoundPlayer player = new SoundPlayer();
        private List<Timer> Timers = new List<Timer>();
        #region Methods
        private Timer CreateTimer()
        {
            Timer Timer = new Timer();
            Timer.Enabled = true;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = 2000;
            Timer.Start();
            Timers.Add(Timer);
            return Timer;
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            if (Timers.Count > 0 && Timers[Timers.Count - 1] == timer)
            {
                if (player.SoundLocation == "Sounds/congestion.wav")
                    stopTone();
            }
            Timers.Remove(timer);
            timer.Dispose();
        }

        public int playTone(ETones toneId)
        {                      
            string fname;
            
            switch (toneId)
            {
                case ETones.EToneDial:
                    fname = "Sounds/dial.wav";
                    break;
                case ETones.EToneCongestion:
                    fname = "Sounds/congestion.wav";
                    break;
                case ETones.EToneRingback:
                    fname = "Sounds/ringback.wav";
                    break;
                case ETones.EToneRing:
                    fname = "Sounds/ring.wav";
                    break;
                default:
                    fname = "";
                    break;
            }
            if (!System.IO.File.Exists(fname)) return 0;
            if (toneId == ETones.EToneRingback) return 1;
            if (toneId == ETones.EToneCongestion) CreateTimer();
            player.SoundLocation = fname;
            player.Load();
            player.PlayLooping();

            return 1;
        }
 
        public int stopTone()
        {

           player.Stop();
            return 1;
        }


        #endregion

    }
}
