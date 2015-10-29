namespace theDiary.Tools.Development.HostFileManager.Controls
{
    partial class HostEntryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostEntryControl));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ipAddress = new theDiary.Tools.Development.HostFileManager.Controls.IPAddressControl();
            this.hostName = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.enabledPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.enabled = new System.Windows.Forms.CheckBox();
            this.enabledPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Host Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(70, 0);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Part1 = ((byte)(0));
            this.ipAddress.Part2 = ((byte)(0));
            this.ipAddress.Part3 = ((byte)(0));
            this.ipAddress.Part4 = ((byte)(0));
            this.ipAddress.Size = new System.Drawing.Size(178, 20);
            this.ipAddress.TabIndex = 3;
            this.ipAddress.Value = ((System.Net.IPAddress)(resources.GetObject("ipAddress.Value")));
            // 
            // hostName
            // 
            this.hostName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostName.Location = new System.Drawing.Point(71, 27);
            this.hostName.Name = "hostName";
            this.hostName.Size = new System.Drawing.Size(177, 20);
            this.hostName.TabIndex = 4;
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Location = new System.Drawing.Point(70, 53);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(178, 36);
            this.description.TabIndex = 5;
            // 
            // enabledPanel
            // 
            this.enabledPanel.Controls.Add(this.enabled);
            this.enabledPanel.Controls.Add(this.label4);
            this.enabledPanel.Location = new System.Drawing.Point(0, 95);
            this.enabledPanel.Name = "enabledPanel";
            this.enabledPanel.Size = new System.Drawing.Size(200, 21);
            this.enabledPanel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Enabled:";
            // 
            // enabled
            // 
            this.enabled.AutoSize = true;
            this.enabled.Location = new System.Drawing.Point(70, 2);
            this.enabled.Name = "enabled";
            this.enabled.Size = new System.Drawing.Size(15, 14);
            this.enabled.TabIndex = 4;
            this.enabled.UseVisualStyleBackColor = true;
            // 
            // HostEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enabledPanel);
            this.Controls.Add(this.description);
            this.Controls.Add(this.hostName);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HostEntryControl";
            this.Size = new System.Drawing.Size(253, 113);
            this.enabledPanel.ResumeLayout(false);
            this.enabledPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private IPAddressControl ipAddress;
        private System.Windows.Forms.TextBox hostName;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Panel enabledPanel;
        private System.Windows.Forms.CheckBox enabled;
        private System.Windows.Forms.Label label4;
    }
}
