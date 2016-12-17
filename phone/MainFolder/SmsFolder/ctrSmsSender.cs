using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Softphone.PhoneBookFace;
 

namespace Softphone.SmsFolder
{
    public partial class ctrSmsSender : UserControl
    {
        public ctrSmsSender()
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
            if (!MainForm.Instance.IsShownControl<ctrSmsSender>()) return;
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0) return;
            bool x = clsSMS.SendSmS(textBox1.Text, textBox2.Text);
            if (x)
            {
                FactoryManger.Instance.RequestGetBalance();
                //MessageBox.Show("Sending SMS was Succeeded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.Instance.GotoBack();
            }
            else MessageBox.Show("Error While Sending SMS.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetData(string to)
        {
            textBox1.Text = to;
            textBox2.Text = "";
        }

        public void SetNumbers(List<string> Nos)
        {
            if (Nos.Count == 0) return;
            string x = "";
            foreach (string no in Nos)
            {
                if (no == "" || x.Contains(no)) continue;
                x += no + ",";
            }
            textBox1.Text = x.TrimEnd(',');
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.Instance.ShowPanelContianerControl(2))
            {
                List<string> list = new List<string>(textBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                MainForm.Instance.GetControl<ctrPhoneBook>().SetSelectionMode(SetNumbers, list);
            }
        }
       
  

        private void ctrButtonCancel_Click(object sender, EventArgs e)
        {
            MainForm.Instance.GotoBack();
        }

        private void ctrSmsSender_Load(object sender, EventArgs e)
        {
           
        }
    }
}
