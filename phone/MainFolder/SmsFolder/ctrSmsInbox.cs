using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SIPProvider.PhoneBookSaver;
using Softphone.SettingFolder;
using SIPProvider;
using Softphone.PhoneBookFace;


namespace Softphone.SmsFolder
{
    public partial class ctrSmsManager : UserControl
    {
        public ctrSmsManager()
        {
            InitializeComponent();
            SmsMsgs.Instance.Container = this;
            this.GotFocus += ctrSmsManager_GotFocus;
            MainForm.Instance.OnDialedButtonPressed +=Instance_OnDialedButtonPressed;
            //Use column key as the same of Sms user data name
            comparableListView1.Columns.Add(MsgDataNames.Msg, "Subject",90);
            comparableListView1.Columns.Add(MsgDataNames.Subject, "From",70);

            comparableListView1.SetSortedColumn(0, SortOrder.Ascending);

            
           
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            SmsMsgs.Instance.Container = null;
            this.GotFocus -= ctrSmsManager_GotFocus;
            MainForm.Instance.OnDialedButtonPressed -= Instance_OnDialedButtonPressed;

            base.OnHandleDestroyed(e);
        }
        void ctrSmsManager_GotFocus(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        #region Events methods
        void Instance_OnDialedButtonPressed()
        {
            if (MainForm.Instance.IsShownControl<ctrSmsManager>())
                CreateCall();
        }

        private void ctrSmsManager_Load(object sender, EventArgs e)
        {
            SmsMsgs.Instance.OnDataLoaded += new DataLoaded(Instance_OnDataLoaded);
           // RefreshList();
            textBoxSearch.Focus();
        }

        void RefreshToolBar(bool loadingDataDone)
        {
            pictureBox1.Visible = !loadingDataDone;
            toolStripButtonRefresh.Visible = loadingDataDone;
            toolStripButtonStopLoading.Visible = !loadingDataDone;
        }

        void Instance_OnDataLoaded()
        {
            LoadMatchItems();
            RefreshToolBar(true);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            removeToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count > 0;
            toolStripSeparator1.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripSeparator2.Visible = comparableListView1.SelectedItems.Count == 1;
            editUserToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;
            callToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;
            sendSmsToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count <2;
            refreshToolStripMenuItem.Visible = toolStripButtonRefresh.Visible;
            if (comparableListView1.SelectedItems.Count > 0)
                callToolStripMenuItem.Text = "Call " + comparableListView1.SelectedItems[0].SubItems[1].Text;
        }




        private void comparableListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMsg();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Hide();
            int tag;
            if (!int.TryParse(e.ClickedItem.Tag + "", out tag)) return;
            ClickItemSwich(tag);
        }
        void ClickItemSwich(int ItemTagNo)
        {
            switch (ItemTagNo)
            {
                case 0: AddMsg(); break;
                case 1: RemoveMsgs(); break;
                case 2: ShowMsg(); break;
                case 3: RefreshList(); break;
                case 4: CreateCall(); break;
                case 5: StopLoading(); break;
            }
        }
       
        private void comparableListView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: RemoveMsgs(); break;
                case Keys.F2: ShowMsg(); break;
                case Keys.F5: RefreshList(); break;
            }
        }



        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Length > 0)
                buttonCancelSearch.Image = Softphone.Properties.Resources.delete_16x;
            else
                buttonCancelSearch.Image = Softphone.Properties.Resources.search;
            LoadMatchItems();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = ""; textBoxSearch.Focus();
        }

        private int comparableListView1_OnSort(int columnIndex, ListViewItem item1, ListViewItem item2)
        {
            try
            {
                SmsMsg user1 = SmsMsgs.Instance.GetMsgById(long.Parse(item1.Name));
                SmsMsg user2 = SmsMsgs.Instance.GetMsgById(long.Parse(item2.Name));
                string colName = comparableListView1.Columns[columnIndex].Name;
                switch (colName)
                {
                    case MsgDataNames.Subject: return user1.subject.CompareTo(user2.subject);
                    case MsgDataNames.Reads: return user1.Reads.CompareTo(user2.Reads);
                    default: return 0;
                }
            }
            catch { return 0; }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) textBoxSearch.Text = "";
        }
        #endregion

        #region Privite Methods

        public void SetSmsBookType(SMSBoxType type)
        {
            SmsMsgs.Instance.SMSBoxType = type;
            comparableListView1.Items.Clear();
            RefreshList();
            ctrTitle1.Title = type == SMSBoxType.Inbox ? "Inbox SMS" : "Outbox SMS";
        }
        #endregion

#region Privite Methods

        private void LoadMatchItems()
        {
            LoadItems(SmsMsgs.Instance.SearchMsgs(IsMatchSearch));
        }
        private bool IsMatchSearch(SmsMsg msg)
        {
            string search=textBoxSearch.Text;
bool result=
             msg.subject.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                   msg.Message.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) != -1;
            return result;
        }

        private void LoadItems(List<SmsMsg> msgs)
        {
            try
            {
                comparableListView1.Items.Clear();
                List<ListViewItem> newItems = new List<ListViewItem>();
                foreach (SmsMsg user in msgs)
                        newItems.Add(MsgToListViewItem(user));
                
                comparableListView1.Items.AddRange(newItems.ToArray());
                //if (comparableListView1.Items.Count > 0) comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                //else comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch { }
        }


        private ListViewItem MsgToListViewItem(SmsMsg msg)
        {
            ListViewItem item = comparableListView1.Items[msg.Id + ""];
            if (item != null) return item;//the item found in list
            int len = msg.Message.Length < 10 ? msg.Message.Length : 10;
            string[] subItems = {   msg.Message.Substring(0,len),
                                    msg.subject+"",
                                };
             item = new ListViewItem(subItems);
             item.ImageIndex = msg.Reads == 0 ? 0 : 1;
            item.Name = msg.Id + "";
            return item;
        }


        private void AddMsg()
        {
            string no = "";
            foreach (ListViewItem Item in comparableListView1.SelectedItems)
            {
                SmsMsg msg = SmsMsgs.Instance.GetMsgById(long.Parse(Item.Name));
                if (no.Contains(msg.subject)) continue;
                no += msg.subject + ",";
            }
            no = no.TrimEnd(',');
            if (MainForm.Instance.ShowPanelContianerControl(12))
                MainForm.Instance.GetControl<ctrSmsSender>().SetData(no);
        }

        private void RemoveMsgs()
        {
            if (comparableListView1.SelectedItems.Count == 0) return;
            DialogResult result = MessageBox.Show("Are you sure you want to remove this Message?", "Remove SMS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            List<string> msgs = new List<string>();
            foreach (ListViewItem item in comparableListView1.SelectedItems)
                msgs.Add(item.Name);
            if (SmsMsgs.Instance.DeleteMsg(msgs))
            {
                while (comparableListView1.SelectedItems.Count > 0)
                    comparableListView1.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Error while trying to delete messages.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMsg()
        {
            if (comparableListView1.SelectedItems.Count != 1) return;
            ListViewItem item = comparableListView1.SelectedItems[0];
            SmsMsg msg = SmsMsgs.Instance.GetMsgById(long.Parse(item.Name));
            if (MainForm.Instance.ShowPanelContianerControl(11))
                MainForm.Instance.GetControl<ctrMsgProperties>().SetData(msg);
        }

        private void RefreshList()
        {
            RefreshToolBar(false);
            SmsMsgs.Instance.RequestLoadMsgs();
        }

        private void CreateCall()
        {
            if (comparableListView1.SelectedItems.Count != 1) return;
            ListViewItem item = comparableListView1.SelectedItems[0];
            SmsMsg msg = SmsMsgs.Instance.GetMsgById(long.Parse(item.Name));
            FactoryManger.Instance.CreateCall(msg.subject);
        }
        void StopLoading()
        {
            SmsMsgs.Instance.StopLoading();
            RefreshToolBar(true);
        }
        #endregion
       
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int tag;
            if (!int.TryParse(e.ClickedItem.Tag + "", out tag)) return;
            ClickItemSwich(tag);
        }

        private void comparableListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButtonCall.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripButtonSendSms.Visible = comparableListView1.SelectedItems.Count <2;
            toolStripButtonRemove.Visible = comparableListView1.SelectedItems.Count > 0;
            toolStripButtonProperties.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripSeparator3.Visible = comparableListView1.SelectedItems.Count == 1;

            if (comparableListView1.SelectedItems.Count > 0)
                toolStripButtonCall.Text = "Call " + comparableListView1.SelectedItems[0].Text;
        }

        private void toolStripButtonRefresh_MouseEnter(object sender, EventArgs e)
        {
            toolStripButtonRefresh.ToolTipText = " Reload Messages (F5) - " + comparableListView1.Items.Count;
        }

    }
}
