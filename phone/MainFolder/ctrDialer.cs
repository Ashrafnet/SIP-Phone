using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SIPProvider.Common;
using SIPProvider.SIPCore;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.PhoneBookSaver;
using Softphone.Properties;

namespace Softphone
{
    public partial class ctrDialer : UserControl
    {
        public ctrDialer()
        {
            InitializeComponent();
            FactoryManger.Instance.OnStateUpdate += FactoryManger_OnStateUpdate;
            imageList1.Images.Add(EStateId.ACTIVE.ToString(), Resources.Accept);
            imageList1.Images.Add(EStateId.ALERTING.ToString(), Resources.Called);
            imageList1.Images.Add(EStateId.HOLDING.ToString(), Resources.hold);
            imageList1.Images.Add(EStateId.INCOMING.ToString(), Resources.incomingcall );
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            FactoryManger.Instance.OnStateUpdate -= FactoryManger_OnStateUpdate;

            base.OnHandleDestroyed(e);
        }
        private void ctrDialer_Load(object sender, EventArgs e)
        {
            UpdateCallLines();
            UpdateCallData();
        }

        void FactoryManger_OnStateUpdate(int sessionId)
        {
           
            //Update the listview call lines
            UpdateCallLines();
        }


        private void contextMenuStripCalls_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            if (listViewCallLines.SelectedItems.Count == 0) return;
            IStateMachine state = (CStateMachine)listViewCallLines.SelectedItems[0].Tag;
            FactoryManger.Instance.CallOperation(e.ClickedItem.Tag + "", state);
            UpdateCallLines();
        }

        private void contextMenuStripCalls_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (listViewCallLines.SelectedItems.Count == 0) { e.Cancel = true; return; }
                
                ListViewItem lvi = listViewCallLines.SelectedItems[0];
                EStateId stateId = ((CStateMachine)lvi.Tag).StateId;
                acceptToolStripMenuItem.Visible = stateId == EStateId.INCOMING;
                holdRetrieveToolStripMenuItem.Visible = stateId == EStateId.ACTIVE || stateId == EStateId.HOLDING;
                holdRetrieveToolStripMenuItem.Text = stateId == EStateId.ACTIVE ? "Hold Call" : "Retrieve Call";
                releaseToolStripMenuItem.Visible = true;
                releaseToolStripMenuItem.Text = "Release Call";
                transferCallToolStripMenuItem.Visible = stateId == EStateId.ACTIVE || stateId == EStateId.INCOMING;
            }
            catch { }
        }

        private void UpdateCallLines()
        {
            try
            {
                for (int i = 0; i < listViewCallLines.Items.Count; i++)
                {
                    ListViewItem item = listViewCallLines.Items[i];
                    if (CCallManager.Instance.CallList.ContainsValue((IStateMachine)item.Tag)) continue;
                    listViewCallLines.Items.RemoveAt(i); i--;
                }

                // get entire call list
                foreach (KeyValuePair<int, IStateMachine> kvp in CCallManager.Instance.CallList)
                    AddItem(kvp.Value);
                listViewCallLines.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);

            }
            catch { }
        }

        bool isExist(IStateMachine state)
        {
            foreach (ListViewItem item in listViewCallLines.Items)
            {
                if (item.Tag == state) return true;
            }
            return false;
        }

        ListViewItem AddItem(IStateMachine state)
        {
            foreach (ListViewItem item in listViewCallLines.Items)
                if (item.Tag == state) return item;

            string number = state.CallingNumber;
            PhoneUser user = PhoneBook.Instance.SearchOneUser(u => u.UserNumber.ToLower() == number.ToLower());
            if (user != null) number = user.UserName + " ( " + number + " )";
            string duration = state.Duration.ToString();
            string stateName = state.StateId.ToString();
            if (CCallManager.Instance.Is3Pty) stateName = "CONFERENCE";
            ListViewItem lvi = new ListViewItem(new string[] {
            stateName, number, duration});

            lvi.Tag = state;
            listViewCallLines.Items.Add(lvi);
            lvi.Selected = true;
            return lvi;
        } 

        private void UpdateCallData()
        {
            
            try
            {
                if (listViewCallLines.Items.Count == 0) return;

                for (int i = 0; i < listViewCallLines.Items.Count; i++)
                {
                    ListViewItem item = listViewCallLines.Items[i];
                    IStateMachine sm = (IStateMachine)item.Tag;
                    item.ImageKey = sm.StateId.ToString();
                    if (sm.IsNull) continue;
                    string stateName = sm.StateId.ToString();
                    if (CCallManager.Instance.Is3Pty) stateName = "CONFERENCE";
                    item.SubItems[0].Text = stateName;
                    item.SubItems[2].Text = DateTime.Parse(sm.RuntimeDuration.ToString()).ToString("mm:ss");
                }
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateCallLines();
            UpdateCallData();
        }

        void TransferCall()
        {
            try
            {
                if (listViewCallLines.SelectedItems.Count == 0) return;
                if (toolStripTextBoxTransferCall.Text == "") return;
                IStateMachine state = (CStateMachine)listViewCallLines.SelectedItems[0].Tag;
                CCallManager.Instance.OnUserTransfer(state.Session, toolStripTextBoxTransferCall.Text);
                UpdateCallLines();
            }
            catch { }
        }
        private void toolStripTextBoxTransferCall_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                contextMenuStripCalls.Hide();
                TransferCall();
            }
        }

      
    }
}
