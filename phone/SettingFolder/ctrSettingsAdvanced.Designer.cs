namespace Softphone.SettingFolder
{
    partial class ctrSettingsAdvanced
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
            this.labelRegistrationTimeout = new System.Windows.Forms.Label();
            this.comboBoxDtmfMode = new System.Windows.Forms.ComboBox();
            this.labelDtmfMode = new System.Windows.Forms.Label();
            this.checkBoxEchoCancelationTail = new System.Windows.Forms.CheckBox();
            this.numericUpDownRegistrationTimeout = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegistrationTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRegistrationTimeout
            // 
            this.labelRegistrationTimeout.AutoSize = true;
            this.labelRegistrationTimeout.Location = new System.Drawing.Point(20, 62);
            this.labelRegistrationTimeout.Name = "labelRegistrationTimeout";
            this.labelRegistrationTimeout.Size = new System.Drawing.Size(122, 13);
            this.labelRegistrationTimeout.TabIndex = 10;
            this.labelRegistrationTimeout.Text = "Registration Timeout (s)";
            // 
            // comboBoxDtmfMode
            // 
            this.comboBoxDtmfMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDtmfMode.FormattingEnabled = true;
            this.comboBoxDtmfMode.Items.AddRange(new object[] {
            "Out of band",
            "Inband",
            "Transparent"});
            this.comboBoxDtmfMode.Location = new System.Drawing.Point(156, 23);
            this.comboBoxDtmfMode.Name = "comboBoxDtmfMode";
            this.comboBoxDtmfMode.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDtmfMode.TabIndex = 9;
            this.comboBoxDtmfMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxDtmfMode_SelectedIndexChanged);
            // 
            // labelDtmfMode
            // 
            this.labelDtmfMode.AutoSize = true;
            this.labelDtmfMode.Location = new System.Drawing.Point(20, 26);
            this.labelDtmfMode.Name = "labelDtmfMode";
            this.labelDtmfMode.Size = new System.Drawing.Size(59, 13);
            this.labelDtmfMode.TabIndex = 8;
            this.labelDtmfMode.Text = "Dtmf Mode";
            // 
            // checkBoxEchoCancelationTail
            // 
            this.checkBoxEchoCancelationTail.AutoSize = true;
            this.checkBoxEchoCancelationTail.Location = new System.Drawing.Point(23, 103);
            this.checkBoxEchoCancelationTail.Name = "checkBoxEchoCancelationTail";
            this.checkBoxEchoCancelationTail.Size = new System.Drawing.Size(127, 17);
            this.checkBoxEchoCancelationTail.TabIndex = 13;
            this.checkBoxEchoCancelationTail.Text = "Echo Cancelation Tail";
            this.checkBoxEchoCancelationTail.UseVisualStyleBackColor = true;
            this.checkBoxEchoCancelationTail.CheckedChanged += new System.EventHandler(this.checkBoxEchoCancelationTail_CheckedChanged);
            // 
            // numericUpDownRegistrationTimeout
            // 
            this.numericUpDownRegistrationTimeout.Enabled = false;
            this.numericUpDownRegistrationTimeout.Location = new System.Drawing.Point(156, 60);
            this.numericUpDownRegistrationTimeout.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownRegistrationTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRegistrationTimeout.Name = "numericUpDownRegistrationTimeout";
            this.numericUpDownRegistrationTimeout.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRegistrationTimeout.TabIndex = 14;
            this.numericUpDownRegistrationTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRegistrationTimeout.ValueChanged += new System.EventHandler(this.numericUpDownRegistrationTimeout_ValueChanged);
            // 
            // ctrSettingsAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownRegistrationTimeout);
            this.Controls.Add(this.checkBoxEchoCancelationTail);
            this.Controls.Add(this.labelRegistrationTimeout);
            this.Controls.Add(this.comboBoxDtmfMode);
            this.Controls.Add(this.labelDtmfMode);
            this.Name = "ctrSettingsAdvanced";
            this.Size = new System.Drawing.Size(392, 244);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegistrationTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegistrationTimeout;
        private System.Windows.Forms.ComboBox comboBoxDtmfMode;
        private System.Windows.Forms.Label labelDtmfMode;
        private System.Windows.Forms.CheckBox checkBoxEchoCancelationTail;
        private System.Windows.Forms.NumericUpDown numericUpDownRegistrationTimeout;

    }
}
