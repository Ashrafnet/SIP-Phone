namespace Softphone.MainFolder.SmsFolder
{
    partial class ctrSmsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrSmsMenu));
            this.ctrMenuItem3 = new Softphone.MainFolder.ctrMenuItem();
            this.ctrMenuItem2 = new Softphone.MainFolder.ctrMenuItem();
            this.ctrMenuItem1 = new Softphone.MainFolder.ctrMenuItem();
            this.ctrTitle1 = new Softphone.MainFolder.ctrTitle();
            this.SuspendLayout();
            // 
            // ctrMenuItem3
            // 
            this.ctrMenuItem3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrMenuItem3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrMenuItem3.FocusBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(222)))));
            this.ctrMenuItem3.Image = global::Softphone.Properties.Resources.outbox;
            this.ctrMenuItem3.ItemView = Softphone.MainFolder.ItemView.Horizontal;
            this.ctrMenuItem3.Location = new System.Drawing.Point(3, 124);
            this.ctrMenuItem3.Name = "ctrMenuItem3";
            this.ctrMenuItem3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.ctrMenuItem3.Size = new System.Drawing.Size(243, 37);
            this.ctrMenuItem3.TabIndex = 2;
            this.ctrMenuItem3.Tag = "2";
            this.ctrMenuItem3.Title = "Sent SMS";
            this.ctrMenuItem3.TitleFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ctrMenuItem3.OnClikItem += new System.EventHandler(this.ctrMenuItem3_OnClikItem);
            // 
            // ctrMenuItem2
            // 
            this.ctrMenuItem2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrMenuItem2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrMenuItem2.FocusBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(222)))));
            this.ctrMenuItem2.Image = global::Softphone.Properties.Resources.Inbox;
            this.ctrMenuItem2.ItemView = Softphone.MainFolder.ItemView.Horizontal;
            this.ctrMenuItem2.Location = new System.Drawing.Point(3, 79);
            this.ctrMenuItem2.Name = "ctrMenuItem2";
            this.ctrMenuItem2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.ctrMenuItem2.Size = new System.Drawing.Size(243, 37);
            this.ctrMenuItem2.TabIndex = 1;
            this.ctrMenuItem2.Tag = "1";
            this.ctrMenuItem2.Title = "Inbox SMS";
            this.ctrMenuItem2.TitleFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ctrMenuItem2.OnClikItem += new System.EventHandler(this.ctrMenuItem3_OnClikItem);
            // 
            // ctrMenuItem1
            // 
            this.ctrMenuItem1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrMenuItem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrMenuItem1.FocusBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(222)))));
            this.ctrMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ctrMenuItem1.Image")));
            this.ctrMenuItem1.ItemView = Softphone.MainFolder.ItemView.Horizontal;
            this.ctrMenuItem1.Location = new System.Drawing.Point(3, 34);
            this.ctrMenuItem1.Name = "ctrMenuItem1";
            this.ctrMenuItem1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.ctrMenuItem1.Size = new System.Drawing.Size(243, 37);
            this.ctrMenuItem1.TabIndex = 0;
            this.ctrMenuItem1.Tag = "0";
            this.ctrMenuItem1.Title = "New SMS";
            this.ctrMenuItem1.TitleFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ctrMenuItem1.OnClikItem += new System.EventHandler(this.ctrMenuItem3_OnClikItem);
            // 
            // ctrTitle1
            // 
            this.ctrTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTitle1.Image = global::Softphone.Properties.Resources.mail;
            this.ctrTitle1.Location = new System.Drawing.Point(0, 0);
            this.ctrTitle1.Name = "ctrTitle1";
            this.ctrTitle1.Size = new System.Drawing.Size(253, 28);
            this.ctrTitle1.TabIndex = 3;
            this.ctrTitle1.Title = "SMS Menu";
            // 
            // ctrSmsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrMenuItem3);
            this.Controls.Add(this.ctrMenuItem2);
            this.Controls.Add(this.ctrMenuItem1);
            this.Controls.Add(this.ctrTitle1);
            this.Name = "ctrSmsMenu";
            this.Size = new System.Drawing.Size(253, 224);
            this.VisibleChanged += new System.EventHandler(this.ctrSmsMenu_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrTitle ctrTitle1;
        private ctrMenuItem ctrMenuItem1;
        private ctrMenuItem ctrMenuItem2;
        private ctrMenuItem ctrMenuItem3;
    }
}
