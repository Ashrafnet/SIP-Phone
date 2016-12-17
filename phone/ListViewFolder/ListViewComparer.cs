using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Softphone.ListViewFolder
{
    public class ListViewComparer : IComparer
    {
        /// <summary>
        /// Occurs when the sort begin
        /// </summary>
        public event SortListView OnSort;
        public int m_ColumnNumber { get;private set; }
        private SortOrder m_SortOrder;

        public ListViewComparer(int column_number, SortOrder sort_order, SortListView OnSort)
        {
            m_ColumnNumber = column_number;
            m_SortOrder = sort_order;
            this.OnSort = OnSort;
        }


        //Compare the items in the appropriate column
        //for objects x and y.
        public int Compare(object x, object y)
        {
            if (OnSort == null) return 0;
            ListViewItem item_x = (ListViewItem)x;
            ListViewItem item_y = (ListViewItem)y;

            if (m_SortOrder == SortOrder.Ascending)return OnSort(m_ColumnNumber, item_x, item_y);
            else return OnSort(m_ColumnNumber, item_y, item_x);
        }

    }
}
