using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Softphone.SettingFolder;
using Softphone.ConfigFolder;
using SIPProvider.SIPCore;

namespace Softphone
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Tag+"")
            {
                case "genral":
                    ShowControl<ctrSettingsGenral>();
                    //Form x = new Form();
                    //x.Controls.Add(new ctrSelectCodecs  ());
                    
                      //  x.ShowDialog();
                    break;
                case "audio":
                    ShowControl<ctrSettingsDevices>();
                    break;
                case "network":
                    ShowControl<ctrSettingsNetwork>();
                    break;
                case "advanced":
                    ShowControl<ctrSettingsAdvanced>();
                    break;
                case "proxy":
                    ShowControl<ctrWebProxy>();
                    break;
            }
        }
        
        /// <summary>
        /// Add if not added before
        /// </summary>
        T ShowControl<T>() where T : Control, new()
        {
            if (typeof(T) == null) return null;
            string Name = typeof(T).Name;
            HideAllControls();
            Control con;
            if (panel1.Controls.ContainsKey(Name)) con = panel1.Controls[Name];
            else
            {
                con = new T();
                ISettingsControl setCon = (ISettingsControl)con;
                setCon.OnChanged += new SettingChanged(setCon_OnChanged);
                panel1.Controls.Add(con);
            }
            con.BringToFront();
            con.Visible = true;
            return (T)con;
        }

        void setCon_OnChanged(string propertyName)
        {
            buttonApply.Enabled = true;
        }
        void HideAllControls()
        {
            foreach (Control con in panel1.Controls)
                con.Visible = false;
        }
     

        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplyOptions();
            buttonApply.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplyOptions();
            Close();
        }

 

        #region ISettingsControl Members

        public bool ApplyOptions()
        {
            bool x = IsChanged;
            foreach (ISettingsControl con in panel1.Controls)
            {
                if (con.IsChanged) con.ApplyOptions();
                con.IsChanged = false;
            }
          if(x) 
              PhoneConfig.Instance.Save();
            return true;
        }

        public bool IsChanged
        {
            get
            {
                foreach (ISettingsControl con in panel1.Controls)
                    if (con.IsChanged) return true;
                return false;
            }
            set { }
        }
        public event SettingChanged OnChanged;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.SipHostName = "localhost";
            Settings.Default.SipProxy = "";
            Settings.Default.TransportMode = ETransportMode.TM_UDP;
        }
    }
}
