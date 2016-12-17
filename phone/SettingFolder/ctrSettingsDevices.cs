using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softphone.ConfigFolder;

namespace Softphone.SettingFolder
{
    public partial class ctrSettingsDevices : UserControl, ISettingsControl
    {
        public ctrSettingsDevices()
        {
            InitializeComponent();
            checkBoxVoiceActivityDetection.Checked = PhoneConfig.Instance.VADEnabled;
        }
       
        public bool ApplyOptions()
        {
            try
            {
                PhoneConfig.Instance.VADEnabled = checkBoxVoiceActivityDetection.Checked;                
                return true;
            }
            catch { return false; }
        }

        bool _IsChanged;
        public bool IsChanged
        {
            get { return _IsChanged; }
            set
            {
                if (value && OnChanged != null) OnChanged("");
                _IsChanged = value;
            }
        }
        public event SettingChanged OnChanged;

        private void ctrSettingsDevices_Load(object sender, EventArgs e)
        {
            cmbMicDevices.SelectedIndex = 0;
            cmbSpeakersDevices .SelectedIndex = 0;
        }

        private void trackBarSpeaker_Scroll(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void trackBarRecording_Scroll(object sender, EventArgs e)
        {            
            IsChanged = true;
        }
    }
}
