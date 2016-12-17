namespace Softphone
{
    partial class ctrDialer
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
            this.listViewCallLines = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripCalls = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.acceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holdRetrieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxTransferCall = new System.Windows.Forms.ToolStripTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ctrTitle1 = new Softphone.MainFolder.ctrTitle();
            this.contextMenuStripCalls.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCallLines
            // 
            this.listViewCallLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewCallLines.ContextMenuStrip = this.contextMenuStripCalls;
            this.listViewCallLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCallLines.FullRowSelect = true;
            this.listViewCallLines.LargeImageList = this.imageList1;
            this.listViewCallLines.Location = new System.Drawing.Point(0, 28);
            this.listViewCallLines.MultiSelect = false;
            this.listViewCallLines.Name = "listViewCallLines";
            this.listViewCallLines.Size = new System.Drawing.Size(313, 251);
            this.listViewCallLines.SmallImageList = this.imageList1;
            this.listViewCallLines.TabIndex = 32;
            this.listViewCallLines.UseCompatibleStateImageBehavior = false;
            this.listViewCallLines.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "State";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 56;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Duration";
            this.columnHeader3.Width = 54;
            // 
            // contextMenuStripCalls
            // 
            this.contextMenuStripCalls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acceptToolStripMenuItem,
            this.releaseToolStripMenuItem,
            this.holdRetrieveToolStripMenuItem,
            this.transferCallToolStripMenuItem});
            this.contextMenuStripCalls.Name = "contextMenuStripCalls";
            this.contextMenuStripCalls.Size = new System.Drawing.Size(171, 92);
            this.contextMenuStripCalls.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripCalls_ItemClicked);
            this.contextMenuStripCalls.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripCalls_Opening);
            // 
            // acceptToolStripMenuItem
            // 
            this.acceptToolStripMenuItem.Image = global::Softphone.Properties.Resources.Accept;
            this.acceptToolStripMenuItem.Name = "acceptToolStripMenuItem";
            this.acceptToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.acceptToolStripMenuItem.Tag = "accept";
            this.acceptToolStripMenuItem.Text = "Accept Call";
            // 
            // releaseToolStripMenuItem
            // 
            this.releaseToolStripMenuItem.Image = global::Softphone.Properties.Resources.release;
            this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            this.releaseToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.releaseToolStripMenuItem.Tag = "release";
            this.releaseToolStripMenuItem.Text = "Release Call";
            // 
            // holdRetrieveToolStripMenuItem
            // 
            this.holdRetrieveToolStripMenuItem.Image = global::Softphone.Properties.Resources.hold;
            this.holdRetrieveToolStripMenuItem.Name = "holdRetrieveToolStripMenuItem";
            this.holdRetrieveToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.holdRetrieveToolStripMenuItem.Tag = "hold";
            this.holdRetrieveToolStripMenuItem.Text = "Hold/Retrieve Call";
            // 
            // transferCallToolStripMenuItem
            // 
            this.transferCallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxTransferCall});
            this.transferCallToolStripMenuItem.Name = "transferCallToolStripMenuItem";
            this.transferCallToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.transferCallToolStripMenuItem.Tag = "";
            this.transferCallToolStripMenuItem.Text = "Transfer Call";
            // 
            // toolStripTextBoxTransferCall
            // 
            this.toolStripTextBoxTransferCall.Name = "toolStripTextBoxTransferCall";
            this.toolStripTextBoxTransferCall.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxTransferCall.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxTransferCall_KeyPress);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ctrTitle1
            // 
            this.ctrTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTitle1.Image = global::Softphone.Properties.Resources.app;
            this.ctrTitle1.Location = new System.Drawing.Point(0, 0);
            this.ctrTitle1.Name = "ctrTitle1";
            this.ctrTitle1.Size = new System.Drawing.Size(313, 28);
            this.ctrTitle1.TabIndex = 33;
            this.ctrTitle1.Title = "Active Calls";
            // 
            // ctrDialer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewCallLines);
            this.Controls.Add(this.ctrTitle1);
            this.Name = "ctrDialer";
            this.Size = new System.Drawing.Size(313, 279);
            this.Load += new System.EventHandler(this.ctrDialer_Load);
            this.contextMenuStripCalls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCallLines;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCalls;
        private System.Windows.Forms.ToolStripMenuItem acceptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holdRetrieveToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem transferCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTransferCall;
        private Softphone.MainFolder.ctrTitle ctrTitle1;
    }
}
