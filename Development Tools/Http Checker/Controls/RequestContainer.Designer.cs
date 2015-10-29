namespace theDiary.Tools.Development.HttpChecker.Controls
{
    partial class RequestContainer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.requestTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.requestDetails1 = new theDiary.Tools.Development.HttpChecker.Controls.RequestDetails();
            this.requestInformationTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.requestHeadersTab = new System.Windows.Forms.TabPage();
            this.requestHeaders1 = new theDiary.Tools.Development.HttpChecker.Controls.RequestHeaders();
            this.tabControl1.SuspendLayout();
            this.requestTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.requestInformationTabControl.SuspendLayout();
            this.requestHeadersTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.requestTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 481);
            this.tabControl1.TabIndex = 0;
            // 
            // requestTab
            // 
            this.requestTab.BackColor = System.Drawing.SystemColors.Control;
            this.requestTab.Controls.Add(this.requestInformationTabControl);
            this.requestTab.Controls.Add(this.groupBox1);
            this.requestTab.Location = new System.Drawing.Point(4, 22);
            this.requestTab.Name = "requestTab";
            this.requestTab.Padding = new System.Windows.Forms.Padding(3);
            this.requestTab.Size = new System.Drawing.Size(703, 455);
            this.requestTab.TabIndex = 0;
            this.requestTab.Text = "Request";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.requestDetails1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Details";
            // 
            // requestDetails1
            // 
            this.requestDetails1.DestinationUrl = "";
            this.requestDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestDetails1.Location = new System.Drawing.Point(3, 16);
            this.requestDetails1.MaximumSize = new System.Drawing.Size(0, 64);
            this.requestDetails1.MinimumSize = new System.Drawing.Size(242, 64);
            this.requestDetails1.Name = "requestDetails1";
            this.requestDetails1.Padding = new System.Windows.Forms.Padding(3);
            this.requestDetails1.Size = new System.Drawing.Size(691, 64);
            this.requestDetails1.TabIndex = 0;
            this.requestDetails1.TimeOut = System.TimeSpan.Parse("00:00:00");
            // 
            // requestInformationTabControl
            // 
            this.requestInformationTabControl.Controls.Add(this.tabPage1);
            this.requestInformationTabControl.Controls.Add(this.requestHeadersTab);
            this.requestInformationTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestInformationTabControl.Location = new System.Drawing.Point(3, 91);
            this.requestInformationTabControl.Name = "requestInformationTabControl";
            this.requestInformationTabControl.SelectedIndex = 0;
            this.requestInformationTabControl.Size = new System.Drawing.Size(697, 361);
            this.requestInformationTabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(451, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Content";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // requestHeadersTab
            // 
            this.requestHeadersTab.Controls.Add(this.requestHeaders1);
            this.requestHeadersTab.Location = new System.Drawing.Point(4, 22);
            this.requestHeadersTab.Name = "requestHeadersTab";
            this.requestHeadersTab.Padding = new System.Windows.Forms.Padding(3);
            this.requestHeadersTab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.requestHeadersTab.Size = new System.Drawing.Size(689, 335);
            this.requestHeadersTab.TabIndex = 1;
            this.requestHeadersTab.Text = "Headers";
            this.requestHeadersTab.UseVisualStyleBackColor = true;
            // 
            // requestHeaders1
            // 
            this.requestHeaders1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestHeaders1.Location = new System.Drawing.Point(3, 3);
            this.requestHeaders1.Name = "requestHeaders1";
            this.requestHeaders1.Size = new System.Drawing.Size(683, 329);
            this.requestHeaders1.TabIndex = 0;
            // 
            // RequestContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "RequestContainer";
            this.Size = new System.Drawing.Size(711, 481);
            this.tabControl1.ResumeLayout(false);
            this.requestTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.requestInformationTabControl.ResumeLayout(false);
            this.requestHeadersTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage requestTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private RequestDetails requestDetails1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl requestInformationTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage requestHeadersTab;
        private RequestHeaders requestHeaders1;
    }
}
