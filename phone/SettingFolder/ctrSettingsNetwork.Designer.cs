namespace Softphone.SettingFolder
{
    partial class ctrSettingsNetwork
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTransport = new System.Windows.Forms.ComboBox();
            this.textBoxStunServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownListeningPort = new System.Windows.Forms.NumericUpDown();
            this.textBoxNameServer = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownListeningPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listening Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transport";
            // 
            // comboBoxTransport
            // 
            this.comboBoxTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransport.FormattingEnabled = true;
            this.comboBoxTransport.Items.AddRange(new object[] {
            "UDP",
            "TCP",
            "TLS (Secure)"});
            this.comboBoxTransport.Location = new System.Drawing.Point(126, 69);
            this.comboBoxTransport.Name = "comboBoxTransport";
            this.comboBoxTransport.Size = new System.Drawing.Size(170, 21);
            this.comboBoxTransport.TabIndex = 3;
            this.comboBoxTransport.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransport_SelectedIndexChanged);
            // 
            // textBoxStunServer
            // 
            this.textBoxStunServer.Location = new System.Drawing.Point(126, 105);
            this.textBoxStunServer.Name = "textBoxStunServer";
            this.textBoxStunServer.Size = new System.Drawing.Size(170, 20);
            this.textBoxStunServer.TabIndex = 5;
            this.textBoxStunServer.TextChanged += new System.EventHandler(this.textBoxStunServer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stun Server";
            // 
            // numericUpDownListeningPort
            // 
            this.numericUpDownListeningPort.Location = new System.Drawing.Point(127, 35);
            this.numericUpDownListeningPort.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownListeningPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownListeningPort.Name = "numericUpDownListeningPort";
            this.numericUpDownListeningPort.Size = new System.Drawing.Size(169, 20);
            this.numericUpDownListeningPort.TabIndex = 6;
            this.numericUpDownListeningPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownListeningPort.ValueChanged += new System.EventHandler(this.numericUpDownListeningPort_ValueChanged);
            // 
            // textBoxNameServer
            // 
            this.textBoxNameServer.Enabled = false;
            this.textBoxNameServer.Location = new System.Drawing.Point(126, 169);
            this.textBoxNameServer.Name = "textBoxNameServer";
            this.textBoxNameServer.Size = new System.Drawing.Size(170, 20);
            this.textBoxNameServer.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.Enabled = false;
            this.label20.Location = new System.Drawing.Point(41, 169);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 43);
            this.label20.TabIndex = 7;
            this.label20.Text = "Name Server (for DNS SRV)";
            // 
            // ctrSettingsNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxNameServer);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.numericUpDownListeningPort);
            this.Controls.Add(this.textBoxStunServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTransport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrSettingsNetwork";
            this.Size = new System.Drawing.Size(325, 265);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownListeningPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTransport;
        private System.Windows.Forms.TextBox textBoxStunServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownListeningPort;
        private System.Windows.Forms.TextBox textBoxNameServer;
        private System.Windows.Forms.Label label20;

    }
}
