namespace Softphone.CallHistory
{
    partial class ctrCallHistory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrCallHistory));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.callToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendSmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addToPhoneBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCall = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSendSms = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProperties = new System.Windows.Forms.ToolStripButton();
            this.buttonCancelSearch = new System.Windows.Forms.Button();
            this.comparableListView1 = new Softphone.ListViewFolder.SpecialListView();
            this.ctrTitle1 = new Softphone.MainFolder.ctrTitle();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callToolStripMenuItem,
            this.sendSmsToolStripMenuItem,
            this.toolStripSeparator2,
            this.addToPhoneBookToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.editUserToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 148);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // callToolStripMenuItem
            // 
            this.callToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.callToolStripMenuItem.Image = global::Softphone.Properties.Resources.calling;
            this.callToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.callToolStripMenuItem.Name = "callToolStripMenuItem";
            this.callToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.callToolStripMenuItem.Tag = "4";
            this.callToolStripMenuItem.Text = "Call..";
            // 
            // sendSmsToolStripMenuItem
            // 
            this.sendSmsToolStripMenuItem.Image = global::Softphone.Properties.Resources.mail;
            this.sendSmsToolStripMenuItem.Name = "sendSmsToolStripMenuItem";
            this.sendSmsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendSmsToolStripMenuItem.Tag = "5";
            this.sendSmsToolStripMenuItem.Text = "Send Sms..";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // addToPhoneBookToolStripMenuItem
            // 
            this.addToPhoneBookToolStripMenuItem.Image = global::Softphone.Properties.Resources.AddPhoneBook;
            this.addToPhoneBookToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.addToPhoneBookToolStripMenuItem.Name = "addToPhoneBookToolStripMenuItem";
            this.addToPhoneBookToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addToPhoneBookToolStripMenuItem.Tag = "0";
            this.addToPhoneBookToolStripMenuItem.Text = "Add to PhoneBook..";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::Softphone.Properties.Resources.delete_16x;
            this.removeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem.Tag = "1";
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::Softphone.Properties.Resources.Refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Tag = "3";
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editUserToolStripMenuItem.Image = global::Softphone.Properties.Resources.PropertiesHS;
            this.editUserToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editUserToolStripMenuItem.Tag = "2";
            this.editUserToolStripMenuItem.Text = "Properties";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "contact.png");
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSearch.Location = new System.Drawing.Point(0, 30);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(320, 20);
            this.textBoxSearch.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxSearch, "Instant Search");
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator3,
            this.toolStripButtonCall,
            this.toolStripButtonSendSms,
            this.toolStripButtonAdd,
            this.toolStripButtonRemove,
            this.toolStripButtonProperties});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 269);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(320, 23);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::Softphone.Properties.Resources.Refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonRefresh.Tag = "3";
            this.toolStripButtonRefresh.Text = "Reload Contacts (F5)";
            this.toolStripButtonRefresh.MouseEnter += new System.EventHandler(this.toolStripButtonRefresh_MouseEnter);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButtonCall
            // 
            this.toolStripButtonCall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCall.Image = global::Softphone.Properties.Resources.calling;
            this.toolStripButtonCall.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonCall.Name = "toolStripButtonCall";
            this.toolStripButtonCall.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonCall.Tag = "4";
            this.toolStripButtonCall.Text = "Call Selected Contact";
            this.toolStripButtonCall.Visible = false;
            // 
            // toolStripButtonSendSms
            // 
            this.toolStripButtonSendSms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSendSms.Image = global::Softphone.Properties.Resources.mail;
            this.toolStripButtonSendSms.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonSendSms.Name = "toolStripButtonSendSms";
            this.toolStripButtonSendSms.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonSendSms.Tag = "5";
            this.toolStripButtonSendSms.Text = "Send Sms";
            this.toolStripButtonSendSms.Visible = false;
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::Softphone.Properties.Resources.AddPhoneBook;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonAdd.Tag = "0";
            this.toolStripButtonAdd.Text = "Add to PhoneBook.";
            this.toolStripButtonAdd.Visible = false;
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = global::Softphone.Properties.Resources.delete_16x;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonRemove.Tag = "1";
            this.toolStripButtonRemove.Text = "Delete Selected Contacts";
            this.toolStripButtonRemove.Visible = false;
            // 
            // toolStripButtonProperties
            // 
            this.toolStripButtonProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonProperties.Image = global::Softphone.Properties.Resources.PropertiesHS;
            this.toolStripButtonProperties.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonProperties.Name = "toolStripButtonProperties";
            this.toolStripButtonProperties.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonProperties.Tag = "2";
            this.toolStripButtonProperties.Text = "Properties Of Selected Contact";
            this.toolStripButtonProperties.Visible = false;
            // 
            // buttonCancelSearch
            // 
            this.buttonCancelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelSearch.BackColor = System.Drawing.Color.White;
            this.buttonCancelSearch.FlatAppearance.BorderSize = 0;
            this.buttonCancelSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelSearch.Image = global::Softphone.Properties.Resources.search;
            this.buttonCancelSearch.Location = new System.Drawing.Point(300, 31);
            this.buttonCancelSearch.Name = "buttonCancelSearch";
            this.buttonCancelSearch.Size = new System.Drawing.Size(20, 18);
            this.buttonCancelSearch.TabIndex = 1;
            this.buttonCancelSearch.UseVisualStyleBackColor = false;
            this.buttonCancelSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // comparableListView1
            // 
            this.comparableListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.comparableListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comparableListView1.FullRowSelect = true;
            this.comparableListView1.LargeImageList = this.imageList1;
            this.comparableListView1.Location = new System.Drawing.Point(0, 50);
            this.comparableListView1.Name = "comparableListView1";
            this.comparableListView1.Size = new System.Drawing.Size(320, 219);
            this.comparableListView1.SmallImageList = this.imageList1;
            this.comparableListView1.TabIndex = 3;
            this.comparableListView1.UseCompatibleStateImageBehavior = false;
            this.comparableListView1.View = System.Windows.Forms.View.Details;
            this.comparableListView1.OnSort += new Softphone.SortListView(this.comparableListView1_OnSort);
            this.comparableListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.comparableListView1_MouseDoubleClick);
            this.comparableListView1.SelectedIndexChanged += new System.EventHandler(this.comparableListView1_SelectedIndexChanged);
            this.comparableListView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comparableListView1_KeyDown);
            // 
            // ctrTitle1
            // 
            this.ctrTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTitle1.Image = ((System.Drawing.Image)(resources.GetObject("ctrTitle1.Image")));
            this.ctrTitle1.Location = new System.Drawing.Point(0, 0);
            this.ctrTitle1.Name = "ctrTitle1";
            this.ctrTitle1.Size = new System.Drawing.Size(320, 30);
            this.ctrTitle1.TabIndex = 4;
            this.ctrTitle1.Title = "Dieled Calls";
            // 
            // ctrCallHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancelSearch);
            this.Controls.Add(this.comparableListView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.ctrTitle1);
            this.Name = "ctrCallHistory";
            this.Size = new System.Drawing.Size(320, 292);
            this.Load += new System.EventHandler(this.ctrCallLoger_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Softphone.ListViewFolder.SpecialListView comparableListView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonCancelSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToPhoneBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonCall;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
        private System.Windows.Forms.ToolStripButton toolStripButtonProperties;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private Softphone.MainFolder.ctrTitle ctrTitle1;
        private System.Windows.Forms.ToolStripMenuItem sendSmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendSms;
    }
}
