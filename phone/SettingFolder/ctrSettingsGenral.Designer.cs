namespace Softphone.SettingFolder
{
    partial class ctrSettingsGenral
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
            this.comboBoxDateTimeStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDatetimeShow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxDateTimeStyle
            // 
            this.comboBoxDateTimeStyle.FormattingEnabled = true;
            this.comboBoxDateTimeStyle.Items.AddRange(new object[] {
            "dddd,MMMM dd, yyyy hh:mm tt",
            "dddd,dd MMMM, yyyy hh:mm tt",
            "MMMM, dd, yyyy hh:mm tt",
            "dd, MMMM, yyyy hh:mm tt",
            "MM/dd/yy hh:mm tt",
            "MM/dd/yyyy hh:mm tt",
            "dd/MM/yyyy hh:mm tt",
            "dd/MMM/yyyy hh:mm tt"});
            this.comboBoxDateTimeStyle.Location = new System.Drawing.Point(61, 152);
            this.comboBoxDateTimeStyle.Name = "comboBoxDateTimeStyle";
            this.comboBoxDateTimeStyle.Size = new System.Drawing.Size(269, 21);
            this.comboBoxDateTimeStyle.TabIndex = 0;
            this.comboBoxDateTimeStyle.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBoxDateTimeStyle.TextChanged += new System.EventHandler(this.comboBoxDateTimeStyle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(13, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date Time Style";
            // 
            // lblDatetimeShow
            // 
            this.lblDatetimeShow.AutoSize = true;
            this.lblDatetimeShow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatetimeShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDatetimeShow.Location = new System.Drawing.Point(69, 185);
            this.lblDatetimeShow.Name = "lblDatetimeShow";
            this.lblDatetimeShow.Size = new System.Drawing.Size(97, 13);
            this.lblDatetimeShow.TabIndex = 2;
            this.lblDatetimeShow.Text = "Date Time Style";
            // 
            // ctrSettingsGenral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDatetimeShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDateTimeStyle);
            this.Name = "ctrSettingsGenral";
            this.Size = new System.Drawing.Size(444, 331);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDateTimeStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDatetimeShow;
    }
}
