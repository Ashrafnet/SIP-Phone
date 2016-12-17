using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIPProvider.PhoneBookSaver;


namespace Softphone.PhoneBookFace
{
    public partial class ctrPhoneUserEditor : UserControl
    {
        public PhoneUser PhoneUser { get; set; }
        /// <summary>
        /// New instance for create new phoneUser
        /// </summary>
        public ctrPhoneUserEditor()
        {
            InitializeComponent();
            MainForm.Instance.OnOkButtonPressed += Instance_OnOkButtonPressed;
            this.Text = "New Contact";
            ctrTitle1.Title  = "New Contact";           
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            MainForm.Instance.OnOkButtonPressed -= Instance_OnOkButtonPressed;
            base.OnHandleDestroyed(e);
        }
        void Instance_OnOkButtonPressed()
        {
            if (!MainForm.Instance.IsShownControl<ctrPhoneUserEditor>()) return;
            if (PhoneUser == null)//Add user
            {
                PhoneUser = PhoneBook.Instance.AddUser(textBoxUserName.Text,
                                            textBoxNumber.Text,
                                            DateTime.Now,
                                            textBoxAddress.Text,
                                           textBoxEmail.Text);
                if (PhoneUser == null)
                {
                    MessageBox.Show(PhoneBook.Instance.LastException.Message, "Failid Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else//Edit user
            {
                if (textBoxUserName.Text == "" || textBoxNumber.Text == "")
                {
                    MessageBox.Show("Can not Edit this user becouse UserName or UserNumber empty.", "Failid Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PhoneUser user = PhoneBook.Instance.GetUser(textBoxUserName.Text, textBoxNumber.Text);
                if (user != null && user.Id != PhoneUser.Id)
                {
                    MessageBox.Show("Can not Edit this user becouse UserName or UserNumber are repeated.", "Failid Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PhoneUser.UserName = textBoxUserName.Text;
                PhoneUser.UserNumber = textBoxNumber.Text;
                PhoneUser.UserEmail = textBoxEmail.Text;
                PhoneUser.UserAddress = textBoxAddress.Text;
            }
            MainForm.Instance.GotoBack();
        }
  
        public void SetData(PhoneUser PhoneUser)
        {
            ctrTitle1.Title = "Edit Contact";           
            this.Text = PhoneUser.UserName + " Properties.";
            this.PhoneUser = PhoneUser;
            if (PhoneUser == null) return;
            textBoxUserName.Text = PhoneUser.UserName;
            textBoxNumber.Text = PhoneUser.UserNumber;
            textBoxEmail.Text = PhoneUser.UserEmail;
            textBoxAddress.Text = PhoneUser.UserAddress;
        }
 
        public void SetData(string UserName, string UserNumber, string UserAddress, string UserEmail)
        {
            PhoneUser = null;
            ctrTitle1.Title = "New Contact";
            textBoxUserName.Text = UserName;
            textBoxNumber.Text = UserNumber;
            textBoxEmail.Text = UserEmail;
            textBoxAddress.Text = UserAddress;
        }


        private void ctrButtonCancel_Click(object sender, EventArgs e)
        {
            MainForm.Instance.GotoBack();
        }
    }
}
