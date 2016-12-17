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
using SIPProvider.RemarkNotes;


namespace Softphone.RemarkNotesFace
{
    public partial class ctrRemarkNotes : UserControl
    {
        public ctrRemarkNotes()
        {
            InitializeComponent();
            //register phone book events
            RemarkNotes.Instance.OnItemAdded += Instance_OnItemAdded;
            RemarkNotes.Instance.OnItemRemoved += Instance_OnItemRemoved;
            RemarkNotes.Instance.OnItemEdited +=  item_OnDataChanged;
            this.GotFocus += ctrPhoneBook_GotFocus;
            //Use column key as the same of RemarkNote data name
            comparableListView1.Columns.Add(RemarkNoteDataNames.Text, "Text");
            comparableListView1.Columns.Add(RemarkNoteDataNames.Time, "Timer");
            comparableListView1.SetSortedColumn(1, SortOrder.Ascending);

        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            RemarkNotes.Instance.OnItemAdded -= Instance_OnItemAdded;
            RemarkNotes.Instance.OnItemRemoved -= Instance_OnItemRemoved;
            RemarkNotes.Instance.OnItemEdited -=  item_OnDataChanged;
            this.GotFocus -= ctrPhoneBook_GotFocus;

            base.OnHandleDestroyed(e);
        }
        void ctrPhoneBook_GotFocus(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
        }

        #region Events methods
       
        void Instance_OnItemRemoved(object sender)
        {
            try
            {
                RemarkNote item = (RemarkNote)sender;
                comparableListView1.Items.RemoveByKey(item.Id + "");
            }
            catch { }
        }

        void Instance_OnItemAdded(object sender)
        {
            try
            {
                RemarkNote x = (RemarkNote)sender;
                ListViewItem item = ItemToListViewItem(x);
                if (!comparableListView1.Items.Contains(item))
                    comparableListView1.Items.Add(item);
                comparableListView1.UnSelectAll();
                item.Selected = true;
            }
            catch { }
        }


        void item_OnDataChanged(object sender, DataChangeEventArgs e)
        {
            try
            {
                ItemToListViewItem((RemarkNote)sender);
            }
            catch { }
        }


        private void ctrPhoneBook_Load(object sender, EventArgs e)
        {
            LoadMatchItems();
            textBoxSearch.Focus();
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            removeToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count > 0;
            toolStripSeparator1.Visible = comparableListView1.SelectedItems.Count == 1;
            editUserToolStripMenuItem.Visible = comparableListView1.SelectedItems.Count == 1;

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
                case 0: AddItem(); break;
                case 1: RemoveItems(); break;
                case 2: EditItem(); break;
                case 3: RefreshList(); break;
            }
        }

        private void comparableListView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: RemoveItems(); break;
                case Keys.F2: EditItem(); break;
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

        private int comparableListView1_OnSort(int columnIndex, ListViewItem Item1, ListViewItem Item2)
        {
            try
            {
                RemarkNote item1 = RemarkNotes.Instance.GetItemById(long.Parse(Item1.Name));
                RemarkNote item2 = RemarkNotes.Instance.GetItemById(long.Parse(Item2.Name));
                
                string colName = comparableListView1.Columns[columnIndex].Name;
                switch (colName)
                {
                    case RemarkNoteDataNames.Text: return item1.Text.CompareTo(item2.Text);
                    case RemarkNoteDataNames.Time: return item1.Time.CompareTo(item2.Time);
                    default: return 0;
                }
            }
            catch { return 0; }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) textBoxSearch.Text = "";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int tag;
            if (!int.TryParse(e.ClickedItem.Tag + "", out tag)) return;
            ClickItemSwich(tag);
        }

        private void comparableListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButtonRemove.Visible = comparableListView1.SelectedItems.Count > 0;
            toolStripButtonProperties.Visible = comparableListView1.SelectedItems.Count == 1;

        }

        private void comparableListView1_DoubleClick(object sender, EventArgs e)
        {
            EditItem();
        }

        #endregion
        
      
        #region Privite Methods

        private void LoadMatchItems()
        {
            LoadItems(RemarkNotes.Instance.SearchItems(IsMatchSearch));
            
            comparableListView1_SelectedIndexChanged(null, null);
        }

        private bool IsMatchSearch(RemarkNote item)
        {
            string search=textBoxSearch.Text;
            return item.Text.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        private void LoadItems(List<RemarkNote> items)
        {
            try
            {
                for (int i = 0; i < comparableListView1.Items.Count; i++)
                {
                    ListViewItem itm = comparableListView1.Items[i];
                    RemarkNote item = items.Find(u => u.Id == long.Parse(itm.Name));
                    if (item != null)//Item found so , Continuo to next item
                        continue;
                    else//item not found So, remove this item from list
                    {
                        comparableListView1.Items.RemoveAt(i);
                        i--;
                    }
                }
                List<ListViewItem> newItems = new List<ListViewItem>();
                foreach (RemarkNote item in items)
                {
                    if (comparableListView1.Items.ContainsKey(item.Id + ""))//Item loaded before this time  so , Continuo to next item
                        continue;
                    else//item not loaded So, load this item to list
                        newItems.Add(ItemToListViewItem(item));
                }
                comparableListView1.Items.AddRange(newItems.ToArray());
                if (comparableListView1.Items.Count > 0) comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                else comparableListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch { }
        }


        private ListViewItem ItemToListViewItem(RemarkNote item)
        {
            ListViewItem Item = comparableListView1.Items[item.Id + ""];
            int len = item.Text.Length < 10 ? item.Text.Length : 10;
            string[] subItems = {   item.Text.Substring(0,len),
                                    item.Time.ToString(Settings.Default.DateTimeFormat),
                                };
            if (Item == null)
            {
                Item = new ListViewItem(subItems);
                Item.Name = item.Id + "";
            }
            else
            {
                Item.Text = subItems[0];
                Item.SubItems[1].Text = subItems[0];
            }
            if (!item.IsRead)
                Item.Font = new Font(Item.Font, FontStyle.Bold);
            else Item.Font = new Font(Item.Font, FontStyle.Regular);
            Item.ImageIndex = 0;
            return Item;
        }


        private void AddItem()
        {
            if (MainForm.Instance.ShowPanelContianerControl(10))
                MainForm.Instance.GetControl<ctrRemarkNoteEditor>().SetData("", "");
        }

        private void RemoveItems()
        {
            if (comparableListView1.SelectedItems.Count == 0) return;
            DialogResult result = MessageBox.Show("Are You sure you want to remove this items.", "Conferm Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            foreach (ListViewItem item in comparableListView1.SelectedItems)
                RemarkNotes.Instance.DeleteItem(long.Parse(item.Name));
        }

        private void EditItem()
        {
            if (comparableListView1.SelectedItems.Count != 1) return;
            ListViewItem Item = comparableListView1.SelectedItems[0];
            RemarkNote item = RemarkNotes.Instance.GetItemById(long.Parse(Item.Name));
            if (item.Time < DateTime.Now)
                item.IsRead = true;
            if (MainForm.Instance.ShowPanelContianerControl(10))
                MainForm.Instance.GetControl<ctrRemarkNoteEditor>().SetData(item);
        }

        private void RefreshList()
        {
            comparableListView1.Items.Clear();
            LoadMatchItems();
        }
        void RefreshImageIndex()
        {
            foreach (ListViewItem Item in comparableListView1.Items)
            {
                RemarkNote item = RemarkNotes.Instance.GetItemById(long.Parse(Item.Name));
                if (item.Time < DateTime.Now) Item.ImageIndex = 1;
                else Item.ImageIndex = 0;
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshImageIndex();
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

        private void toolStripButtonRefresh_MouseEnter(object sender, EventArgs e)
        {
            toolStripButtonRefresh.ToolTipText = " Reload Notes (F5) - " + comparableListView1.Items.Count;
        }
    }
}
