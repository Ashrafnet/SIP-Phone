using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIPProvider.PhoneBookSaver;

using Softphone.SettingFolder;
using SIPProvider.SIPCore;
using SIPProvider.CallRecords;


namespace Softphone.CallHistory
{
    public partial class ctrRecordProperties : UserControl
    {
        /// <summary>
        /// New instance for edit phoneUser
        /// </summary>
        /// <param name="PhoneUser">The PhoneUser to edit</param>
        public ctrRecordProperties()
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
            if (!MainForm.Instance.IsShownControl<ctrRecordProperties>()) return;
             MainForm.Instance.GotoBack();
        }

        public void SetData(CCallRecord CallRecord)
        {
            textBoxUserName.Text = CallRecord.Name;
            textBoxNumber.Text = CallRecord.Number;
            textBoxTime.Text = CallRecord.Time.ToString(Settings.Default.DateTimeFormat);
            textBoxType.Text = EnumToString.GetCallType(CallRecord.Type);
            textBoxDuration.Text = CallRecord.Duration + "";
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
    }
}
