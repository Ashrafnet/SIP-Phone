namespace Softphone.SmsFolder
{
    partial class ctrSmsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrSmsManager));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.callToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendSmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCancelSearch = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCall = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSendSms = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProperties = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStopLoading = new System.Windows.Forms.ToolStripButton();
            this.comparableListView1 = new Softphone.ListViewFolder.SpecialListView();
            this.ctrTitle1 = new Softphone.MainFolder.ctrTitle();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callToolStripMenuItem,
            this.toolStripSeparator2,
            this.sendSmsToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.editUserToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 126);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // callToolStripMenuItem
            // 
            this.callToolStripMenuItem.Image = global::Softphone.Properties.Resources.calling;
            this.callToolStripMenuItem.Name = "callToolStripMenuItem";
            this.callToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.callToolStripMenuItem.Tag = "4";
            this.callToolStripMenuItem.Text = "Call Sender..";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // sendSmsToolStripMenuItem
            // 
            this.sendSmsToolStripMenuItem.Image = global::Softphone.Properties.Resources.NewContact1;
            this.sendSmsToolStripMenuItem.Name = "sendSmsToolStripMenuItem";
            this.sendSmsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.sendSmsToolStripMenuItem.Tag = "0";
            this.sendSmsToolStripMenuItem.Text = "New SMS..";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::Softphone.Properties.Resources.delete_16x;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.removeToolStripMenuItem.Tag = "1";
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::Softphone.Properties.Resources.Refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.refreshToolStripMenuItem.Tag = "3";
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.editUserToolStripMenuItem.Image = global::Softphone.Properties.Resources.PropertiesHS;
            this.editUserToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.editUserToolStripMenuItem.Tag = "2";
            this.editUserToolStripMenuItem.Text = "Properties";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "unread.gif");
            this.imageList1.Images.SetKeyName(1, "readed.png");
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSearch.Location = new System.Drawing.Point(0, 25);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(271, 20);
            this.textBoxSearch.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxSearch, "Instant Search");
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(251, 167);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Loading..");
            this.pictureBox1.Visible = false;
            // 
            // buttonCancelSearch
            // 
            this.buttonCancelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelSearch.BackColor = System.Drawing.Color.White;
            this.buttonCancelSearch.FlatAppearance.BorderSize = 0;
            this.buttonCancelSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelSearch.Image = global::Softphone.Properties.Resources.search;
            this.buttonCancelSearch.Location = new System.Drawing.Point(249, 26);
            this.buttonCancelSearch.Name = "buttonCancelSearch";
            this.buttonCancelSearch.Size = new System.Drawing.Size(20, 18);
            this.buttonCancelSearch.TabIndex = 1;
            this.buttonCancelSearch.UseVisualStyleBackColor = false;
            this.buttonCancelSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCall,
            this.toolStripSeparator3,
            this.toolStripButtonSendSms,
            this.toolStripButtonRemove,
            this.toolStripButtonProperties,
            this.toolStripButtonRefresh,
            this.toolStripButtonStopLoading});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 164);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(271, 23);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonCall
            // 
            this.toolStripButtonCall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCall.Image = global::Softphone.Properties.Resources.calling;
            this.toolStripButtonCall.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtonCall.Name = "toolStripButtonCall";
            this.toolStripButtonCall.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonCall.Tag = "4";
            this.toolStripButtonCall.Text = "Call Sender";
            this.toolStripButtonCall.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            this.toolStripSeparator3.Visible = false;
            // 
            // toolStripButtonSendSms
            // 
            this.toolStripButtonSendSms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSendSms.Image = global::Softphone.Properties.Resources.NewContact1;
            this.toolStripButtonSendSms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendSms.Name = "toolStripButtonSendSms";
            this.toolStripButtonSendSms.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonSendSms.Tag = "0";
            this.toolStripButtonSendSms.Text = "New SMS";
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = global::Softphone.Properties.Resources.delete_16x;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonRemove.Tag = "1";
            this.toolStripButtonRemove.Text = "Delete Selected SMS";
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
            this.toolStripButtonProperties.Text = "View SMS";
            this.toolStripButtonProperties.Visible = false;
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::Softphone.Properties.Resources.Refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonRefresh.Tag = "3";
            this.toolStripButtonRefresh.Text = "Refresh SMS (F5)";
            this.toolStripButtonRefresh.MouseEnter += new System.EventHandler(this.toolStripButtonRefresh_MouseEnter);
            // 
            // toolStripButtonStopLoading
            // 
            this.toolStripButtonStopLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStopLoading.Image = global::Softphone.Properties.Resources.Stop;
            this.toolStripButtonStopLoading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStopLoading.Name = "toolStripButtonStopLoading";
            this.toolStripButtonStopLoading.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonStopLoading.Tag = "5";
            this.toolStripButtonStopLoading.Text = "Stop Loading";
            // 
            // comparableListView1
            // 
            this.comparableListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.comparableListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comparableListView1.FullRowSelect = true;
            this.comparableListView1.LargeImageList = this.imageList1;
            this.comparableListView1.Location = new System.Drawing.Point(0, 45);
            this.comparableListView1.Name = "comparableListView1";
            this.comparableListView1.Size = new System.Drawing.Size(271, 119);
            this.comparableListView1.SmallImageList = this.imageList1;
            this.comparableListView1.TabIndex = 2;
            this.comparableListView1.UseCompatibleStateImageBehavior = false;
            this.comparableListView1.View = System.Windows.Forms.View.Details;
            this.comparableListView1.OnSort += new Softphone.SortListView(this.comparableListView1_OnSort);
            this.comparableListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.comparableListView1_MouseDoubleClick);
            this.comparableListView1.SelectedIndexChanged += new System.EventHandler(this.comparableListView1_SelectedIndexChanged);
            this.comparableListView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comparableListView1_KeyDown);
            // 
            // ctrTitle1
            // 
            this.ctrTitle1.AutoSize = true;
            this.ctrTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTitle1.Image = global::Softphone.Properties.Resources.readed;
            this.ctrTitle1.Location = new System.Drawing.Point(0, 0);
            this.ctrTitle1.Name = "ctrTitle1";
            this.ctrTitle1.Size = new System.Drawing.Size(271, 25);
            this.ctrTitle1.TabIndex = 7;
            this.ctrTitle1.Title = "Inbox SMS";
            // 
            // ctrSmsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comparableListView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonCancelSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.ctrTitle1);
            this.Name = "ctrSmsManager";
            this.Size = new System.Drawing.Size(271, 187);
            this.Load += new System.EventHandler(this.ctrSmsManager_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Softphone.ListViewFolder.SpecialListView comparableListView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendSmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonCancelSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCall;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendSms;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
        private System.Windows.Forms.ToolStripButton toolStripButtonProperties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStopLoading;
        private Softphone.MainFolder.ctrTitle ctrTitle1;
    }
}
