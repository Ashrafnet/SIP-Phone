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
using SIPProvider.CallRecords;
using Softphone.SmsFolder;


namespace Softphone.PhoneBookFace
{
    public partial class ctrPhoneBook : UserControl
    {
        public ctrPhoneBook()
        {
            InitializeComponent();
            //register phone book events
            PhoneBook.Instance.OnUserAdded += Instance_OnUserAdded;
            PhoneBook.Instance.OnUserRemoved += Instance_OnUserRemoved;
            PhoneBook.Instance.OnUserEdited += user_OnDataChanged;
            this.GotFocus += ctrPhoneBook_GotFocus;
            MainForm.Instance.OnDialedButtonPressed += Instance_OnDialedButtonPressed;
            MainForm.Instance.OnOkButtonPressed += Instance_OnOkButtonPressed;

            //Use column key as the same of phone user data name
            comparableListView1.Columns.Add(PhoneUserDataNames.UserName, "Name");
            comparableListView1.Columns.Add(PhoneUserDataNames.UserNumber, "Number");

            comparableListView1.SetSortedColumn(0, SortOrder.Ascending);

         
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            PhoneBook.Instance.OnUserAdded -= Instance_OnUserAdded;
            PhoneBook.Instance.OnUserRemoved -= Instance_OnUserRemoved;
            PhoneBook.Instance.OnUserEdited -= user_OnDataChanged;
            this.GotFocus -= ctrPhoneBook_GotFocus;
            MainForm.Instance.OnDialedButtonPressed -= Instance_OnDialedButtonPressed;
            MainForm.Instance.OnOkButtonPressed -= Instance_OnOkButtonPressed;

            base.OnHandleDestroyed(e);
        }

        void Instance_OnOkButtonPressed()
        {
            if (!MainForm.Instance.IsShownControl<ctrPhoneBook>()) return;
            if (SelectionOnly)
            {
                if (CalledWhenSelected != null) CalledWhenSelected(SelectedContacts);
                MainForm.Instance.GotoBack();
            }
        }
        public bool SelectionOnly
        {
            get
            {
                return comparableListView1.CheckBoxes;
            }
            set
            {
                comparableListView1.CheckBoxes = value;
                toolStrip1.Visible = !value;
                if (value)
                {
                    comparableListView1.Dock = DockStyle.None;
                    comparableListView1.Height = 180;
                }
                else comparableListView1.Dock = DockStyle.Fill;
            }
        }

        public List<string> SelectedContacts
        {
            get
            {
                List<string> x = new List<string>();
                foreach (ListViewItem item in comparableListView1.CheckedItems)
                {
                    PhoneUser user = PhoneBook.Instance.SearchOneUser(u => u.Id == long.Parse(item.Name));
                    if (user == null) continue;
                    x.Add(user.UserNumber);
                }
                return x;
            }
            set
            {
               // LoadMatchItems();
                foreach (string no in value) 
                {
                    PhoneUser user = PhoneBook.Instance.SearchOneUser(u => u.UserNumber == no);
                    if (user == null) continue;
                    ListViewItem item = comparableListView1.Items[user.Id+""];
                    if (item == null) continue;
                    item.Checked = true;
                    comparableListView1.EnsureVisible(item.Index);
                }
            }
        }
        void ctrPhoneBook_GotFocus(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        #region Events methods
        void Instance_OnDialedButtonPressed()
        {
            if (!MainForm.Instance.IsShownControl<ctrPhoneBook>()) return;
            if (!SelectionOnly)
                CreateCall();
        }
        void Instance_OnUserRemoved(object sender)
        {
            try
            {
                PhoneUser user = (PhoneUser)sender;
                comparableListView1.Items.RemoveByKey(user.Id + "");
            }
            catch { }
        }

        void Instance_OnUserAdded(object sender)
        {
            try
            {
                PhoneUser user = (PhoneUser)sender;
                ListViewItem item = UserToListViewItem(user);
                if (!comparableListView1.Items.Contains(item))
                    comparableListView1.Items.Add(item);
                comparableListView1.UnSelectAll();
                item.Selected = true;
            }
            catch { }
        }


        void user_OnDataChanged(object sender, DataChangeEventArgs e)
        {
            try
            {
                PhoneUser user = (PhoneUser)sender;
                ListViewItem Item = comparableListView1.Items[user.Id + ""];
                if (Item == null) return;
                //comparableListView1.Columns has key as dataName
                int subItemIndex = comparableListView1.Columns[e.DataName].Index;
                string newValue = e.NewValue is DateTime ? ((DateTime)e.NewValue).ToString(Settings.Default.DateTimeFormat) + "" : e.NewValue + "";
                Item.SubItems[subItemIndex].Text = newValue;
            }
            catch { }
        }


        private void ctrPhoneBook_Load(object sender, EventArgs e)
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
            PhoneBook.Instance.OnUserAdded -= new SIPProvider.SIPCore.ItemAdded(Instance_OnUserAdded);
            PhoneBook.Instance.OnUserRemoved -= new SIPProvider.SIPCore.ItemRemoved(Instance_OnUserRemoved);
            PhoneBook.Instance.OnUserEdited -= new SIPProvider.SIPCore.DataChanged(user_OnDataChanged);
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (SelectionOnly) { e.Cancel = true; return; }
            removeToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count > 0;
            sendSmsToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripSeparator1.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripSeparator2.Visible = comparableListView1.SelectedItems.Count == 1;
            editUserToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;
            callToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;

            if (comparableListView1.SelectedItems.Count > 0)
                callToolStripMenuItem.Text = "Call " + comparableListView1.SelectedItems[0].Text;
        }



        private void comparableListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectionOnly) return;
            CreateCall();
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
                case 0: AddUser(); break;
                case 1: RemoveUsers(); break;
                case 2: EditUser(); break;
                case 3: RefreshList(); break;
                case 4: CreateCall(); break;
                case 5: AddMsg(); break;
            }
        }
        private void comparableListView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: RemoveUsers(); break;
                case Keys.F2: EditUser(); break;
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
                PhoneUser user1 = PhoneBook.Instance.GetUserById(long.Parse(item1.Name));
                PhoneUser user2 = PhoneBook.Instance.GetUserById(long.Parse(item2.Name));
                string colName = comparableListView1.Columns[columnIndex].Name;
                switch (colName)
                {
                    case PhoneUserDataNames.UserName: return user1.UserName.CompareTo(user2.UserName);
                    case PhoneUserDataNames.UserNumber: return user1.UserNumber.CompareTo(user2.UserNumber);
                    case PhoneUserDataNames.UserEmail: return user1.UserEmail.CompareTo(user2.UserEmail);
                    case PhoneUserDataNames.RegisterTime: return user1.RegisterTime.CompareTo(user2.RegisterTime);
                    case PhoneUserDataNames.UserAddress: return user1.UserAddress.CompareTo(user2.UserAddress);
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

        //private void AutoSizeColumns()
        //{
        //    foreach (ColumnHeader item in comparableListView1.Columns)
        //    {
        //        item.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        //        if(item.Width<item.Text.Length>5)
        //    }
        //}

        private void LoadMatchItems()
        {
            LoadItems(PhoneBook.Instance.SearchUsers(IsMatchSearch));
            
            comparableListView1_SelectedIndexChanged(null, null);
        }
        private bool IsMatchSearch(PhoneUser user)
        {
            string search=textBoxSearch.Text;
            return user.UserName.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                   user.UserNumber.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        private void LoadItems(List<PhoneUser> users)
        {
            try
            {
                for (int i = 0; i < comparableListView1.Items.Count; i++)
                {
                    ListViewItem itm = comparableListView1.Items[i];
                    PhoneUser user = users.Find(u => u.Id == long.Parse(itm.Name));
                    if (user != null)//User found so , Continuo to next item
                        continue;
                    else//user not found So, remove this user from list
                    {
                        comparableListView1.Items.RemoveAt(i);
                        i--;
                    }
                }
                List<ListViewItem> newItems = new List<ListViewItem>();
                foreach (PhoneUser user in users)
                {
                    if (comparableListView1.Items.ContainsKey(user.Id + ""))//User loaded before this time  so , Continuo to next item
                        continue;
                    else//user not loaded So, load this user to list
                        newItems.Add(UserToListViewItem(user));
                }
                comparableListView1.Items.AddRange(newItems.ToArray());
                if (comparableListView1.Items.Count > 0) comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                else comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch { }
        }


        private ListViewItem UserToListViewItem(PhoneUser user)
        {
            ListViewItem item = comparableListView1.Items[user.Id + ""];
            if (item != null) return item;//the item found in list
            string[] subItems = {   user.UserName,
                                    user.UserNumber,
                                    //user.UserEmail,
                                    //user.RegisterTime.ToString(Settings.Default.DateTimeFormat), 
                                    //user.UserAddress
                                };
             item = new ListViewItem(subItems);
            item.ImageIndex = 0;
            item.Name = user.Id + "";
            return item;
        }


        private void AddUser()
        {
            if (MainForm.Instance.ShowPanelContianerControl(9))
                MainForm.Instance.GetControl<ctrPhoneUserEditor>().SetData("","","","");
        }

        private void RemoveUsers()
        {
            if (comparableListView1.SelectedItems.Count == 0) return;
            DialogResult result = MessageBox.Show("remove All Selected users?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            List<long> ids = new List<long>();
            foreach (ListViewItem item in comparableListView1.SelectedItems)
                ids.Add(long.Parse(item.Name));
            PhoneBook.Instance.DeleteUser(ids.ToArray());
        }

        private void EditUser()
        {
            if (comparableListView1.SelectedItems.Count != 1) return;
            ListViewItem item = comparableListView1.SelectedItems[0];
            PhoneUser user = PhoneBook.Instance.GetUserById(long.Parse(item.Name));
            if (MainForm.Instance.ShowPanelContianerControl(9))
                MainForm.Instance.GetControl<ctrPhoneUserEditor>().SetData(user);
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
            PhoneUser user = PhoneBook.Instance.GetUserById(long.Parse(item.Name));
            FactoryManger.Instance.CreateCall(user.UserNumber);
        }

        private void AddMsg()
        {
            string no = "";
            foreach (ListViewItem Item in comparableListView1.SelectedItems)
            {
                PhoneUser user = PhoneBook.Instance.GetUserById(long.Parse(Item.Name));
                if (no.Contains(user.UserNumber)) continue;
                no += user.UserNumber + ",";
                break;//Sine the server not accept more one no
            }
            no = no.TrimEnd(',');


            if (MainForm.Instance.ShowPanelContianerControl(12))
                MainForm.Instance.GetControl<ctrSmsSender>().SetData(no);
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
            toolStripButtonSendSms.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripButtonRemove.Visible = comparableListView1.SelectedItems.Count > 0;
            toolStripButtonProperties.Visible = comparableListView1.SelectedItems.Count == 1;
            toolStripSeparator3.Visible = comparableListView1.SelectedItems.Count == 1;

            if (comparableListView1.SelectedItems.Count > 0)
                toolStripButtonCall.Text = "Call " + comparableListView1.SelectedItems[0].Text;
        }
        private OnPhonebookSelectedContacts CalledWhenSelected;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whenDone">It will be called when selected contacts done</param>
        public void SetSelectionMode(OnPhonebookSelectedContacts CalledWhenSelected, List<string> initialSelected)
        {
            SelectionOnly = true;
            SelectedContacts = initialSelected;
            this.CalledWhenSelected = CalledWhenSelected;
        }

        private void ctrButtonCancel_Click(object sender, EventArgs e)
        {
            MainForm.Instance.GotoBack();
        }

        private void toolStripButtonRefresh_MouseEnter(object sender, EventArgs e)
        {
            toolStripButtonRefresh.ToolTipText = " Reload Contacts (F5) - " + comparableListView1.Items.Count;
        }
    }
}
