namespace Softphone.SmsFolder
{
    partial class ctrSmsSender
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
            this.buttonCancelSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrTitle1 = new Softphone.MainFolder.ctrTitle();
            this.textBox2 = new Softphone.MainFolder.ctrTextbox();
            this.textBox1 = new Softphone.MainFolder.ctrTextbox();
            this.SuspendLayout();
            // 
            // buttonCancelSearch
            // 
            this.buttonCancelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelSearch.BackColor = System.Drawing.Color.White;
            this.buttonCancelSearch.FlatAppearance.BorderSize = 0;
            this.buttonCancelSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelSearch.Image = global::Softphone.Properties.Resources.phoneBook;
            this.buttonCancelSearch.Location = new System.Drawing.Point(292, 40);
            this.buttonCancelSearch.Name = "buttonCancelSearch";
            this.buttonCancelSearch.Size = new System.Drawing.Size(20, 18);
            this.buttonCancelSearch.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonCancelSearch, "Phone Book");
            this.buttonCancelSearch.UseVisualStyleBackColor = false;
            this.buttonCancelSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(222)))));
            this.label6.Location = new System.Drawing.Point(259, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Cancel";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(123)))), ((int)(((byte)(222)))));
            this.label5.Location = new System.Drawing.Point(17, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ok";
            // 
            // ctrTitle1
            // 
            this.ctrTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrTitle1.Image = global::Softphone.Properties.Resources.contact;
            this.ctrTitle1.Location = new System.Drawing.Point(0, 0);
            this.ctrTitle1.Name = "ctrTitle1";
            this.ctrTitle1.Size = new System.Drawing.Size(320, 28);
            this.ctrTitle1.TabIndex = 5;
            this.ctrTitle1.Title = "Send SMS";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackText = "Message Text";
            this.textBox2.ForeColor = System.Drawing.Color.Silver;
            this.textBox2.Location = new System.Drawing.Point(3, 65);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(310, 88);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "";
            this.textBox2.Text = "Message Text";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackText = "To";
            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(3, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(310, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "";
            this.textBox1.Text = "To";
            // 
            // ctrSmsSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancelSearch);
            this.Controls.Add(this.ctrTitle1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "ctrSmsSender";
            this.Size = new System.Drawing.Size(320, 182);
            this.Load += new System.EventHandler(this.ctrSmsSender_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Softphone.MainFolder.ctrTextbox textBox1;
        private Softphone.MainFolder.ctrTextbox textBox2;
        private Softphone.MainFolder.ctrTitle ctrTitle1;
        private System.Windows.Forms.Button buttonCancelSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}