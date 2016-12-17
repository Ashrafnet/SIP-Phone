using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softphone.ConfigFolder;
using SIPProvider.SIPCore;

namespace Softphone
{
    public partial class ctrSelectCodecs : UserControl, Softphone.SettingFolder.ISettingsControl
    {
        public ctrSelectCodecs()
        {
            InitializeComponent();
        }

        private void ctrSelectCodecs_Load(object sender, EventArgs e)
        {
            ctrSelectColumns ctr = new ctrSelectColumns(pjsipStackProxy.Instance.getAllCodecs(), PhoneConfig.Instance.CodecList);
            ctr.Dock = DockStyle.Fill;
            this.Controls.Add(ctr);
        }



        #region ISettingsControl Members

        public bool ApplyOptions()
        {
            try
            {
                ctrSelectColumns con = (ctrSelectColumns)this.Controls[typeof(ctrSelectColumns).Name];
                con.ApplyOption();
                PhoneConfig.Instance.CodecList = con.enabledItems;

                foreach (string item in con.disableItems)
                    pjsipStackProxy.Instance.setCodecPriority(item, 0);
                int i = 0;
                foreach (string item in PhoneConfig.Instance.CodecList)
                {
                    pjsipStackProxy.Instance.setCodecPriority(item, 128 - i);
                    i++;
                }
                return true;
            }
            catch { return false; }
        }

        public bool IsChanged
        {
            get
            {
               
                return true;
            }
            set
            {
          
            }
        }

        public event SettingChanged OnChanged;

        #endregion
    }
}
