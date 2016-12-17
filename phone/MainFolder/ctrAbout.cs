using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace Softphone.MainFolder
{
    public partial class ctrAbout : UserControl
    {
        public ctrAbout()
        {
            InitializeComponent();
        }

        #region IPhoneControl Members

        public bool NeedOkCancel
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text+ "");
        }
    }
}
