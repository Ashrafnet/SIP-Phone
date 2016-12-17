using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softphone.SettingFolder;
using Softphone.ConfigFolder;
using SIPProvider.SIPCore;
using SIPProvider.Common;

namespace Softphone
{
    public partial class ctrLogin : UserControl
    {
        /// <summary>
        /// Occurs When Success Login
        /// </summary>
        public event SuccessLogin OnSuccessLogin;
        public ctrLogin()
        {
            InitializeComponent();
            FactoryManger.Instance.OnRegistrationUpdate +=FactoryManger_OnRegistrationUpdate;
            FactoryManger.Instance.OnRegestering += Instance_OnRegestering;

            foreach (string x in Settings.Default.LoginUsers)
                textBox4.AutoCompleteCustomSource.Add(x);
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            FactoryManger.Instance.OnRegistrationUpdate -= FactoryManger_OnRegistrationUpdate;
            FactoryManger.Instance.OnRegestering -= Instance_OnRegestering;

            base.OnHandleDestroyed(e);
        }
        void Instance_OnRegestering()
        {
            lblstatus.Text = "Registering..";
        }

        public void SetLabelStatus(string txt)
        {
            lblstatus.Text = txt;
        }

        void FactoryManger_OnRegistrationUpdate(int accountId, int accState)
        {
            pjsip_status_code status = (pjsip_status_code)accState;
            lblstatus.Text = EnumToString.GetRegisterStatus(status);
            if (accState == 200 && OnSuccessLogin != null)
                OnSuccessLogin(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblstatus.Text = "Registering..";
            FactoryManger.Instance.Logoff();
            Application.DoEvents();
            Cursor = Cursors.WaitCursor;
            PhoneConfig.Instance.Accounts[0].UserName = textBox4.Text;
            PhoneConfig.Instance.Accounts[0].Password = textBox5.Text ;
            Settings.Default.RememberRegistration = checkBox1.Checked;
            Settings.Default.AutoLogin = checkBoxAutoLoginMe.Checked;
            FactoryManger.Instance.SetConfig();
            Cursor = Cursors.Default;
        }

        private void ctrLogin_Load(object sender, EventArgs e)
        {
            button1.Visible= Environment.CommandLine.ToLower().Contains("-advanced".ToLower());
            
            this.BackColor = Color.Transparent;
            foreach (Control item in this.Controls)
            {
                if (item is Label  )
                    ((Label)item).ForeColor  = Color.White;
                else if ( item is CheckBox )
                    ((CheckBox)item).ForeColor = Color.White;
            }
            checkBox1.Checked = Settings.Default.RememberRegistration;
            checkBoxAutoLoginMe.Checked = Settings.Default.AutoLogin;
            if (checkBox1.Checked)
            {
                textBox4.Text = PhoneConfig.Instance.Accounts[0].UserName;
                textBox5.Text = "******";
            }

        }

        public void SetMouseDownEvent(MouseEventHandler MouseDown)
        {
            this.MouseDown += MouseDown;
            
            lblstatus.MouseDown += MouseDown;
            label7.MouseDown += MouseDown;
            label8.MouseDown += MouseDown;
            lbltip .MouseDown += MouseDown;
            lblTootTip.MouseDown += MouseDown;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings x = new frmSettings();
            x.ShowDialog();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lblstatus_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = lblstatus.Text.EndsWith("..");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox1.Enabled  = !checkBoxAutoLoginMe.Checked;
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) button2_Click(null, null);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
