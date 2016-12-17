using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Softphone.MainFolder
{
    public partial class ctrTitle : UserControl
    {
        public ctrTitle()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            this.SendToBack();
        }

        public Image Image
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string Title
        {
            get { return  label1.Text; }
            set { label1.Text = value; }
        }

    }
}
