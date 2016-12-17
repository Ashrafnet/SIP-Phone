using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Softphone.MainFolder;

namespace Softphone.DtmfFolder
{
    public partial class ctrKeyPad : UserControl
    {
        public event KeypadPressed OnKeypadPressed;
        public ctrKeyPad()
        {
            InitializeComponent();
            OnKeypadPressed += ctrKeyPad_OnKeypadPressed;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            OnKeypadPressed -= ctrKeyPad_OnKeypadPressed;

            base.OnHandleDestroyed(e);
        }
        void ctrKeyPad_OnKeypadPressed(char keyPad)
        {
            MainForm.Instance.ShowPanelContianerControl(0);
            if (MainForm.Instance.IsShownControl<ctrMainWindow>())
                try { MainForm.Instance.GetControl<ctrMainWindow>().KeyPad_OnKeypadPressed(keyPad); }
                catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control but = (Control)sender;
            char keyPad = char.Parse(but.Tag + "");           
            if (OnKeypadPressed != null) OnKeypadPressed(keyPad);
        }

     
    }
}
