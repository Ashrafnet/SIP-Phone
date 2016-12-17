using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SIPProvider.PhoneBookSaver;
using Softphone.SettingFolder;
using SIPProvider.CallRecords ;
using SIPProvider.SIPCore;
using Softphone.PhoneBookFace;
using SIPProvider;
using Softphone.Properties;
using Softphone.SmsFolder;


namespace Softphone.CallHistory
{
    public partial class ctrCallHistory : UserControl
    {
        private ECallType _CallType;
        public ECallType CallType
        {
            get { return _CallType; }
            set
            {
                _CallType = value;
                comparableListView1.Items.Clear();
                LoadMatchItems();
                textBoxSearch.Focus();
                
                switch (value)
                {
                    case ECallType.EDialed:
                        ctrTitle1.Title = "Dialed Calls";
                        ctrTitle1.Image = Resources.Called;
                        break;
                    case ECallType.EMissed:
                        ctrTitle1.Title = "Missed Calls";
                        ctrTitle1.Image = Resources.missed;
                        break;
                    case ECallType.EReceived:
                        ctrTitle1.Title = "Received Calls";
                        ctrTitle1.Image = Resources.incomingcall;
                        break;
                }
            }
        }

        public ctrCallHistory()
        {
            InitializeComponent();
            //register Call Loger events
            CallLoger.Instance.OnRecordAdded += Instance_OnRecordAdded;
            CallLoger.Instance.OnRecordRemoved += Instance_OnUserRemoved;
            CallLoger.Instance.OnRecordEdited += user_OnDataChanged;
            this.GotFocus += ctrCallRecords_GotFocus;
            MainForm.Instance.OnDialedButtonPressed += Instance_OnDialedButtonPressed;

            //Use column key as the same of phone user data name
            comparableListView1.Columns.Add(CallRecordDataNames.Name, "Contact"); 
            comparableListView1.Columns.Add(CallRecordDataNames.Time, "Calling Time");

            imageList1.Images.Add(ECallType.EDialed.ToString(), Resources.Called);
            imageList1.Images.Add(ECallType.EMissed.ToString(), Resources.missed);
            imageList1.Images.Add(ECallType.EReceived.ToString(), Resources.incomingcall);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister Call Loger events
            CallLoger.Instance.OnRecordAdded -= Instance_OnRecordAdded;
            CallLoger.Instance.OnRecordRemoved -= Instance_OnUserRemoved;
            CallLoger.Instance.OnRecordEdited -= user_OnDataChanged;
            this.GotFocus -= ctrCallRecords_GotFocus;
            MainForm.Instance.OnDialedButtonPressed -= Instance_OnDialedButtonPressed;
            base.OnHandleDestroyed(e);
        }
        #region Events methods
        void Instance_OnDialedButtonPressed()
        {
            if (MainForm.Instance.IsShownControl<ctrCallHistory>())
                CreateCall();
        }
        void ctrCallRecords_GotFocus(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        void Instance_OnUserRemoved(object sender)
        {
            try
            {
                CCallRecord record = (CCallRecord)sender;
                comparableListView1.Items.RemoveByKey(record.Id + "");
            }
            catch { }
        }

        void Instance_OnRecordAdded(object sender)
        {
            try
            {
                CCallRecord record = (CCallRecord)sender;
                if (record.Type != CallType) return;
                ListViewItem item = RecordToListViewItem(record);
                if (!comparableListView1.Items.Contains(item))
                    comparableListView1.Items.Insert(0, item);
                comparableListView1.UnSelectAll();
                item.Selected = true;
            }
            catch { }
        }


        void user_OnDataChanged(object sender, DataChangeEventArgs e)
        {
            try
            {
                CCallRecord record = (CCallRecord)sender;
                ListViewItem Item = comparableListView1.Items[record.Id + ""];
                if (Item == null) return;
                //comparableListView1.Columns has key as dataName
                int subItemIndex = comparableListView1.Columns[e.DataName].Index;
                string newValue = e.NewValue is DateTime ? ((DateTime)e.NewValue).ToString(Settings.Default.DateTimeFormat) + "" : e.NewValue + "";
                Item.SubItems[subItemIndex].Text = newValue;
            }
            catch { }
        }


        private void ctrCallLoger_Load(object sender, EventArgs e)
        {
            LoadMatchItems();
            Form owner = FindForm();
            if (owner == null) return;
            owner.FormClosed += new FormClosedEventHandler(owner_FormClosed);
            textBoxSearch.Focus();
        }

        void owner_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Un register phone book events
            CallLoger.Instance.OnRecordAdded -= new SIPProvider.SIPCore.ItemAdded(Instance_OnRecordAdded);
            CallLoger.Instance.OnRecordRemoved -= new SIPProvider.SIPCore.ItemRemoved(Instance_OnUserRemoved);
            CallLoger.Instance.OnRecordEdited -= new SIPProvider.SIPCore.DataChanged(user_OnDataChanged);
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (comparableListView1.SelectedItems.Count == 0) { e.Cancel = true; return; }
            removeToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count > 0;
            editUserToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;
            addToPhoneBookToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;
            callToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;
            sendSmsToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count ==1;
            if (comparableListView1.SelectedItems.Count > 0)
                callToolStripMenuItem.Text = "Call " + comparableListView1.SelectedItems[0].Text;

            toolStripSeparator2.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripSeparator1.Visible = comparableListView1.SelectedItems.Count == 1;
        }



        private void comparableListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CreateCall();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Hide();
            int tag;
            if (!int.TryParse(e.ClickedItem.Tag + "", out tag)) return;
            switch (tag)
            {
                case 0: AddToPhoneBook(); break;
                case 1: RemoveRecords(); break;
                case 2: ViewCtrRecord(); break;
                case 3: RefreshList(); break;
                case 4: CreateCall(); break;
                case 5: AddMsg(); break;
            }
        }
        
        private void comparableListView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: RemoveRecords(); break;
                case Keys.F2: ViewCtrRecord(); break;
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1_ItemClicked(sender, e);

        }

        private int comparableListView1_OnSort(int columnIndex, ListViewItem item1, ListViewItem item2)
        {
            try
            {
                CCallRecord record1 = CallLoger.Instance.GetRecordById(long.Parse(item1.Name));
                CCallRecord record2 = CallLoger.Instance.GetRecordById(long.Parse(item2.Name));
                string colName = comparableListView1.Columns[columnIndex].Name;
                switch (colName)
                {
                    case CallRecordDataNames.Name: return record1.Name.CompareTo(record2.Name);
                    case CallRecordDataNames.Number: return record1.Number.CompareTo(record2.Number);
                    case CallRecordDataNames.Time: return record1.Time.CompareTo(record2.Time);
                    case CallRecordDataNames.Duration: return record1.Duration.CompareTo(record2.Duration);
                    default: return 0;
                }
            }
            catch { return 0; }
        }


        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) textBoxSearch.Text = "";
        }

        private void comparableListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButtonCall.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripButtonSendSms.Visible = comparableListView1.SelectedItems.Count ==1;
            toolStripButtonAdd.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripButtonRemove.Visible = comparableListView1.SelectedItems.Count > 0;
            toolStripButtonProperties.Visible = comparableListView1.SelectedItems.Count == 1;

            if (comparableListView1.SelectedItems.Count > 0)
                toolStripButtonCall.Text = "Call " + comparableListView1.SelectedItems[0].Text;

        }
        #endregion
        
      
        #region Privite Methods
       
        private void LoadMatchItems()
        {

            LoadItems(CallLoger.Instance.SearchList(CallType, IsMatchSearch));
            comparableListView1_SelectedIndexChanged(null, null);
        }
        private bool IsMatchSearch(CCallRecord record)
        {
            string search=textBoxSearch.Text;
            return record.Name.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                   record.Number.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        private void LoadItems(List<CCallRecord> records)
        {
            try
            {
                for (int i = 0; i < comparableListView1.Items.Count; i++)
                {
                    ListViewItem itm = comparableListView1.Items[i];
                    CCallRecord record = records.Find(u => u.Id == long.Parse(itm.Name));
                    if (record != null)//User found so , Continuo to next item
                        continue;
                    else//user not found So, remove this user from list
                    {
                        comparableListView1.Items.RemoveAt(i);
                        i--;
                    }
                }
                List<ListViewItem> newItems = new List<ListViewItem>();
                foreach (CCallRecord user in records)
                {
                    if (comparableListView1.Items.ContainsKey(user.Id + ""))//User loaded before this time  so , Continuo to next item
                        continue;
                    else//user not loaded So, load this user to list
                        newItems.Add(RecordToListViewItem(user));
                }
                comparableListView1.Items.AddRange(newItems.ToArray());
                if (comparableListView1.Items.Count > 0) comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                else comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch { }
        }

        private ListViewItem RecordToListViewItem(CCallRecord user)
        {
            ListViewItem item = comparableListView1.Items[user.Id + ""];
            if (item != null) return item;//the item found in list
            string[] subItems = {   user.Name,
                                    user.Time.ToString(Settings.Default.DateTimeFormat),
                                };
             item = new ListViewItem(subItems);
             item.ImageKey = CallType.ToString();
            item.Name = user.Id + "";
            return item;
        }

        private void AddToPhoneBook()
        {
            if (comparableListView1.SelectedItems.Count != 1) return;
            ListViewItem item = comparableListView1.SelectedItems[0];
            CCallRecord record = CallLoger.Instance.GetRecordById(long.Parse(item.Name));

            if (MainForm.Instance.ShowPanelContianerControl(9))
                MainForm.Instance.GetControl<ctrPhoneUserEditor>().SetData(record.Name, record.Number, "", "");
        }

        private void RemoveRecords()
        {
            if (comparableListView1.SelectedItems.Count == 0) return;
            DialogResult result = MessageBox.Show("remove All Selected Records?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);            
            if (result == DialogResult.No) return;
            List<long> ids = new List<long>();
            foreach (ListViewItem item in comparableListView1.SelectedItems)
                ids.Add(long.Parse(item.Name));
                CallLoger.Instance.deleteRecord(ids.ToArray());
        }

        private void ViewCtrRecord()
        {
            if (comparableListView1.SelectedItems.Count != 1) return;
            ListViewItem item = comparableListView1.SelectedItems[0];
            CCallRecord record = CallLoger.Instance.GetRecordById(long.Parse(item.Name));
            if (MainForm.Instance.ShowPanelContianerControl(8))
                MainForm.Instance.GetControl<ctrRecordProperties>().SetData(record);
        }
        private void RefreshList()
        {
            comparableListView1.Items.Clear();
            LoadMatchItems();
        }

        private void CreateCall()
        {
            if (comparableListView1.SelectedItems.Count != 1) return;
            ListViewItem item = comparableListView1.SelectedItems[0];
            CCallRecord record = CallLoger.Instance.GetRecordById(long.Parse(item.Name));
            FactoryManger.Instance.CreateCall(record.Number);
        }

        private void AddMsg()
        {
            string no = "";
            foreach (ListViewItem Item in comparableListView1.SelectedItems)
            {
                CCallRecord record = CallLoger.Instance.GetRecordById(long.Parse(Item.Name));
                if (no.Contains(record.Number)) continue;
                no += record.Number + ",";
                break;//Sine the server not accept more one no
            }
            no = no.TrimEnd(',');


            if (MainForm.Instance.ShowPanelContianerControl(12))
                MainForm.Instance.GetControl<ctrSmsSender>().SetData(no);
        }
        #endregion

        #region IPhoneControl Members

        public bool NeedOkCancel
        {
            get
            {
                return false;
            }
            set { }
        }

        #endregion

        private void toolStripButtonRefresh_MouseEnter(object sender, EventArgs e)
        {
            toolStripButtonRefresh.ToolTipText = " Reload Contacts (F5) - " + comparableListView1.Items.Count;
        }
    }
}
