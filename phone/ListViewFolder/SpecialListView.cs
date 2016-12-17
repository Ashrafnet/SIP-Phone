using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Softphone.ListViewFolder;

namespace Softphone.ListViewFolder
{
    public class SpecialListView : ListView
    {

        #region Sort list View

        /// <summary>
        /// Occurs when the sort begin
        /// </summary>
        public event SortListView OnSort;

        private ColumnHeader m_SortingColumn;

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = this.Columns[e.Column];

            // Figure out the new sorting order.
            SortOrder sort_order;
            if (m_SortingColumn == null)
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            else
            {
                // See if this is the same column.
                if (new_sorting_column.Equals(m_SortingColumn))
                {
                    // Same column. Switch the sort order.
                    if (m_SortingColumn.Text.StartsWith("> "))
                        sort_order = SortOrder.Descending;
                    else
                        sort_order = SortOrder.Ascending;
                }
                else
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;

                // Remove the old sort indicator.
                m_SortingColumn.Text = m_SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            m_SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
                m_SortingColumn.Text = "> " + m_SortingColumn.Text;
            else
                m_SortingColumn.Text = "< " + m_SortingColumn.Text;

            // Create a comparer.
            this.ListViewItemSorter = new ListViewComparer(e.Column, sort_order, ComparableListView_OnSort);

            // Sort.
            this.Sort();
        }

        int ComparableListView_OnSort(int columnIndex, ListViewItem item1, ListViewItem item2)
        {
            if (OnSort != null) return OnSort(columnIndex, item1, item2);
            else return 0;
        }

        #endregion

        #region Select UnSelect Items

        /// <summary>
        /// Sort the list for this columnIndex and SortOrder
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="SortOrder"></param>
        public void SetSortedColumn(int columnIndex, SortOrder SortOrder)
        {
            ListViewItemSorter = new ListViewComparer(columnIndex, SortOrder, ComparableListView_OnSort);
            // Sort.
            this.Sort();
        }
        //public new ListViewItemCollection Items
        //{
        //    get 
        //    {
        //        if (base.Items.Count == 0) MessageBox.Show("Empty List.");
        //        return base.Items; 
        //    }
        //}
        /// <summary>
        /// Make all item unSelected
        /// </summary>
        public void UnSelectAll()
        {
            foreach (ListViewItem itm in Items)
                itm.Selected = false;
        }

        /// <summary>
        /// Make all item Selected
        /// </summary>
        public void SelectAll()
        {
            foreach (ListViewItem itm in Items)
                itm.Selected = true;
        }
        /// <summary>
        /// Select the item which has this key
        /// </summary>
        public void SelectKey(string key)
        {
            try { Items[key].Selected = true; }
            catch { }
        }

        /// <summary>
        /// UnSelect the item which has this key
        /// </summary>
        public void UnSelectKey(string key)
        {
            try { Items[key].Selected = false; }
            catch { }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.A:
                    if (MultiSelect) SelectAll(); break;
                default: base.OnKeyUp(e); break;
            }
        }

        
        #endregion
        
       
    }
}
