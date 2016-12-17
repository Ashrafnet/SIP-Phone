using System;
using System.Windows.Forms;
using SIPProvider.Common;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;
using SIPProvider.PhoneBookSaver;
using Softphone.SettingFolder;
using Softphone.PhoneBookFace;
using Softphone.CallHistory;
using Softphone.ConfigFolder;
using System.Collections.Generic;
using System.ComponentModel;
using Softphone.DtmfFolder;
using System.Drawing;
using Softphone.SmsFolder;
using System.Drawing.Drawing2D;
using Softphone.MainFolder;
using Softphone.RemarkNotesFace;
using SIPProvider.RemarkNotes;
using Softphone.MainFolder.SmsFolder;

namespace Softphone
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }
        private Stack<int> StackShownIndex;
        #region Constructor
        public MainForm()
        {
            Instance = this;
            InitializeComponent();
            ctrButtonBack.Location = ctrButtonMenu.Location;
            StackShownIndex = new Stack<int>();
            RegisterMouseDown(this);
            SetFormRegion();
            FactoryManger.Instance.OnIncomingCallNotification += new DIncomingCallNotification(FactoryManger_OnIncomingCallNotification);
            FactoryManger.Instance.OnRegistrationUpdate += new DAccountStateChanged(FactoryManger_OnRegistrationUpdate);
            FactoryManger.Instance.OnStateUpdate += new DCallStateRefresh(FactoryManger_OnStateUpdate);

            //Register menu item events
            DropDownItems.Instance.RegisterToolStripMenuItemEvents(acceptToolStripMenuItem);
            DropDownItems.Instance.RegisterToolStripMenuItemEvents(releaseToolStripMenuItem);
            DropDownItems.Instance.RegisterToolStripMenuItemEvents(holdRetrieveToolStripMenuItem);

        }
        List<Point> points;
        private void SetFormRegion()
        {
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            int x = 4;
            points = new List<Point>();
            //   return;
            ////Top left side
            //points.Add(new Point(0, x));
            //points.Add(new Point(x, x));
            //points.Add(new Point(x, 0));

            ////Top Right side
            //points.Add(new Point(this.Width - x, 0));
            //points.Add(new Point(this.Width - x, x));
            //points.Add(new Point(this.Width, x));

            ////Down left side
            //points.Add(new Point(this.Width, this.Height - x));
            //points.Add(new Point(this.Width - x, this.Height - x));
            //points.Add(new Point(this.Width - x, this.Height));

            ////Down Right side
            //points.Add(new Point(x, this.Height));
            //points.Add(new Point(x, this.Height - x));
            //points.Add(new Point(0, this.Height - x));


            points.Add(new Point(0, 9));
            points.Add(new Point(1, 6));
            points.Add(new Point(4, 3));
            points.Add(new Point(7, 1));
            points.Add(new Point(9, 0));
            points.Add(new Point(253, 0));
            points.Add(new Point(256, 2));
            points.Add(new Point(259, 5));
            points.Add(new Point(260, 9));
            points.Add(new Point(261, 451));
            points.Add(new Point(259, 455));
            points.Add(new Point(257, 457));
            points.Add(new Point(253, 459));
            points.Add(new Point(11, 459));
            points.Add(new Point(7, 459));
            points.Add(new Point(4, 457));
            points.Add(new Point(1, 454));
            points.Add(new Point(0, 451));


            //  points.Add(new Point(0, 11)); points.Add(new Point(0, 10)); points.Add(new Point(1, 8)); points.Add(new Point(2, 5)); points.Add(new Point(4, 2)); points.Add(new Point(9, 0)); points.Add(new Point(251, 0)); points.Add(new Point(252, 0)); points.Add(new Point(255, 2)); points.Add(new Point(258, 4)); points.Add(new Point(260, 8)); points.Add(new Point(261, 11)); points.Add(new Point(261, 450)); points.Add(new Point(260, 453)); points.Add(new Point(258, 456)); points.Add(new Point(255, 458)); points.Add(new Point(254, 459)); points.Add(new Point(250, 459)); points.Add(new Point(11, 459)); points.Add(new Point(8, 459)); points.Add(new Point(5, 458)); points.Add(new Point(2, 455)); points.Add(new Point(1, 454)); points.Add(new Point(0, 452)); points.Add(new Point(0, 450));

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(points.ToArray());
            this.Region = new Region(path);
        }

        #endregion


        #region Synhronized callbacks

        void FactoryManger_OnStateUpdate(int sessionId)
        {
            RefreshGUI(CCallManager.Instance[sessionId]);
        }

        void FactoryManger_OnRegistrationUpdate(int accountId, int accState)
        {
            pjsip_status_code status = (pjsip_status_code)accState;
            if (accState != 200) ShowPanelContianerControl(-1);
        }

        void FactoryManger_OnIncomingCallNotification(int sessionId, string number, string info)
        {
            PhoneUser user = PhoneBook.Instance.GetUser(number);
            if (user != null) number = user.UserName + " ( " + number + " )";
            notifyIcon.Tag = null;
            notifyIcon.ShowBalloonTip(3600, Settings.Default.ProgramName, "Incoming Call From " + number + "!", ToolTipIcon.Info);

            ShowPanelContianerControl(0);
        }

        #endregion

        #region Events Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {

            ShowPanelContianerControl(-1);

            //If the register success then the login window hidden
            if (Settings.Default.AutoLogin && Settings.Default.UserName.Length > 0 && Settings.Default.pass.Length > 0)
                FactoryManger.Instance.SetConfig();
        }






        private void contextMenuStripCalls_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                acceptToolStripMenuItem.Visible = CCallManager.Instance[EStateId.INCOMING].Count > 0;
                releaseToolStripMenuItem.Visible = CCallManager.Instance.Count > 0;
                holdRetrieveToolStripMenuItem.Visible = CCallManager.Instance[s => s.StateId == EStateId.ACTIVE || s.StateId == EStateId.HOLDING].Count > 0;
                toolStripSeparator1.Visible = CCallManager.Instance.Count > 0;
                openToolStripMenuItem.Text = this.Visible ? "Hide " + Settings.Default.ProgramName : "Show " + Settings.Default.ProgramName;
                exitToolStripMenuItem.Visible = CCallManager.Instance.Count == 0;

                foreach (object o in contextMenuStripCalls.Items)
                    DropDownItems.Instance.acceptToolStripMenuItem_DropDownOpening(o, null);
            }
            catch { }
        }


        private void contextMenuStripCalls_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStripCalls.Hide();
            switch (e.ClickedItem.Tag + "")
            {
                default:
                    ToolStripDropDownItem button = (ToolStripDropDownItem)e.ClickedItem;
                    DropDownItems.Instance.acceptToolStripMenuItem_DropDownOpening(e.ClickedItem, e);
                    if (button.DropDownItems.Count == 1)
                        DropDownItems.Instance.toolStripButton7_DropDownItemClicked(button, new ToolStripItemClickedEventArgs(button.DropDownItems[0]));
                    break;
                case "open": ShowHideMainForm(!this.Visible); break;
                case "exit": ExitApplication(); break;
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            ShowHideMainForm(true);
            if (notifyIcon.Tag is RemarkNote)
            {
                ((RemarkNote)notifyIcon.Tag).IsRead = true;
                ShowPanelContianerControl(7);
            }
        }



        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuStripCalls.Hide();
                ShowHideMainForm(true);
            }
            else
            {
                contextMenuStripCalls.Hide();
                contextMenuStripCalls.Show(MousePosition);
            }
        }





        #endregion

        #region Methods
        void ExitApplication()
        {
            try
            {
                if (!PhoneConfig.Instance.Accounts[0].IsLoggedin) { Close(); return; }
                Cursor = Cursors.AppStarting;
                Hide();
                FactoryManger.Instance.Logoff();
                Cursor = Cursors.Default;
                Close();
            }
            catch { }
        }


        void ShowHideMainForm(bool showOrHide)
        {
            try
            {
                if (showOrHide)
                {
                    this.Show();//Show the form if it is visable
                    this.Activate();
                }
                else this.Hide();
            }
            catch { }
        }
        void LogOff()
        {
            try
            {
                Cursor = Cursors.AppStarting;
                FactoryManger.Instance.Logoff();
                Cursor = Cursors.Default;
                OnDialedButtonPressed = null;
                OnCancelButtonPressed = null;
                OnOkButtonPressed = null;
                foreach (Control item in panelContianer.Controls)
                    item.Dispose();
                panelContianer.Controls.Clear();
                ShowPanelContianerControl(-1);
            }
            catch { }
        }
        void RefreshGUI(IStateMachine state)
        {
            try
            {
                switch (state.StateId)
                {
                    case EStateId.NULL:
                        FactoryManger.Instance.PlayTone(ETones.EToneCongestion);
                        FactoryManger.Instance.RequestGetBalance();//get Balance when call finished
                        notifyIcon.Tag = null;
                        notifyIcon.ShowBalloonTip(30, Settings.Default.ProgramName, "Call was Terminated!", ToolTipIcon.Info);
                        CCallManager.Instance.OnUserStopRecording(state.Session);
                        break;
                }
                btnLogoff.Enabled = CCallManager.Instance.Count == 0;
                int count = CCallManager.Instance[s => s.StateId == EStateId.ACTIVE || s.StateId == EStateId.ALERTING || s.StateId == EStateId.HOLDING || s.StateId == EStateId.INCOMING].Count;
                //if ( count> 1)
                //    ShowPanelContianerControl(3);
                //else
                if (count == 0)
                {
                    if (IsShownControl<ctrDialer>())
                        ShowPanelContianerControl(0);
                }
                //this.Refresh();
            }
            catch { }
        }

        void login_OnSuccessLogin(Control control)
        {
            FactoryManger.Instance.SetCodec();

            control.Visible = false;
            btnLogoff.Enabled = CCallManager.Instance.Count < 1;

            ctrKeyPad1.Enabled = ctrButtonBack.Enabled = ctrButtonMenu.Enabled = ctrButtonCancel.Enabled = ctrButtonAccept.Enabled = ctrButton1.Enabled = ctrButton2.Enabled = true;

            if (GetControl<ctrMainWindow>() == null)
                ShowPanelContianerControl(0);
            if (!Settings.Default.LoginUsers.Contains(PhoneConfig.Instance.Accounts[0].UserName))
                Settings.Default.LoginUsers.Add(PhoneConfig.Instance.Accounts[0].UserName);
            PhoneConfig.Instance.Save();

        }

        int ShownControlIndex { get; set; }


        public bool IsShownControl<T>()
        {
            try
            {
                return panelContianer.Controls[typeof(T).Name].Visible;
            }
            catch { return false; }
        }
        /// <summary>
        /// Get the control if was loaded or return null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetControl<T>() where T : Control, new()
        {
            try
            {
                return (T)panelContianer.Controls[typeof(T).Name];
            }
            catch { return null; }
        }
        /// <summary>
        /// Get the control if was loaded or return null
        /// </summary>
        /// <param name="controlIndex">
        /// -1 : login form
        /// 0 : Panel Main
        /// 1: ctrCallRecords
        /// 2: ctrPhoneBook
        /// 3: ctrDialer 
        /// 4: ctrSmsManager 
        /// 5: ctrMenu 
        /// 6: ctrAboat
        /// 7: ctrRemarkNotes
        /// 8:ctrRecordProperties
        /// 9:ctrPhoneUserEditor
        /// 10:ctrRemarkNoteEditor
        /// 11ctrMsgProperties
        /// 12:ctrSmsSender
        /// 13:ctrTransferCall
        /// 14:ctrSmsMenu
        /// </param>
        public Control GetControl(int controlIndex)
        {
            try
            {
                switch (controlIndex)
                {
                    case -1: return GetControl<ctrLogin>();
                    case 0: return GetControl<ctrMainWindow>();
                    case 1: return GetControl<ctrCallHistory>(); 
                    case 2: return GetControl<ctrPhoneBook>(); 
                    case 3: return GetControl<ctrDialer>(); 
                    case 4: return GetControl<ctrSmsManager>(); 
                    case 5: return GetControl<ctrMenu>(); 
                    case 6: return GetControl<ctrAbout>(); 
                    case 7: return GetControl<ctrRemarkNotes>(); 
                    case 8: return GetControl<ctrRecordProperties>(); 
                    case 9: return GetControl<ctrPhoneUserEditor>(); 
                    case 10: return GetControl<ctrRemarkNoteEditor>(); 
                    case 11: return GetControl<ctrMsgProperties>(); 
                    case 12: return GetControl<ctrSmsSender>(); 
                    case 13: return GetControl<ctrTransferCall>(); 
                    case 14: return GetControl<ctrSmsMenu>(); 
                    default: return null; ;
                }
            }
            catch { return null; }
        }

        /// <summary>
        /// Return True is control shown
        /// </summary>
        /// <param name="controlIndex">
        /// -1 : login form
        /// 0 : Panel Main
        /// 1: ctrCallRecords
        /// 2: ctrPhoneBook
        /// 3: ctrDialer 
        /// 4: ctrSmsManager 
        /// 5: ctrMenu 
        /// 6: ctrAboat
        /// 7: ctrRemarkNotes
        /// 8:ctrRecordProperties
        /// 9:ctrPhoneUserEditor
        /// 10:ctrRemarkNoteEditor
        /// 11ctrMsgProperties
        /// 12:ctrSmsSender
        /// 13:ctrTransferCall
        /// 14:ctrSmsMenu
        /// </param>
        public bool ShowPanelContianerControl(int controlIndex)
        {
            if (controlIndex == 3 && CCallManager.Instance.Count == 0)
                return false;
            switch (controlIndex)
            {
                case -1:
                    ShowPanelContianerControl<ctrLogin>();
                    GetControl<ctrLogin>().textBox5.Text = "";
                    GetControl<ctrLogin>().OnSuccessLogin -= login_OnSuccessLogin;
                    GetControl<ctrLogin>().OnSuccessLogin += login_OnSuccessLogin;
                    btnLogoff.Enabled = false;
                    ctrKeyPad1.Enabled = ctrButtonBack.Enabled = ctrButtonMenu.Enabled = ctrButtonCancel.Enabled = ctrButtonAccept.Enabled = ctrButton1.Enabled = ctrButton2.Enabled = false;
                    break;
                case 0: ShowPanelContianerControl<ctrMainWindow>();
                    ShownControlIndex = -1;
                    StackShownIndex.Clear();
                    break;
                case 1: ShowPanelContianerControl<ctrCallHistory>(); break;
                case 2: ShowPanelContianerControl<ctrPhoneBook>(); break;
                case 3: ShowPanelContianerControl<ctrDialer>(); break;
                case 4: ShowPanelContianerControl<ctrSmsManager>(); break;
                case 5: ShowPanelContianerControl<ctrMenu>(); break;
                case 6: ShowPanelContianerControl<ctrAbout>(); break;
                case 7: ShowPanelContianerControl<ctrRemarkNotes>(); break;
                case 8: ShowPanelContianerControl<ctrRecordProperties>(); break;
                case 9: ShowPanelContianerControl<ctrPhoneUserEditor>(); break;
                case 10: ShowPanelContianerControl<ctrRemarkNoteEditor>(); break;
                case 11: ShowPanelContianerControl<ctrMsgProperties>(); break;
                case 12: ShowPanelContianerControl<ctrSmsSender>(); break;
                case 13: ShowPanelContianerControl<ctrTransferCall>(); break;
                case 14: ShowPanelContianerControl<ctrSmsMenu>(); break;
                default: return false;
            }
            try
            {
                if (StackShownIndex.Count == 0 || ShownControlIndex != StackShownIndex.Peek())
                    if (ShownControlIndex != -1)
                        StackShownIndex.Push(ShownControlIndex);
                ShowMenuOrBackButton(controlIndex == 0 || controlIndex == -1);
            }
            catch { }
            ShownControlIndex = controlIndex;
            return true;
        }

        void ShowMenuOrBackButton(bool showMenu)
        {
            ctrButtonBack.Visible = !showMenu;
            ctrButtonMenu.Visible = showMenu;
        }
        /// <summary>
        /// Hide All Controls and show the control has this T type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool ShowPanelContianerControl<T>() where T : Control, new()
        {
            string Name = typeof(T).Name;
            foreach (Control item in panelContianer.Controls)//HidePanelContianerControls
                if (item.GetType() != typeof(T)) item.Visible = false;
            Control con;
            bool addedBefore = panelContianer.Controls.ContainsKey(Name);
           // MessageBox.Show(addedBefore + "");
            if (addedBefore) con = panelContianer.Controls[Name];
            else
            {
                con = new T();
                con.Dock = DockStyle.Fill;
                RegisterMouseDown(con);
                panelContianer.Controls.Add(con);
                con.Name = Name;
            }
            con.Visible = true;
            con.Focus();
            return addedBefore;
        }

        public void RegisterMouseDown(Control control)
        {
            foreach (Control child in control.Controls)
                RegisterMouseDown(child);

            if (control is LinkLabel) return;
            if (control is TrackBar) return;
            if (control is MonthCalendar) return;
            if (control is ctrButton) return;
            if (control is ButtonBase) return;
            if (control is TextBoxBase) return;
            if (control is ListControl) return;
            if (control is ListView) return;
            if (control is PictureBox) return;

            control.MouseDown += new MouseEventHandler(MainForm.Instance.MainForm_MouseDown);
        }

        public void MainForm_MouseDown(object sender, MouseEventArgs e)
        {


            ((Control)sender).Capture = false;
            this.Capture = false;
            Message msg = new Message();
            msg.HWnd = this.Handle;
            msg.Msg = 0x112;
            msg.WParam = new IntPtr(0xF012);
            WndProc(ref msg);
        }

        #endregion

        public event OnDialedButtonPressed OnDialedButtonPressed, OnOkButtonPressed;
        public event OnCancelButtonPressed OnCancelButtonPressed;
        private void ctrButton2_Click(object sender, EventArgs e)
        {
            if (OnDialedButtonPressed != null) OnDialedButtonPressed();
        }

        private void ctrButton2_Click_1(object sender, EventArgs e)
        {
            if (OnOkButtonPressed != null) OnOkButtonPressed();
        }

        private void ctrButton3_Click(object sender, EventArgs e)
        {
            if (OnCancelButtonPressed != null) OnCancelButtonPressed();
        }

        private void ctrButtonMenu_Click(object sender, EventArgs e)
        {
            ShowPanelContianerControl(5);
        }

        private void ctrButtonBack_Click(object sender, EventArgs e)
        {
            GotoBack();
        }
        /// <summary>
        /// Go to last viewer control
        /// </summary>
        public void GotoBack()
        {
            try
            {
                //if (IsShownControl<ctrMainWindow>()) return;
                if (StackShownIndex.Count > 0)
                {
                    Control con = GetControl(ShownControlIndex);
                    if (con != null)
                    {
                        panelContianer.Controls.Remove(con);
                        con.Dispose();
                    }
                    ShowPanelContianerControl(StackShownIndex.Pop());
                    StackShownIndex.Pop();
                }
                if (ShownControlIndex != 0 && StackShownIndex.Count == 0)
                {
                    ShowPanelContianerControl(0);
                }
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(CCallManager.Instance[EStateId.ACTIVE][0].Codec);
            }
            catch { }
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {

            switch (((Button)sender).Tag + "")
            {
                case "0": ExitApplication(); break;
                case "1": Hide(); break;
                case "2": LogOff(); break;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://www.nogafone.com/advertise.php");
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {

            //switch (e.KeyData)
            //{
            //    case Keys.Enter: points.Add(PointToClient(MousePosition)); break;
            //    case Keys.Left: Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y); break;
            //    case Keys.Right: Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y); break;
            //    case Keys.Up: Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 1); break;
            //    case Keys.Down: Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 1); break;
            //}
            //string s = "";
            //foreach (Point p in points)
            //{
            //    s += "points.Add(new Point(" + p.X + "," + p.Y + "));";
            //}
        }



        private void ctrButton1_Click(object sender, EventArgs e)
        {
            GotoBack();
        }






    }
}


