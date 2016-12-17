namespace Softphone.MainFolder
{
    partial class ctrMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrMainWindow));
            this.lblCallStatus = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMyNo = new System.Windows.Forms.Label();
            this.lblCallingNo = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblBalance = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrVolume1 = new Softphone.MainFolder.ctrVolume();
            this.ctrButtonConference = new Softphone.ctrButton();
            this.ctrButtonRecord = new Softphone.ctrButton();
            this.ctrButtonTransfer = new Softphone.ctrButton();
            this.ctrButtonHold = new Softphone.ctrButton();
            this.picrecord = new Softphone.MainFolder.ctrRecordpic();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonConference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picrecord)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCallStatus
            // 
            this.lblCallStatus.AutoEllipsis = true;
            this.lblCallStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCallStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCallStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(222)))));
            this.lblCallStatus.Location = new System.Drawing.Point(3, 7);
            this.lblCallStatus.Name = "lblCallStatus";
            this.lblCallStatus.Size = new System.Drawing.Size(149, 16);
            this.lblCallStatus.TabIndex = 0;
            this.lblCallStatus.Text = "Ready.";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(3, 171);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 32;
            this.lblTime.Text = "Time";
            // 
            // lblMyNo
            // 
            this.lblMyNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMyNo.AutoSize = true;
            this.lblMyNo.BackColor = System.Drawing.Color.Transparent;
            this.lblMyNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyNo.ForeColor = System.Drawing.Color.White;
            this.lblMyNo.Location = new System.Drawing.Point(3, 197);
            this.lblMyNo.Name = "lblMyNo";
            this.lblMyNo.Size = new System.Drawing.Size(37, 13);
            this.lblMyNo.TabIndex = 60;
            this.lblMyNo.Text = "My No";
            // 
            // lblCallingNo
            // 
            this.lblCallingNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCallingNo.AutoEllipsis = true;
            this.lblCallingNo.BackColor = System.Drawing.Color.Transparent;
            this.lblCallingNo.ContextMenuStrip = this.contextMenuStrip1;
            this.lblCallingNo.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCallingNo.ForeColor = System.Drawing.Color.White;
            this.lblCallingNo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblCallingNo.Location = new System.Drawing.Point(3, 69);
            this.lblCallingNo.Name = "lblCallingNo";
            this.lblCallingNo.Size = new System.Drawing.Size(182, 50);
            this.lblCallingNo.TabIndex = 2;
            this.lblCallingNo.Text = "101";
            this.lblCallingNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCallingNo.TextChanged += new System.EventHandler(this.lblCallingNo_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::Softphone.Properties.Resources.CopyHS;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Tag = "0";
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::Softphone.Properties.Resources.PasteHS;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Tag = "1";
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Softphone.Properties.Resources.delete_16x;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem.Tag = "2";
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(3, 184);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 33;
            this.lblDate.Text = "Date";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalance.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBalance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(222)))));
            this.lblBalance.Location = new System.Drawing.Point(163, 7);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(68, 19);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "0.0€";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = global::Softphone.Properties.Resources.Redial;
            this.pictureBox3.Location = new System.Drawing.Point(119, 190);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 69;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "2";
            this.toolTip1.SetToolTip(this.pictureBox3, "Redial");
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Softphone.Properties.Resources.B;
            this.pictureBox2.Location = new System.Drawing.Point(163, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 68;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "0";
            this.toolTip1.SetToolTip(this.pictureBox2, "BackSpace");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::Softphone.Properties.Resources.c;
            this.pictureBox1.Location = new System.Drawing.Point(141, 190);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "1";
            this.toolTip1.SetToolTip(this.pictureBox1, "Clear");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ctrVolume1
            // 
            this.ctrVolume1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrVolume1.BackColor = System.Drawing.Color.Transparent;
            this.ctrVolume1.Location = new System.Drawing.Point(187, 100);
            this.ctrVolume1.Name = "ctrVolume1";
            this.ctrVolume1.Size = new System.Drawing.Size(47, 109);
            this.ctrVolume1.TabIndex = 70;
            // 
            // ctrButtonConference
            // 
            this.ctrButtonConference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrButtonConference.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrButtonConference.Enabled = false;
            this.ctrButtonConference.Image = global::Softphone.Properties.Resources.conference1;
            this.ctrButtonConference.Image_MouseClick = global::Softphone.Properties.Resources.conference3;
            this.ctrButtonConference.Image_MouseIn = global::Softphone.Properties.Resources.conference1;
            this.ctrButtonConference.Image_Normal = global::Softphone.Properties.Resources.conference1;
            this.ctrButtonConference.Location = new System.Drawing.Point(153, 215);
            this.ctrButtonConference.Name = "ctrButtonConference";
            this.ctrButtonConference.Size = new System.Drawing.Size(78, 24);
            this.ctrButtonConference.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ctrButtonConference.TabIndex = 65;
            this.ctrButtonConference.TabStop = false;
            this.ctrButtonConference.Tag = "";
            this.ctrButtonConference.LocationChanged += new System.EventHandler(this.ctrButtonConference_LocationChanged);
            this.ctrButtonConference.Click += new System.EventHandler(this.ctrButtonConference_Click);
            this.ctrButtonConference.EnabledChanged += new System.EventHandler(this.ctrButtonConference_EnabledChanged);
            // 
            // ctrButtonRecord
            // 
            this.ctrButtonRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrButtonRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrButtonRecord.Enabled = false;
            this.ctrButtonRecord.Image = global::Softphone.Properties.Resources.record1;
            this.ctrButtonRecord.Image_MouseClick = global::Softphone.Properties.Resources.record3;
            this.ctrButtonRecord.Image_MouseIn = global::Softphone.Properties.Resources.record1;
            this.ctrButtonRecord.Image_Normal = global::Softphone.Properties.Resources.record1;
            this.ctrButtonRecord.Location = new System.Drawing.Point(99, 215);
            this.ctrButtonRecord.Name = "ctrButtonRecord";
            this.ctrButtonRecord.Size = new System.Drawing.Size(54, 24);
            this.ctrButtonRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ctrButtonRecord.TabIndex = 64;
            this.ctrButtonRecord.TabStop = false;
            this.ctrButtonRecord.Tag = "";
            this.ctrButtonRecord.Click += new System.EventHandler(this.ctrButton2_Click);
            this.ctrButtonRecord.EnabledChanged += new System.EventHandler(this.ctrButtonRecord_EnabledChanged);
            // 
            // ctrButtonTransfer
            // 
            this.ctrButtonTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrButtonTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrButtonTransfer.Enabled = false;
            this.ctrButtonTransfer.Image = global::Softphone.Properties.Resources.transfer1;
            this.ctrButtonTransfer.Image_MouseClick = global::Softphone.Properties.Resources.transfer3;
            this.ctrButtonTransfer.Image_MouseIn = global::Softphone.Properties.Resources.transfer1;
            this.ctrButtonTransfer.Image_Normal = global::Softphone.Properties.Resources.transfer1;
            this.ctrButtonTransfer.Location = new System.Drawing.Point(40, 215);
            this.ctrButtonTransfer.Name = "ctrButtonTransfer";
            this.ctrButtonTransfer.Size = new System.Drawing.Size(61, 24);
            this.ctrButtonTransfer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ctrButtonTransfer.TabIndex = 63;
            this.ctrButtonTransfer.TabStop = false;
            this.ctrButtonTransfer.Tag = "";
            this.ctrButtonTransfer.Click += new System.EventHandler(this.ctrButtonTransfer_Click);
            this.ctrButtonTransfer.EnabledChanged += new System.EventHandler(this.ctrButtonTransfer_EnabledChanged);
            // 
            // ctrButtonHold
            // 
            this.ctrButtonHold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrButtonHold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrButtonHold.Enabled = false;
            this.ctrButtonHold.Image = global::Softphone.Properties.Resources.hold1;
            this.ctrButtonHold.Image_MouseClick = global::Softphone.Properties.Resources.hold3;
            this.ctrButtonHold.Image_MouseIn = global::Softphone.Properties.Resources.hold1;
            this.ctrButtonHold.Image_Normal = global::Softphone.Properties.Resources.hold1;
            this.ctrButtonHold.Location = new System.Drawing.Point(1, 215);
            this.ctrButtonHold.Name = "ctrButtonHold";
            this.ctrButtonHold.Size = new System.Drawing.Size(40, 24);
            this.ctrButtonHold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ctrButtonHold.TabIndex = 62;
            this.ctrButtonHold.TabStop = false;
            this.ctrButtonHold.Tag = "";
            this.ctrButtonHold.Click += new System.EventHandler(this.ctrButtonHold_Click);
            this.ctrButtonHold.EnabledChanged += new System.EventHandler(this.ctrButtonHold_EnabledChanged);
            // 
            // picrecord
            // 
            this.picrecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picrecord.EnabelTimer = false;
            this.picrecord.Image = ((System.Drawing.Image)(resources.GetObject("picrecord.Image")));
            this.picrecord.Location = new System.Drawing.Point(216, 29);
            this.picrecord.Name = "picrecord";
            this.picrecord.Size = new System.Drawing.Size(22, 17);
            this.picrecord.TabIndex = 66;
            this.picrecord.TabStop = false;
            this.picrecord.Visible = false;
            // 
            // ctrMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.ctrVolume1);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.ctrButtonConference);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrButtonRecord);
            this.Controls.Add(this.ctrButtonTransfer);
            this.Controls.Add(this.ctrButtonHold);
            this.Controls.Add(this.lblCallingNo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblCallStatus);
            this.Controls.Add(this.lblMyNo);
            this.Controls.Add(this.picrecord);
            this.Name = "ctrMainWindow";
            this.Size = new System.Drawing.Size(235, 239);
            this.Load += new System.EventHandler(this.ctrMainWindow_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonConference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrButtonHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picrecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.Label lblCallStatus;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblMyNo;
        private System.Windows.Forms.Label lblCallingNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lblBalance;
        private ctrButton ctrButtonHold;
        private ctrButton ctrButtonTransfer;
        private ctrButton ctrButtonRecord;
        private ctrButton ctrButtonConference;
        private ctrRecordpic picrecord;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private ctrVolume ctrVolume1;
    }
}
