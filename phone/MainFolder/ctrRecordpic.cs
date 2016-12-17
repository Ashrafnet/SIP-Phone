using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softphone.Properties;

namespace Softphone.MainFolder
{
    public partial class ctrRecordpic : PictureBox
    {
        Timer timer;
        public ctrRecordpic()
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            this.Image = Resources.record;
            //timer.Enabled = true;
        }

        public bool EnabelTimer
        {
            get { return timer.Enabled; }
            set
            {
                timer.Enabled = value;
                this.Visible = value;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }
    }
}
