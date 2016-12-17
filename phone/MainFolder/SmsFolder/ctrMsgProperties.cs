using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Softphone.SmsFolder
{
    public partial class ctrMsgProperties : UserControl
    {
        public ctrMsgProperties()
        {
            InitializeComponent();
            MainForm.Instance.OnOkButtonPressed += Instance_OnOkButtonPressed;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            MainForm.Instance.OnOkButtonPressed -= Instance_OnOkButtonPressed;
            base.OnHandleDestroyed(e);
        }
        void Instance_OnOkButtonPressed()
        {
            if (!MainForm.Instance.IsShownControl<ctrMsgProperties>()) return;
            MainForm.Instance.GotoBack();
        }
        public void SetData(SmsMsg msg)
        {
            textBoxSubject.Text = msg.subject;
            textBoxMessage.Text = msg.Message;
            textBoxDate.Text = msg.Reads + "";
            
            try { textBoxDate.Text = DateTime.Parse(msg.Date).ToString("ddd MMM dd yyyy HH:mm"); }
            catch { textBoxDate.Text = msg.Date; }
        }

    }
}
