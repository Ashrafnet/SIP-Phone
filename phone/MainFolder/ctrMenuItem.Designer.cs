namespace Softphone.MainFolder
{
    partial class ctrMenuItem
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.picmnu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picmnu)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(72, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.linkLabel1.Size = new System.Drawing.Size(118, 55);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "";
            this.linkLabel1.Text = "New SMS";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.MouseLeave += new System.EventHandler(this.picmnu_MouseLeave);
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.MouseEnter += new System.EventHandler(this.picmnu_MouseEnter);
            // 
            // picmnu
            // 
            this.picmnu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picmnu.Dock = System.Windows.Forms.DockStyle.Left;
            this.picmnu.Image = global::Softphone.Properties.Resources.sendsms;
            this.picmnu.Location = new System.Drawing.Point(20, 0);
            this.picmnu.Name = "picmnu";
            this.picmnu.Size = new System.Drawing.Size(52, 55);
            this.picmnu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picmnu.TabIndex = 18;
            this.picmnu.TabStop = false;
            this.picmnu.Tag = "";
            this.picmnu.MouseLeave += new System.EventHandler(this.picmnu_MouseLeave);
            this.picmnu.Click += new System.EventHandler(this.picmnu_Click);
            this.picmnu.MouseEnter += new System.EventHandler(this.picmnu_MouseEnter);
            // 
            // ctrMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.picmnu);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ctrMenuItem";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Size = new System.Drawing.Size(190, 55);
            this.Load += new System.EventHandler(this.ctrMenuItem_Load);
            this.Leave += new System.EventHandler(this.picmnu_MouseLeave);
            this.Enter += new System.EventHandler(this.picmnu_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.picmnu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picmnu;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
