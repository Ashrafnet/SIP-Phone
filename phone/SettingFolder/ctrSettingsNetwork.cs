using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softphone.ConfigFolder;
using SIPProvider.SIPCore;

namespace Softphone.SettingFolder
{
    public partial class ctrSettingsNetwork : UserControl, ISettingsControl
    {
        private int InitialSelectedIndex;
        public ctrSettingsNetwork()
        {
            InitializeComponent();
            try
            {
                
                numericUpDownListeningPort.Value = PhoneConfig.Instance.SIPPort;
                textBoxStunServer.Text = PhoneConfig.Instance.StunServerAddress;//StunServerAddress
                switch (PhoneConfig.Instance.Accounts[0].TransportMode)
                {
                    case ETransportMode.TM_UDP: comboBoxTransport.SelectedIndex = 0; break;
                    case ETransportMode.TM_TCP: comboBoxTransport.SelectedIndex = 1; break;
                    case ETransportMode.TM_TLS: comboBoxTransport.SelectedIndex = 2; break;
                }
                InitialSelectedIndex = comboBoxTransport.SelectedIndex;
            }
            catch { }
        }

        public bool ApplyOptions()
        {
            try
            {
                if (!IsChanged) return true;
                PhoneConfig.Instance.SIPPort = (int)numericUpDownListeningPort.Value;
                PhoneConfig.Instance.StunServerAddress = textBoxStunServer.Text;
                switch (comboBoxTransport.SelectedIndex)
                {
                    case 0: PhoneConfig.Instance.Accounts[0].TransportMode = ETransportMode.TM_UDP; break;
                    case 1: PhoneConfig.Instance.Accounts[0].TransportMode = ETransportMode.TM_TCP; break;
                    case 2: PhoneConfig.Instance.Accounts[0].TransportMode = ETransportMode.TM_TLS; break;
                }
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

        private void numericUpDownListeningPort_ValueChanged(object sender, EventArgs e)
        {
                IsChanged = true;
        }

        private void comboBoxTransport_SelectedIndexChanged(object sender, EventArgs e)
        {
                IsChanged = true;
        }

        private void textBoxStunServer_TextChanged(object sender, EventArgs e)
        {
                IsChanged = true;
        }
    }
}
