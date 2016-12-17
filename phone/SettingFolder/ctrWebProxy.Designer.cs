namespace Softphone.SettingFolder
{
    partial class ctrWebProxy
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
            this.textBoxProxyAddress = new System.Windows.Forms.TextBox();
            this.textBoxProxyUserName = new System.Windows.Forms.TextBox();
            this.checkBoxUseProxyAuthentication = new System.Windows.Forms.CheckBox();
            this.textBoxProxyPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxProxyDomain = new System.Windows.Forms.TextBox();
            this.groupBoxUseProxyAuthentication = new System.Windows.Forms.GroupBox();
            this.checkBoxUseProxy = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxUseProxyAuthentication.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxProxyAddress
            // 
            this.textBoxProxyAddress.Location = new System.Drawing.Point(114, 20);
            this.textBoxProxyAddress.Name = "textBoxProxyAddress";
            this.textBoxProxyAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxProxyAddress.TabIndex = 2;
            this.textBoxProxyAddress.TextChanged += new System.EventHandler(this.textBoxProxyAddress_TextChanged);
            // 
            // textBoxProxyUserName
            // 
            this.textBoxProxyUserName.Location = new System.Drawing.Point(115, 22);
            this.textBoxProxyUserName.Name = "textBoxProxyUserName";
            this.textBoxProxyUserName.Size = new System.Drawing.Size(100, 20);
            this.textBoxProxyUserName.TabIndex = 3;
            this.textBoxProxyUserName.TextChanged += new System.EventHandler(this.textBoxProxyAddress_TextChanged);
            // 
            // checkBoxUseProxyAuthentication
            // 
            this.checkBoxUseProxyAuthentication.AutoSize = true;
            this.checkBoxUseProxyAuthentication.Location = new System.Drawing.Point(34, 57);
            this.checkBoxUseProxyAuthentication.Name = "checkBoxUseProxyAuthentication";
            this.checkBoxUseProxyAuthentication.Size = new System.Drawing.Size(117, 17);
            this.checkBoxUseProxyAuthentication.TabIndex = 4;
            this.checkBoxUseProxyAuthentication.Text = "Use Authentication";
            this.checkBoxUseProxyAuthentication.UseVisualStyleBackColor = true;
            this.checkBoxUseProxyAuthentication.CheckedChanged += new System.EventHandler(this.checkBoxUseProxy_CheckedChanged_1);
            // 
            // textBoxProxyPassword
            // 
            this.textBoxProxyPassword.Location = new System.Drawing.Point(115, 51);
            this.textBoxProxyPassword.Name = "textBoxProxyPassword";
            this.textBoxProxyPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxProxyPassword.TabIndex = 3;
            this.textBoxProxyPassword.UseSystemPasswordChar = true;
            this.textBoxProxyPassword.TextChanged += new System.EventHandler(this.textBoxProxyAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proxy Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Domain";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProxyDomain
            // 
            this.textBoxProxyDomain.Location = new System.Drawing.Point(115, 77);
            this.textBoxProxyDomain.Name = "textBoxProxyDomain";
            this.textBoxProxyDomain.Size = new System.Drawing.Size(100, 20);
            this.textBoxProxyDomain.TabIndex = 3;
            this.textBoxProxyDomain.UseSystemPasswordChar = true;
            this.textBoxProxyDomain.TextChanged += new System.EventHandler(this.textBoxProxyAddress_TextChanged);
            // 
            // groupBoxUseProxyAuthentication
            // 
            this.groupBoxUseProxyAuthentication.Controls.Add(this.label4);
            this.groupBoxUseProxyAuthentication.Controls.Add(this.textBoxProxyDomain);
            this.groupBoxUseProxyAuthentication.Controls.Add(this.label3);
            this.groupBoxUseProxyAuthentication.Controls.Add(this.textBoxProxyUserName);
            this.groupBoxUseProxyAuthentication.Controls.Add(this.label2);
            this.groupBoxUseProxyAuthentication.Controls.Add(this.textBoxProxyPassword);
            this.groupBoxUseProxyAuthentication.Enabled = false;
            this.groupBoxUseProxyAuthentication.Location = new System.Drawing.Point(29, 61);
            this.groupBoxUseProxyAuthentication.Name = "groupBoxUseProxyAuthentication";
            this.groupBoxUseProxyAuthentication.Size = new System.Drawing.Size(245, 106);
            this.groupBoxUseProxyAuthentication.TabIndex = 6;
            this.groupBoxUseProxyAuthentication.TabStop = false;
            this.groupBoxUseProxyAuthentication.Text = "Use Authentication";
            // 
            // checkBoxUseProxy
            // 
            this.checkBoxUseProxy.AutoSize = true;
            this.checkBoxUseProxy.Location = new System.Drawing.Point(55, 53);
            this.checkBoxUseProxy.Name = "checkBoxUseProxy";
            this.checkBoxUseProxy.Size = new System.Drawing.Size(75, 17);
            this.checkBoxUseProxy.TabIndex = 4;
            this.checkBoxUseProxy.Text = "Use Proxy";
            this.checkBoxUseProxy.UseVisualStyleBackColor = true;
            this.checkBoxUseProxy.CheckedChanged += new System.EventHandler(this.checkBoxUseProxy_CheckedChanged_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxUseProxyAuthentication);
            this.panel1.Controls.Add(this.textBoxProxyAddress);
            this.panel1.Controls.Add(this.groupBoxUseProxyAuthentication);
            this.panel1.Location = new System.Drawing.Point(55, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 294);
            this.panel1.TabIndex = 8;
            // 
            // ctrWebProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxUseProxy);
            this.Controls.Add(this.panel1);
            this.Name = "ctrWebProxy";
            this.Size = new System.Drawing.Size(424, 370);
            this.Load += new System.EventHandler(this.ctrWebProxy_Load);
            this.groupBoxUseProxyAuthentication.ResumeLayout(false);
            this.groupBoxUseProxyAuthentication.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProxyAddress;
        private System.Windows.Forms.TextBox textBoxProxyUserName;
        private System.Windows.Forms.CheckBox checkBoxUseProxyAuthentication;
        private System.Windows.Forms.TextBox textBoxProxyPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxProxyDomain;
        private System.Windows.Forms.GroupBox groupBoxUseProxyAuthentication;
        private System.Windows.Forms.CheckBox checkBoxUseProxy;
        private System.Windows.Forms.Panel panel1;
    }
}
