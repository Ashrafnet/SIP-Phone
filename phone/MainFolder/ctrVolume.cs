using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SIPProvider.VolumeControl;
using Softphone.Properties;

namespace Softphone.MainFolder
{
    public partial class ctrVolume : UserControl
    {
        
        Volume volume = new Volume();
        /// <summary>
        /// Value must be between 0 and 100
        /// </summary>
        private int PlayBackVolume
        {
            get
            {
                try 
                {
                    //int val= 100 * PC_VolumeControl.VolumeControl.GetVolume() / PC_VolumeControl.VolumeControl.MaxVolume;
                    int val = 100 * volume.PlaybackVolume / volume.PlaybackMaxVolume;
                    label1.Text = val + "";
                    return val;
                }
                catch { return 0; }
            }
            set 
            {
                try
                {
                    if (value < 0 || value > 100) return;
                    volume.PlaybackVolume = value * volume.PlaybackMaxVolume / 100;
                    label1.Text = value + ""; 
                }
                catch {  }
            }
        }
        private int RecordVolume
        {
            get
            {
                try
                {
                    //int val= 100 * PC_VolumeControl.VolumeControl.GetVolume() / PC_VolumeControl.VolumeControl.MaxVolume;
                    int val = 100 * volume.MicVolume / volume.MicMaxVolume;
                    label2.Text = val + "";
                    return val;
                }
                catch { return 0; }
            }
            set
            {
                try
                {
                    if (value < 0 || value > 100) return;
                    volume.MicVolume = value * volume.MicMaxVolume / 100;
                    label2.Text = value + "";
                }
                catch { }
            }
        }
        public ctrVolume()
        {

            InitializeComponent();
            trackBar1.Maximum = 100;
            volume.PlayMixer.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(MicMixer_MixerLineChanged);
            volume.MicMixer.MixerLineChanged+=new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(PlayBackMixer_MixerLineChanged);
            SetAllVolume();
            //this.LostFocus += new EventHandler(ctrVolume_LostFocus);
            //trackBar1.LostFocus += new EventHandler(trackBar1_LostFocus);
            //trackBar2.LostFocus += new EventHandler(trackBar2_LostFocus);
        }

        void trackBar1_LostFocus(object sender, EventArgs e)
        {
            VisibleControl(VolumeType.PlayBack , false);
        }
        void trackBar2_LostFocus(object sender, EventArgs e)
        {
            VisibleControl(VolumeType.Recording, false);
        }
        void MicMixer_MixerLineChanged(WaveLib.AudioMixer.Mixer mixer, WaveLib.AudioMixer.MixerLine line)
        {

            SetAllVolume();
        }

        void SetAllVolume()
        {
            buttonSpeaker.Image = volume.PlayMixer.Lines[0].Mute ? Resources.SpeakerMute : Resources.Speaker1;
            trackBar1.Value = PlayBackVolume;

            pictureBox1.Image = volume.MicMixer .Lines[0].Mute ? Resources.micMute : Resources.mic;
            trackBar2.Value = RecordVolume ;
            
        }
        void PlayBackMixer_MixerLineChanged(WaveLib.AudioMixer.Mixer mixer, WaveLib.AudioMixer.MixerLine line)
        {
            SetAllVolume();
        }
        void buttonSpeaker_GotFocus(object sender, EventArgs e)
        {
            trackBar1.Focus();
        }

       

        void ctrVolume_LostFocus(object sender, EventArgs e)
        {
            VisibleControl(VolumeType.Recording, false);
            VisibleControl(VolumeType.PlayBack , false);
        }

        private void buttonSpeaker_Click(object sender, EventArgs e)
        {
            VisibleControl(VolumeType.PlayBack, !trackBar1.Visible);            
            if (trackBar1.Visible) trackBar1.Focus();

            
        }
        private enum VolumeType { PlayBack,Recording}
        void VisibleControl(VolumeType type,bool Visible)
        {
            try
            {
                if (type == VolumeType.PlayBack)
                {
                    trackBar1.Visible = Visible;
                    checkBox1.Visible = Visible;
                    label1.Visible = Visible;
                }
                else
                {
                    trackBar2.Visible = Visible;
                    checkBox2.Visible = Visible;
                    label2.Visible = Visible;
                }
            }
            catch
            {
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                PlayBackVolume = trackBar1.Value;
                
            }
            catch { }
        }
        public int GetVolume
        {
            get
            {
                return PlayBackVolume;
            }
        }

        private void ctrVolume_Leave(object sender, EventArgs e)
        {
            //label1.Visible = trackBar1.Visible = false; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VisibleControl(VolumeType.Recording , !trackBar2.Visible);
            
            if (trackBar2.Visible) trackBar2.Focus();

           
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            try { RecordVolume = trackBar2.Value; }
            catch { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            volume.PlayMixer.Lines[0].Mute = checkBox1.Checked;
            buttonSpeaker.Image = volume.PlayMixer.Lines[0].Mute ? Resources.SpeakerMute : Resources.Speaker1;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            volume.MicMixer.Lines[0].Mute = checkBox2.Checked;
            pictureBox1.Image = volume.MicMixer.Lines[0].Mute ? Resources.micMute : Resources.mic;
        }

        private void ctrVolume_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = volume.PlayMixer.Lines[0].Mute;
            checkBox2.Checked = volume.MicMixer.Lines[0].Mute;
        }
        
    }
}
