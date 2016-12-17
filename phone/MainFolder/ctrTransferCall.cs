using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIPProvider.SIPCore.Interfaces;
using Softphone.PhoneBookFace;

namespace Softphone.MainFolder
{
    public partial class ctrTransferCall : UserControl
    {
        IStateMachine state;
        public ctrTransferCall()
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
            FactoryManger.Instance.TransferCall(state, textBox1.Text);
            MainForm.Instance.GotoBack();
        }

        public void SetData(IStateMachine state)
        {
            this.state = state;
            labelFrom.Text = state.CallingNumber;
            textBox1.Text = "";
        }


        public void SetNumbers(List<string> Nos)
        {
            if (Nos.Count == 0) return;
            textBox1.Text = Nos[0];
        }

        private void buttonCancelSearch_Click(object sender, EventArgs e)
        {
            if (MainForm.Instance.ShowPanelContianerControl(2))
            {
                MainForm.Instance.GetControl<ctrPhoneBook>().SetSelectionMode(SetNumbers, new List<string>());
            }
        }

    }
}
