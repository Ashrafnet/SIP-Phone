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
    public partial class ctrSettingsAdvanced : UserControl, ISettingsControl
    {
        public ctrSettingsAdvanced()
        {
            InitializeComponent();

            numericUpDownRegistrationTimeout.Value = PhoneConfig.Instance.Expires;
            checkBoxEchoCancelationTail.Checked = PhoneConfig.Instance.ECTail > 255;
            switch (PhoneConfig.Instance.DtmfMode)
            {
                case EDtmfMode.DM_Outband: comboBoxDtmfMode.SelectedIndex = 0; break;
                case EDtmfMode.DM_Inband: comboBoxDtmfMode.SelectedIndex = 1; break;
                case EDtmfMode.DM_Transparent: comboBoxDtmfMode.SelectedIndex = 2; break;
            }
        }

        public bool ApplyOptions()
        {
            try
            {
                PhoneConfig.Instance.Expires = (int)numericUpDownRegistrationTimeout.Value;
                PhoneConfig.Instance.ECTail = checkBoxEchoCancelationTail.Checked ? 256 : 50;
                switch (comboBoxDtmfMode.SelectedIndex)
                {
                    case 0: PhoneConfig.Instance.DtmfMode = EDtmfMode.DM_Outband; break;
                    case 1: PhoneConfig.Instance.DtmfMode = EDtmfMode.DM_Inband; break;
                    case 2: PhoneConfig.Instance.DtmfMode = EDtmfMode.DM_Transparent; break;
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
       private void comboBoxDtmfMode_SelectedIndexChanged(object sender, EventArgs e)
       {
           IsChanged = true;
       }

       private void numericUpDownRegistrationTimeout_ValueChanged(object sender, EventArgs e)
       {
           IsChanged = true;
       }

       private void checkBoxEchoCancelationTail_CheckedChanged(object sender, EventArgs e)
       {
           IsChanged = true;
       }
    }
}
