using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softphone.CallHistory;
using SIPProvider.SIPCore;
using Softphone.SettingFolder;
using SIPProvider.Common;
using Softphone.PhoneBookFace;

namespace Softphone.MainFolder
{
    public partial class ctrMenu : UserControl
    {
        public ctrMenu()
        {
            InitializeComponent();
            FactoryManger.Instance.OnStateUpdate += Instance_OnStateUpdate;
            MainForm.Instance.OnOkButtonPressed += Instance_OnOkButtonPressed;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            FactoryManger.Instance.OnStateUpdate -= Instance_OnStateUpdate;
            MainForm.Instance.OnOkButtonPressed -= Instance_OnOkButtonPressed;

            base.OnHandleDestroyed(e);
        }
        void Instance_OnOkButtonPressed()
        {
            if (!MainForm.Instance.IsShownControl<ctrMenu>()) return;
            ctrMenuItem item = FocusControl();
            if (item == null) return;
            ctrMenuItem7_OnClikItem(item, null);
        }
        ctrMenuItem FocusControl()
        {
            foreach (Control con in this.Controls)
                if (con is ctrMenuItem && ((ctrMenuItem)con).Focused) return (ctrMenuItem)con;
            return null;
        }
        void Instance_OnStateUpdate(int sessionId)
        {
            ctrMenuItem7.Visible = CCallManager.Instance.Count > 0;
        }

        private void ctrMenu_Load(object sender, EventArgs e)
        {
            ctrMenuItem7.Visible = CCallManager.Instance.Count > 0;
        }


        ctrMenuItem lastPressed;
        private void ctrMenuItem7_OnClikItem(object sender, EventArgs e)
        {
            try
            {
                Control but = (Control)sender;
                switch (but.Tag + "")
                {
                    case "0":
                        MainForm.Instance.ShowPanelContianerControl(2);
                        MainForm.Instance.GetControl<ctrPhoneBook>().SelectionOnly = false;
                        break;
                    case "1": MainForm.Instance.ShowPanelContianerControl(14); break;
                    case "2": MainForm.Instance.ShowPanelContianerControl(7); break;
                    case "3": if (MainForm.Instance.ShowPanelContianerControl(1))
                            MainForm.Instance.GetControl<ctrCallHistory>().CallType = ECallType.EReceived;
                        break;
                    case "4": if (MainForm.Instance.ShowPanelContianerControl(1))
                            MainForm.Instance.GetControl<ctrCallHistory>().CallType = ECallType.EDialed;
                        break;
                    case "5": if (MainForm.Instance.ShowPanelContianerControl(1))
                            MainForm.Instance.GetControl<ctrCallHistory>().CallType = ECallType.EMissed;
                        break;
                    case "6": System.Diagnostics.Process.Start(Settings.Default.BalanceLink); break;
                    case "7": MainForm.Instance.ShowPanelContianerControl(6); break;
                    case "8": MainForm.Instance.ShowPanelContianerControl(3); break;
                }
                lastPressed =(ctrMenuItem) but;
            }
            catch { }
        }

        private void ctrMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (lastPressed == null) return;
            if (this.Visible) lastPressed.Focus();
        }

       

       

        
    }
}
