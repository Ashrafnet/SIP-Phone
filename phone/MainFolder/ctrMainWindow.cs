using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;
using SIPProvider.Common;
using Softphone.SettingFolder;
using Softphone.ConfigFolder;
using SIPProvider.PhoneBookSaver;
using Softphone.CallHistory;
using Softphone.Properties;
using System.IO;
using SIPProvider.RemarkNotes;

namespace Softphone.MainFolder
{
    public partial class ctrMainWindow : UserControl
    {
        private DateTime RegTime; string LastNo = "";
        public ctrMainWindow()
        {
            InitializeComponent();

            lblMyNo.Text = "My No: " + PhoneConfig.Instance.Accounts[0].UserName;

            FactoryManger.Instance.OnBalanceLoad +=FactoryManger_OnBalanceLoad;
            FactoryManger.Instance.OnRegistrationUpdate += FactoryManger_OnRegistrationUpdate;
            FactoryManger.Instance.OnStateUpdate += FactoryManger_OnStateUpdate;
            FactoryManger.Instance.OnRegestering += Instance_OnRegestering;

            MainForm.Instance.KeyPress += Instance_KeyPress;
            MainForm.Instance.OnDialedButtonPressed += Instance_OnDialedButtonPressed;
            MainForm.Instance.OnCancelButtonPressed +=Instance_OnCancelButtonPressed;

            lblCallingNo.Text = "";
            RegTime = DateTime.Now;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            FactoryManger.Instance.AbortRequestGetBalance();
            FactoryManger.Instance.OnBalanceLoad -= FactoryManger_OnBalanceLoad;
            FactoryManger.Instance.OnRegistrationUpdate -= FactoryManger_OnRegistrationUpdate;
            FactoryManger.Instance.OnStateUpdate -= FactoryManger_OnStateUpdate;
            FactoryManger.Instance.OnRegestering -= Instance_OnRegestering;

            MainForm.Instance.KeyPress -= Instance_KeyPress;
            MainForm.Instance.OnDialedButtonPressed -= Instance_OnDialedButtonPressed;
            MainForm.Instance.OnCancelButtonPressed -= Instance_OnCancelButtonPressed;
            base.OnHandleDestroyed(e);
        }


        void Instance_OnCancelButtonPressed()
        {
            if (MainForm.Instance.IsShownControl<ctrMainWindow>())
            {
                List<IStateMachine> calls = FactoryManger.Instance.CallsCanRelease;
                if (calls.Count > 0)
                    FactoryManger.Instance.CallOperation("release", calls[calls.Count - 1]);
                else lblCallingNo.Tag = lblCallingNo.Text = "";
                MainForm.Instance.Cursor = Cursors.Default;
            }
            else MainForm.Instance.ShowPanelContianerControl(0);
        }

        void Instance_OnDialedButtonPressed()
        {
            if (!MainForm.Instance.IsShownControl<ctrMainWindow>()) return;
            List<IStateMachine> calls = CCallManager.Instance[EStateId.INCOMING];
            if (calls.Count > 0)
                FactoryManger.Instance.CallOperation("accept", calls[calls.Count - 1]);
            else if (lblCallingNo.Text.Length > 0) CreateCall();
            else
            {
               if( MainForm.Instance.ShowPanelContianerControl(1))
                   MainForm.Instance.GetControl<ctrCallHistory>().CallType = ECallType.EDialed;
            }
        }

        void Instance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!PhoneConfig.Instance.Accounts[0].IsLoggedin) return;
            if (e.KeyChar == 3) copyToolStripMenuItem.PerformClick();//copy
            else if (e.KeyChar == 22 && Clipboard.ContainsText() && CanWriteNumber()) pasteToolStripMenuItem.PerformClick();//paste
            else
            {
                if (MainForm.Instance.IsShownControl<ctrMainWindow>())//The user will right a number
                    try { KeyPad_OnKeypadPressed(e.KeyChar); }
                    catch { }
            }
        }


        #region Synhronized callbacks

        void Instance_OnRegestering()
        {
            lblCallStatus.Text = "Regestering...";
        }

        void FactoryManger_OnStateUpdate(int sessionId)
        {
            RefreshRecordButton();
            RefreshHoldButton();
            RefreshGUI(CCallManager.Instance[sessionId]);
        }

        void RefreshHoldButton()
        {
            try
            {
                IStateMachine state = CCallManager.Instance[(int)ctrButtonHold.Tag];
                switch (state.StateId)
                {
                    case EStateId.ACTIVE: ctrButtonHold.Image_Normal = Resources.hold2; break;
                    case EStateId.HOLDING: ctrButtonHold.Image_Normal = Resources.hold3; break;
                    case EStateId.NULL: ctrButtonHold.Image_Normal = Resources.hold1; break;
                }

            }
            catch { }
        }

        void RefreshRecordButton()
        {
            try
            {
                IStateMachine state = CCallManager.Instance[(int)ctrButtonRecord.Tag];
                if (state.StateId == EStateId.NULL)
                {
                    ctrButtonRecord.Image_Normal = Resources.record1;
                    picrecord.EnabelTimer = false;
                }

            }
            catch { }
        }

        void FactoryManger_OnRegistrationUpdate(int accountId, int accState)
        {
            pjsip_status_code status = (pjsip_status_code)accState;
            lblCallStatus.Text = EnumToString.GetRegisterStatus(status);
        }
        

        void FactoryManger_OnBalanceLoad(string Balance)
        {
            try
            {
                lblBalance.Text = Balance + "€";
                lblBalance.ForeColor = Color.FromArgb(24, 123, 222) ;
            }
            catch
            {
                lblBalance.ForeColor = Color.Red;
            }
        }



        #endregion

        public void CreateCall()
        {
            if (lblCallingNo.Tag == null) lblCallingNo.Tag = lblCallingNo.Text;
           
            FactoryManger.Instance.CreateCall(lblCallingNo.Tag.ToString() );
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            copyToolStripMenuItem.Visible = lblCallingNo.Text.Length > 0;
            pasteToolStripMenuItem.Visible = Clipboard.ContainsText() && CanWriteNumber();
            deleteToolStripMenuItem.Visible = CanWriteNumber() ;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Tag + "")
                {
                    case "0": Clipboard.SetText(lblCallingNo.Text); break;
                    case "1": lblCallingNo.Text += Clipboard.GetText();
                        lblCallingNo.Tag = lblCallingNo.Text;
                        break;
                    case "2": lblCallingNo.Text = ""; break;
                }
            }
            catch { }
        }

        void RefreshGUI(IStateMachine state)
        {
            try
            {
                switch (state.StateId)
                {
                    case EStateId.ALERTING: LastNo = state.CallingNumber; break;
                }
                int count = CCallManager.Instance[s => s.StateId == EStateId.ACTIVE || s.StateId == EStateId.ALERTING || s.StateId == EStateId.HOLDING || s.StateId == EStateId.INCOMING].Count;
                if (count == 0)
                {
                    lblCallingNo.Text = "";
                    lblCallingNo.Tag = "";
                }

                ctrButtonHold.Enabled = FactoryManger.Instance.CallsCanHold.Count > 0 || FactoryManger.Instance.CallsCanRetrieve.Count > 0;
                ctrButtonConference.Enabled = ctrButtonTransfer.Enabled = FactoryManger.Instance.CallsCanTransfer.Count > 0;
                ctrButtonRecord.Enabled = FactoryManger.Instance.CallsCanRecorded.Count > 0;
                
                lblCallStatus.Text = EnumToString.GetCallState(state.StateId) + PhoneBook.Instance.GetUserNameOrNumber(state.CallingNumber);

                IStateMachine callState = null;
                if (CCallManager.Instance[EStateId.ACTIVE].Count > 0)
                    callState = CCallManager.Instance[EStateId.ACTIVE][0];
                else if (CCallManager.Instance[EStateId.INCOMING].Count > 0)
                    callState = CCallManager.Instance[EStateId.INCOMING][0];
                else if (CCallManager.Instance[EStateId.ALERTING].Count > 0)
                    callState = CCallManager.Instance[EStateId.ALERTING][0];
                else if (CCallManager.Instance[EStateId.HOLDING].Count > 0)
                    callState = CCallManager.Instance[EStateId.HOLDING][0];

                if (callState != null) 
                 lblCallingNo.Text = PhoneBook.Instance.GetUserNameOrNumber(callState.CallingNumber);

                //if (CCallManager.Instance[EStateId.NULL].Count > 0)
                //    pictureBox1.Enabled  = lblCallingNo.Text.Length > 0;
                //else pictureBox1.Enabled = false;


            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (RegTime <= DateTime.Now.Subtract(new TimeSpan(0,0,PhoneConfig.Instance.Expires )))
            {
                RegTime = DateTime.Now;
                FactoryManger.Instance.Logoff();

            }
            lblDate.Text = DateTime.Now.ToString("ddd, MMM dd, yy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

            IStateMachine callState = null;
            if (CCallManager.Instance[EStateId.INCOMING].Count > 0)
                callState = CCallManager.Instance[EStateId.INCOMING][0];
            else if (CCallManager.Instance[EStateId.ALERTING].Count > 0)
                callState = CCallManager.Instance[EStateId.ALERTING][0];
            else if (CCallManager.Instance[EStateId.ACTIVE].Count > 0)
                callState = CCallManager.Instance[EStateId.ACTIVE][0];
            else if (CCallManager.Instance[EStateId.HOLDING].Count > 0)
                callState = CCallManager.Instance[EStateId.HOLDING][0];

            if (callState == null) lblCallStatus.Text = "Ready.";

            else if (callState.StateId == EStateId.ACTIVE)
            {
                IStateMachine state = CCallManager.Instance[EStateId.ACTIVE][0];
                lblCallStatus.Text = DateTime.Parse(state.RuntimeDuration.ToString()).ToString("mm:ss");
            }
            else lblCallStatus.Text = EnumToString.GetCallState(callState.StateId) + PhoneBook.Instance.GetUserNameOrNumber(callState.CallingNumber);
            
            RefreshHoldButton();
        }


       

       public void KeyPad_OnKeypadPressed(char keyPad)
        {
            List<IStateMachine> calls = CCallManager.Instance[EStateId.ACTIVE];
            if (calls.Count > 0)//Send keys to call
            {
                foreach (IStateMachine call in calls)
                    CCallManager.Instance.OnUserDialDigit(call.Session, keyPad + "", PhoneConfig.Instance.DtmfMode);
            }
            else if (!CanWriteNumber())
                return;
            else if (keyPad == 'c' || keyPad == 8)
            {
                if (lblCallingNo.Text.Length > 0) lblCallingNo.Text = lblCallingNo.Text.Substring(0, lblCallingNo.Text.Length - 1);
            }
            else if (keyPad >= 48 && keyPad < 58 || keyPad == '*' || keyPad == '#')
            {
                lblCallingNo.Text += keyPad + "";
                System.Media.SoundPlayer sx = new System.Media.SoundPlayer();
                sx.Stream = Softphone.Properties.Resources.ResourceManager.GetStream("dtmf_" + keyPad);
                sx.Play();
            }
            lblCallingNo.Tag = lblCallingNo.Text;
        }

       bool CanWriteNumber()
       {
           if (CCallManager.Instance[EStateId.ACTIVE].Count > 0) return false;
           if (CCallManager.Instance[EStateId.INCOMING].Count > 0) return false;
           if (CCallManager.Instance[EStateId.ALERTING].Count > 0) return false;
           return true;
       }

       private void lblCallingNo_TextChanged(object sender, EventArgs e)
       {
           //pictureBox1.Enabled = lblCallingNo.Text.Length > 0;
          // toolStripButtonAcceptCall.Visible = lblCallingNo.Text.Length > 0;
           //if (lblCallingNo.Text.Length > 15)
           //    lblCallingNo.Font = new System.Drawing.Font(lblCallingNo.Font, System.Drawing.FontStyle.Regular);
           //else
           //    lblCallingNo.Font = new System.Drawing.Font(lblCallingNo.Font, System.Drawing.FontStyle.Bold);
       }

       private void ctrButton1_Click(object sender, EventArgs e)
       {
           lblCallingNo.Text = "";
       }

 

       private void ctrMainWindow_Load(object sender, EventArgs e)
       {
           timer1_Tick(null, null);
           FactoryManger.Instance.RequestGetBalance();
       }
 

 

       private void ctrButton2_Click(object sender, EventArgs e)
       {
           try
           {
               IStateMachine tagState = CCallManager.Instance[(int)ctrButtonRecord.Tag];
               if (tagState.IsRecording)
               {
                   CCallManager.Instance.OnUserStopRecording(tagState.Session);
                   ctrButtonRecord.Image_Normal = Resources.record2;
                   picrecord.EnabelTimer = false;
                   ctrButtonRecord.Tag = null;
                   return;
               }
           }
           catch { }
           if (CCallManager.Instance[EStateId.ACTIVE].Count > 0)
           {
               IStateMachine s = (IStateMachine)CCallManager.Instance[EStateId.ACTIVE][0];
               ctrButtonRecord.Tag =s.Session;
               CCallManager.Instance.OnUserStartRecording(s.Session, GetRecordingPath(s));
               ctrButtonRecord.Image_Normal = Resources.record3;
               picrecord.EnabelTimer = true;
           }
       }

       private string GetRecordingPath(IStateMachine Session)
       {
           int i = 1;
           string path = Environment.CurrentDirectory + "\\Recorded\\";
           if(!Directory.Exists(path )) Directory.CreateDirectory(path);
           string filename = Session.CallingNumber + "_" + DateTime.Now.ToString("dd,MM,yy HH,mm")+".wav";
           filename = path + filename;
           chechFileexist:
           if (File.Exists(filename))
           {
               filename = filename + i;
               i+=1;
               goto chechFileexist;
           }
           return filename;
       }

       private void ctrButtonHold_Click(object sender, EventArgs e)
       {
           try
           {
               IStateMachine state;
               try
               {
                   if (int.Parse(ctrButtonHold.Tag + "") == CCallManager.Instance[EStateId.HOLDING][0].Session) state = CCallManager.Instance[EStateId.HOLDING][0];
                   else state = CCallManager.Instance[EStateId.ACTIVE][0];
               }
               catch { state = CCallManager.Instance[EStateId.ACTIVE][0]; }
               FactoryManger.Instance.CallOperation("hold", state);
               ctrButtonHold.Tag = state.Session;

           }
           catch { }

       }

       private void ctrButtonTransfer_Click(object sender, EventArgs e)
       {
           try
           {
               IStateMachine callState ;
               if (CCallManager.Instance[EStateId.INCOMING].Count > 0)
                   callState = CCallManager.Instance[EStateId.INCOMING][0];
               else if (CCallManager.Instance[EStateId.ACTIVE].Count > 0)
                   callState = CCallManager.Instance[EStateId.ACTIVE][0];
               else if (CCallManager.Instance[EStateId.HOLDING].Count > 0)
                   callState = CCallManager.Instance[EStateId.HOLDING][0];
               else return;
               if (MainForm.Instance.ShowPanelContianerControl(13))
                   MainForm.Instance.GetControl<ctrTransferCall>().SetData(callState);
           }
           catch { }
       }

       private void ctrButtonConference_Click(object sender, EventArgs e)
       {
           try
           {
               IStateMachine callState;
               if (CCallManager.Instance[EStateId.INCOMING].Count > 0)
                   callState = CCallManager.Instance[EStateId.INCOMING][0];
               else if (CCallManager.Instance[EStateId.ACTIVE].Count > 0)
                   callState = CCallManager.Instance[EStateId.ACTIVE][0];
               else if (CCallManager.Instance[EStateId.HOLDING].Count > 0)
                   callState = CCallManager.Instance[EStateId.HOLDING][0];
               else return;
               CCallManager.Instance.OnUserConference(callState.Session);
           }
           catch { }
       }

       private void pictureBox1_Click(object sender, EventArgs e)
       {
           
       }

       private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
       {
           ((PictureBox)sender).Location = new Point(((PictureBox)sender).Location.X, ((PictureBox)sender).Location.Y + 2);
       }

       private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
       {
           ((PictureBox)sender).Location = new Point(((PictureBox)sender).Location.X, ((PictureBox)sender).Location.Y - 2);
       }

       private void pictureBox3_Click(object sender, EventArgs e)
       {

           try
           {
               if (!CanWriteNumber()) return;
               switch (((PictureBox)sender).Tag + "")
               {
                   case "0":
                       
                       lblCallingNo.Text = lblCallingNo.Text.Substring(0, lblCallingNo.Text.Length-1);
                       break;
                   case "1":
                       lblCallingNo.Text = "";
                       break;
                   case "2":
                       FactoryManger.Instance.CreateCall(LastNo +"");
                       break;
               }
           }
           catch { }
       }

       private void ctrButtonConference_EnabledChanged(object sender, EventArgs e)
       {
           if (((ctrButton)sender).Enabled)
               ((ctrButton)sender).Image_Normal = Resources.conference2;
           else
               ((ctrButton)sender).Image_Normal = Resources.conference1;
       }

       private void ctrButtonConference_LocationChanged(object sender, EventArgs e)
       {

       }

       private void ctrButtonRecord_EnabledChanged(object sender, EventArgs e)
       {
           if (((ctrButton)sender).Enabled)
               ((ctrButton)sender).Image_Normal = Resources.record2;
           else
               ((ctrButton)sender).Image_Normal = Resources.record1 ;
       }

       private void ctrButtonTransfer_EnabledChanged(object sender, EventArgs e)
       {
           if (((ctrButton)sender).Enabled)
               ((ctrButton)sender).Image_Normal = Resources.transfer2 ;
           else
               ((ctrButton)sender).Image_Normal = Resources.transfer1 ;

       }

       private void ctrButtonHold_EnabledChanged(object sender, EventArgs e)
       {
           if (((ctrButton)sender).Enabled)
               ((ctrButton)sender).Image_Normal = Resources.hold2 ;
           else
               ((ctrButton)sender).Image_Normal = Resources.hold1 ;
       }



    }
}
