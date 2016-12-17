using Softphone.MainFolder;
namespace Softphone
{
  partial class MainForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        this.contextMenuStripCalls = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.acceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.holdRetrieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.btnClose = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.btnLogoff = new System.Windows.Forms.Button();
        this.panelContianer = new System.Windows.Forms.Panel();
        this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
        this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
        this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
        this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
        this.ctrButton1 = new Softphone.ctrButton();
        this.ctrButton2 = new Softphone.ctrButton();
        this.ctrKeyPad1 = new Softphone.DtmfFolder.ctrKeyPad();
        this.ctrButtonMenu = new Softphone.ctrButton();
        this.ctrButtonCancel = new Softphone.ctrButton();
        this.ctrButtonBack = new Softphone.ctrButton();
        this.ctrButtonAccept = new Softphone.ctrButton();
        this.contextMenuStripCalls.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButton1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButton2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonMenu)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonCancel)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonBack)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonAccept)).BeginInit();
        this.SuspendLayout();
        // 
        // contextMenuStripCalls
        // 
        this.contextMenuStripCalls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acceptToolStripMenuItem,
            this.releaseToolStripMenuItem,
            this.holdRetrieveToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
        this.contextMenuStripCalls.Name = "contextMenuStripCalls";
        this.contextMenuStripCalls.Size = new System.Drawing.Size(171, 120);
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
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
        // 
        // openToolStripMenuItem
        // 
        this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.openToolStripMenuItem.Image = global::Softphone.Properties.Resources.app;
        this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
        this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        this.openToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
        this.openToolStripMenuItem.Tag = "open";
        this.openToolStripMenuItem.Text = "Open NogaFone";
        // 
        // exitToolStripMenuItem
        // 
        this.exitToolStripMenuItem.Image = global::Softphone.Properties.Resources.ClosePreviewHS;
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
        this.exitToolStripMenuItem.Tag = "exit";
        this.exitToolStripMenuItem.Text = "Exit";
        // 
        // notifyIcon
        // 
        this.notifyIcon.ContextMenuStrip = this.contextMenuStripCalls;
        this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        this.notifyIcon.Text = "NogaFone";
        this.notifyIcon.Visible = true;
        this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
        this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
        // 
        // btnClose
        // 
        this.btnClose.BackColor = System.Drawing.Color.Transparent;
        this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Image = global::Softphone.Properties.Resources.close;
        this.btnClose.Location = new System.Drawing.Point(226, 12);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(22, 22);
        this.btnClose.TabIndex = 75;
        this.btnClose.TabStop = false;
        this.btnClose.Tag = "0";
        this.toolTip1.SetToolTip(this.btnClose, "Exit");
        this.btnClose.UseVisualStyleBackColor = false;
        this.btnClose.Click += new System.EventHandler(this.btnLogoff_Click);
        // 
        // button2
        // 
        this.button2.BackColor = System.Drawing.Color.Transparent;
        this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button2.Image = global::Softphone.Properties.Resources.min;
        this.button2.Location = new System.Drawing.Point(205, 12);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(22, 22);
        this.button2.TabIndex = 76;
        this.button2.TabStop = false;
        this.button2.Tag = "1";
        this.toolTip1.SetToolTip(this.button2, "Hide Me");
        this.button2.UseVisualStyleBackColor = false;
        this.button2.Click += new System.EventHandler(this.btnLogoff_Click);
        // 
        // btnLogoff
        // 
        this.btnLogoff.BackColor = System.Drawing.Color.Transparent;
        this.btnLogoff.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLogoff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.btnLogoff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
        this.btnLogoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLogoff.Image = global::Softphone.Properties.Resources._lock;
        this.btnLogoff.Location = new System.Drawing.Point(183, 12);
        this.btnLogoff.Name = "btnLogoff";
        this.btnLogoff.Size = new System.Drawing.Size(22, 22);
        this.btnLogoff.TabIndex = 77;
        this.btnLogoff.TabStop = false;
        this.btnLogoff.Tag = "2";
        this.toolTip1.SetToolTip(this.btnLogoff, "Log off");
        this.btnLogoff.UseVisualStyleBackColor = false;
        this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
        // 
        // panelContianer
        // 
        this.panelContianer.BackColor = System.Drawing.Color.Transparent;
        this.panelContianer.Location = new System.Drawing.Point(13, 37);
        this.panelContianer.Name = "panelContianer";
        this.panelContianer.Padding = new System.Windows.Forms.Padding(2);
        this.panelContianer.Size = new System.Drawing.Size(235, 230);
        this.panelContianer.TabIndex = 48;
        // 
        // toolStripButton3
        // 
        this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
        this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButton3.Name = "toolStripButton3";
        this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
        this.toolStripButton3.Text = "toolStripButton3";
        // 
        // toolStripButton4
        // 
        this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
        this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButton4.Name = "toolStripButton4";
        this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
        this.toolStripButton4.Text = "toolStripButton4";
        // 
        // toolStripButton5
        // 
        this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
        this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButton5.Name = "toolStripButton5";
        this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
        this.toolStripButton5.Text = "toolStripButton5";
        // 
        // toolStripButton6
        // 
        this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
        this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButton6.Name = "toolStripButton6";
        this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
        this.toolStripButton6.Text = "toolStripButton6";
        // 
        // ctrButton1
        // 
        this.ctrButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.ctrButton1.BackColor = System.Drawing.Color.Black;
        this.ctrButton1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ctrButton1.Image = global::Softphone.Properties.Resources.ok1;
        this.ctrButton1.Image_MouseClick = global::Softphone.Properties.Resources.ok3;
        this.ctrButton1.Image_MouseIn = global::Softphone.Properties.Resources.ok2;
        this.ctrButton1.Image_Normal = global::Softphone.Properties.Resources.ok1;
        this.ctrButton1.Location = new System.Drawing.Point(169, 276);
        this.ctrButton1.Name = "ctrButton1";
        this.ctrButton1.Size = new System.Drawing.Size(68, 28);
        this.ctrButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.ctrButton1.TabIndex = 79;
        this.ctrButton1.TabStop = false;
        this.ctrButton1.Click += new System.EventHandler(this.ctrButton1_Click);
        // 
        // ctrButton2
        // 
        this.ctrButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.ctrButton2.BackColor = System.Drawing.Color.Black;
        this.ctrButton2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ctrButton2.Image = global::Softphone.Properties.Resources.ok1;
        this.ctrButton2.Image_MouseClick = global::Softphone.Properties.Resources.ok3;
        this.ctrButton2.Image_MouseIn = global::Softphone.Properties.Resources.ok2;
        this.ctrButton2.Image_Normal = global::Softphone.Properties.Resources.ok1;
        this.ctrButton2.Location = new System.Drawing.Point(24, 276);
        this.ctrButton2.Name = "ctrButton2";
        this.ctrButton2.Size = new System.Drawing.Size(66, 29);
        this.ctrButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.ctrButton2.TabIndex = 78;
        this.ctrButton2.TabStop = false;
        this.ctrButton2.Click += new System.EventHandler(this.ctrButton2_Click_1);
        // 
        // ctrKeyPad1
        // 
        this.ctrKeyPad1.AutoSize = true;
        this.ctrKeyPad1.BackColor = System.Drawing.Color.Transparent;
        this.ctrKeyPad1.Enabled = false;
        this.ctrKeyPad1.Location = new System.Drawing.Point(14, 343);
        this.ctrKeyPad1.Name = "ctrKeyPad1";
        this.ctrKeyPad1.Size = new System.Drawing.Size(236, 107);
        this.ctrKeyPad1.TabIndex = 64;
        // 
        // ctrButtonMenu
        // 
        this.ctrButtonMenu.BackColor = System.Drawing.Color.Black;
        this.ctrButtonMenu.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ctrButtonMenu.Image = global::Softphone.Properties.Resources.menu1;
        this.ctrButtonMenu.Image_MouseClick = global::Softphone.Properties.Resources.menu3;
        this.ctrButtonMenu.Image_MouseIn = global::Softphone.Properties.Resources.menu2;
        this.ctrButtonMenu.Image_Normal = global::Softphone.Properties.Resources.menu1;
        this.ctrButtonMenu.Location = new System.Drawing.Point(100, 286);
        this.ctrButtonMenu.Name = "ctrButtonMenu";
        this.ctrButtonMenu.Size = new System.Drawing.Size(54, 41);
        this.ctrButtonMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.ctrButtonMenu.TabIndex = 69;
        this.ctrButtonMenu.TabStop = false;
        this.ctrButtonMenu.Click += new System.EventHandler(this.ctrButtonMenu_Click);
        // 
        // ctrButtonCancel
        // 
        this.ctrButtonCancel.BackColor = System.Drawing.Color.Black;
        this.ctrButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ctrButtonCancel.Image = global::Softphone.Properties.Resources.release1;
        this.ctrButtonCancel.Image_MouseClick = global::Softphone.Properties.Resources.release3;
        this.ctrButtonCancel.Image_MouseIn = global::Softphone.Properties.Resources.release2;
        this.ctrButtonCancel.Image_Normal = global::Softphone.Properties.Resources.release1;
        this.ctrButtonCancel.Location = new System.Drawing.Point(169, 308);
        this.ctrButtonCancel.Name = "ctrButtonCancel";
        this.ctrButtonCancel.Size = new System.Drawing.Size(68, 29);
        this.ctrButtonCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.ctrButtonCancel.TabIndex = 66;
        this.ctrButtonCancel.TabStop = false;
        this.ctrButtonCancel.Click += new System.EventHandler(this.ctrButton3_Click);
        // 
        // ctrButtonBack
        // 
        this.ctrButtonBack.BackColor = System.Drawing.Color.Black;
        this.ctrButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ctrButtonBack.Image = global::Softphone.Properties.Resources.back1;
        this.ctrButtonBack.Image_MouseClick = global::Softphone.Properties.Resources.back3;
        this.ctrButtonBack.Image_MouseIn = global::Softphone.Properties.Resources.back2;
        this.ctrButtonBack.Image_Normal = global::Softphone.Properties.Resources.back1;
        this.ctrButtonBack.Location = new System.Drawing.Point(286, 206);
        this.ctrButtonBack.Name = "ctrButtonBack";
        this.ctrButtonBack.Size = new System.Drawing.Size(54, 41);
        this.ctrButtonBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.ctrButtonBack.TabIndex = 70;
        this.ctrButtonBack.TabStop = false;
        this.ctrButtonBack.Visible = false;
        this.ctrButtonBack.Click += new System.EventHandler(this.ctrButtonBack_Click);
        // 
        // ctrButtonAccept
        // 
        this.ctrButtonAccept.BackColor = System.Drawing.Color.Black;
        this.ctrButtonAccept.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ctrButtonAccept.Image = global::Softphone.Properties.Resources.accept1;
        this.ctrButtonAccept.Image_MouseClick = global::Softphone.Properties.Resources.accept3;
        this.ctrButtonAccept.Image_MouseIn = global::Softphone.Properties.Resources.accept2;
        this.ctrButtonAccept.Image_Normal = global::Softphone.Properties.Resources.accept1;
        this.ctrButtonAccept.Location = new System.Drawing.Point(24, 309);
        this.ctrButtonAccept.Name = "ctrButtonAccept";
        this.ctrButtonAccept.Size = new System.Drawing.Size(66, 28);
        this.ctrButtonAccept.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.ctrButtonAccept.TabIndex = 65;
        this.ctrButtonAccept.TabStop = false;
        this.ctrButtonAccept.Click += new System.EventHandler(this.ctrButton2_Click);
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.BackgroundImage = global::Softphone.Properties.Resources.main;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.ClientSize = new System.Drawing.Size(262, 461);
        this.Controls.Add(this.ctrButton1);
        this.Controls.Add(this.ctrButton2);
        this.Controls.Add(this.btnLogoff);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.ctrKeyPad1);
        this.Controls.Add(this.panelContianer);
        this.Controls.Add(this.ctrButtonMenu);
        this.Controls.Add(this.ctrButtonCancel);
        this.Controls.Add(this.ctrButtonBack);
        this.Controls.Add(this.ctrButtonAccept);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.DoubleBuffered = true;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.KeyPreview = true;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "NogaFone";
        this.Load += new System.EventHandler(this.MainForm_Load);
        this.Shown += new System.EventHandler(this.MainForm_Shown);
        this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
        this.contextMenuStripCalls.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ctrButton1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButton2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonMenu)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonCancel)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonBack)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ctrButtonAccept)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStripCalls;
      private System.Windows.Forms.ToolStripMenuItem acceptToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem holdRetrieveToolStripMenuItem;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.Panel panelContianer;
      private Softphone.DtmfFolder.ctrKeyPad ctrKeyPad1;
      private ctrButton ctrButtonAccept;
      private ctrButton ctrButtonCancel;
      private ctrButton ctrButtonMenu;
      private ctrButton ctrButtonBack;
      private System.Windows.Forms.ToolStripButton toolStripButton3;
      private System.Windows.Forms.ToolStripButton toolStripButton4;
      private System.Windows.Forms.ToolStripButton toolStripButton5;
      private System.Windows.Forms.ToolStripButton toolStripButton6;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button btnLogoff;
      public System.Windows.Forms.NotifyIcon notifyIcon;
      private ctrButton ctrButton2;
      private ctrButton ctrButton1;
  }
}

