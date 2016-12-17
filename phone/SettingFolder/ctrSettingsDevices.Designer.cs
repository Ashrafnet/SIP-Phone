namespace Softphone.SettingFolder
{
    partial class ctrSettingsDevices
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
            this.cmbSpeakersDevices = new System.Windows.Forms.ComboBox();
            this.cmbMicDevices = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxVoiceActivityDetection = new System.Windows.Forms.CheckBox();
            this.ctrVolume1 = new Softphone.MainFolder.ctrVolume();
            this.ctrVolume2 = new Softphone.MainFolder.ctrVolume();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSpeakersDevices
            // 
            this.cmbSpeakersDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeakersDevices.FormattingEnabled = true;
            this.cmbSpeakersDevices.Items.AddRange(new object[] {
            "System Default"});
            this.cmbSpeakersDevices.Location = new System.Drawing.Point(57, 30);
            this.cmbSpeakersDevices.Name = "cmbSpeakersDevices";
            this.cmbSpeakersDevices.Size = new System.Drawing.Size(224, 21);
            this.cmbSpeakersDevices.TabIndex = 0;
            // 
            // cmbMicDevices
            // 
            this.cmbMicDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMicDevices.FormattingEnabled = true;
            this.cmbMicDevices.Items.AddRange(new object[] {
            "System Default"});
            this.cmbMicDevices.Location = new System.Drawing.Point(57, 38);
            this.cmbMicDevices.Name = "cmbMicDevices";
            this.cmbMicDevices.Size = new System.Drawing.Size(224, 21);
            this.cmbMicDevices.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrVolume1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cmbSpeakersDevices);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 113);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playback";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Softphone.Properties.Resources.Speaker1;
            this.pictureBox1.Location = new System.Drawing.Point(25, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::Softphone.Properties.Resources.mic;
            this.pictureBox2.Location = new System.Drawing.Point(25, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 46;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrVolume2);
            this.groupBox2.Controls.Add(this.cmbMicDevices);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 119);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recording";
            // 
            // checkBoxVoiceActivityDetection
            // 
            this.checkBoxVoiceActivityDetection.AutoSize = true;
            this.checkBoxVoiceActivityDetection.Location = new System.Drawing.Point(28, 247);
            this.checkBoxVoiceActivityDetection.Name = "checkBoxVoiceActivityDetection";
            this.checkBoxVoiceActivityDetection.Size = new System.Drawing.Size(139, 17);
            this.checkBoxVoiceActivityDetection.TabIndex = 14;
            this.checkBoxVoiceActivityDetection.Text = "Voice Activity Detection";
            this.checkBoxVoiceActivityDetection.UseVisualStyleBackColor = true;
            // 
            // ctrVolume1
            // 
            this.ctrVolume1.BackColor = System.Drawing.Color.Transparent;

            this.ctrVolume1.Location = new System.Drawing.Point(305, 20);
            this.ctrVolume1.Name = "ctrVolume1";
            this.ctrVolume1.Size = new System.Drawing.Size(29, 85);
            this.ctrVolume1.TabIndex = 46;
            // 
            // ctrVolume2
            // 
            this.ctrVolume2.BackColor = System.Drawing.Color.Transparent;
            this.ctrVolume2.Enabled = false;
            
            this.ctrVolume2.Location = new System.Drawing.Point(300, 19);
            this.ctrVolume2.Name = "ctrVolume2";
            this.ctrVolume2.Size = new System.Drawing.Size(34, 85);
            this.ctrVolume2.TabIndex = 47;
            // 
            // ctrSettingsDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxVoiceActivityDetection);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrSettingsDevices";
            this.Size = new System.Drawing.Size(352, 282);
            this.Load += new System.EventHandler(this.ctrSettingsDevices_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSpeakersDevices;
        private System.Windows.Forms.ComboBox cmbMicDevices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxVoiceActivityDetection;
        private Softphone.MainFolder.ctrVolume ctrVolume1;
        private Softphone.MainFolder.ctrVolume ctrVolume2;
    }
}
