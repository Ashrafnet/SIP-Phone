using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Softphone.SettingFolder
{
    public partial class ctrWebProxy : UserControl,ISettingsControl
    {
        public ctrWebProxy()
        {
            InitializeComponent();
        }



        #region ISettingsControl Members

        public bool ApplyOptions()
        {
            try
            {
                Settings.Default.ProxyAddress = textBoxProxyAddress.Text;
                Settings.Default.ProxyDomain = textBoxProxyDomain.Text;
                Settings.Default.ProxyPassword = textBoxProxyPassword.Text;
                Settings.Default.ProxyUserName = textBoxProxyUserName.Text;
                Settings.Default.UseProxy = checkBoxUseProxy.Checked;
                Settings.Default.UseProxyAuthentication = checkBoxUseProxyAuthentication.Checked;
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

        #endregion

        private void textBoxProxyAddress_TextChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void checkBoxUseProxy_CheckedChanged_1(object sender, EventArgs e)
        {
            IsChanged = true;
            panel1.Enabled = checkBoxUseProxy.Checked;

            groupBoxUseProxyAuthentication.Enabled = checkBoxUseProxyAuthentication.Checked;
        }

        private void ctrWebProxy_Load(object sender, EventArgs e)
        {
            textBoxProxyAddress.Text = Settings.Default.ProxyAddress;
            textBoxProxyDomain.Text = Settings.Default.ProxyDomain;
            textBoxProxyPassword.Text = Settings.Default.ProxyPassword;
            textBoxProxyUserName.Text = Settings.Default.ProxyUserName;
            checkBoxUseProxy.Checked = Settings.Default.UseProxy;
            checkBoxUseProxyAuthentication.Checked = Settings.Default.UseProxyAuthentication;
        }
    }
}
