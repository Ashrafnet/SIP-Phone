using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Security;

namespace Softphone
{

    public partial class ctrSelectColumns : UserControl
    {
        /// <summary>
        /// The enabledItems
        /// </summary>
        public StringCollection enabledItems { get; set; }
        /// <summary>
        /// The disableItems
        /// </summary>
        public StringCollection disableItems { get;private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="allItems">All items checked and not checked</param>
        /// <param name="enabledItems">only checked items </param>
        public ctrSelectColumns(StringCollection allItems, StringCollection enabledItems)
        {
            this.enabledItems = enabledItems;
            disableItems = new StringCollection();
            InitializeComponent(); 
            listView1.Items.Clear();
            foreach (string codec in enabledItems)
                AddItem(codec,true);

            foreach (string codec in allItems)
            {
                if (listView1.Items.ContainsKey(codec)) continue;
                disableItems.Add(codec);
                AddItem(codec,false);
            }
        }
        private void AddItem(string codec,bool isEnable)
        {
            ListViewItem Item = new ListViewItem();
            Item.ImageIndex = 0;
            Item.Name = codec;
            Item.Text = codec;
            Item.Checked = isEnable;
            listView1.Items.Add(Item);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
                listView1.Items[i].Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
                listView1.Items[i].Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
                listView1.SelectedItems[i].Checked = !listView1.SelectedItems[i].Checked;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView1.CheckedItems.Count == 0) e.Item.Checked = true;
        }

        public void ApplyOption()
        {
            enabledItems.Clear();
            disableItems.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
                if (listView1.Items[i].Checked)
                    enabledItems.Add(listView1.Items[i].Name);
                else disableItems.Add(listView1.Items[i].Name);
        }
        private void button6_Down(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            for (int i = count - 1; i > -1; i--)
            {
                ListViewItem Item = listView1.SelectedItems[i];
                int index = Item.Index;
                if (index == listView1.Items.Count - 1) break;
                ListViewItem down = listView1.Items[index + 1];
                listView1.Items.RemoveAt(Item.Index + 1);
                listView1.Items.Insert(index, down);
                Item.EnsureVisible();
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView1.SelectedItems)
            {
                int index = Item.Index;
                if (index == 0) break;
                ListViewItem up = listView1.Items[index - 1];
                listView1.Items.RemoveAt(Item.Index - 1);
                listView1.Items.Insert(index, up);
                Item.EnsureVisible();
            }
        }


    }
}
