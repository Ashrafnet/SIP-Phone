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
    public partial class ctrSettingsGenral : UserControl, ISettingsControl
    {
        public ctrSettingsGenral()
        {
            InitializeComponent();
            comboBoxDateTimeStyle.Text = Settings.Default.DateTimeFormat;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDatetimeShow.Text = "" + DateTime.Now.ToString(comboBoxDateTimeStyle.Text) ;
            IsChanged = true;
        }

        public bool ApplyOptions()
        {
            try
            {
                Settings.Default.DateTimeFormat = comboBoxDateTimeStyle.Text;
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

        private void comboBoxDateTimeStyle_TextChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }
    }
}
