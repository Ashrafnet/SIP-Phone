using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softphone.SmsFolder;


namespace Softphone.MainFolder.SmsFolder
{
    public partial class ctrSmsMenu : UserControl
    {
        public ctrSmsMenu()
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
            if (!MainForm.Instance.IsShownControl<ctrSmsMenu>()) return;
            ctrMenuItem item = FocusControl();
            if (item == null) return;
            ctrMenuItem3_OnClikItem(item, null);
        }

        ctrMenuItem FocusControl()
        {
            foreach (Control con in this.Controls)
                if (con is ctrMenuItem && ((ctrMenuItem)con).Focused) return (ctrMenuItem)con;
            return null;
        }
        ctrMenuItem lastPressed;
        private void ctrMenuItem3_OnClikItem(object sender, EventArgs e)
        {
            try
            {
                Control but = (Control)sender;
                switch (but.Tag + "")
                {
                    case "0":
                        if (MainForm.Instance.ShowPanelContianerControl(12))
                            MainForm.Instance.GetControl<ctrSmsSender>().SetData("");
                        break;
                    case "1":
                        if (MainForm.Instance.ShowPanelContianerControl(4))
                            MainForm.Instance.GetControl<ctrSmsManager>().SetSmsBookType(SMSBoxType.Inbox);
                        break;
                    case "2":
                        if (MainForm.Instance.ShowPanelContianerControl(4))
                            MainForm.Instance.GetControl<ctrSmsManager>().SetSmsBookType(SMSBoxType.Outbox);
                        break;
                }
               lastPressed= (ctrMenuItem)but;
            }
            catch { }
        }

        private void ctrSmsMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (lastPressed == null) return;
            if (this.Visible) lastPressed.Focus();
        }

 
    }
}
