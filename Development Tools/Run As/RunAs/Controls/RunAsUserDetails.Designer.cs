namespace Iterative.Tools.RunAs.Controls
{
    partial class RunAsUserDetails
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.domainName = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Controls.WatermarkTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Domain:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // domainName
            // 
            this.domainName.AccessibleDescription = "The Domain name used to authenticate against...";
            this.domainName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.domainName.Location = new System.Drawing.Point(66, 54);
            this.domainName.Name = "domainName";
            this.domainName.Size = new System.Drawing.Size(254, 20);
            this.domainName.TabIndex = 18;
            this.domainName.TextChanged += new System.EventHandler(this.UserDetailsChanged);
            this.domainName.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.domainName.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // password
            // 
            this.password.AccessibleDescription = "The Password used to authenticate...";
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password.ContextMenuStrip = this.contextMenuStrip1;
            this.password.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.password.Location = new System.Drawing.Point(66, 28);
            this.password.Name = "password";
            this.password.PasswordChar = 'l';
            this.password.Size = new System.Drawing.Size(254, 20);
            this.password.TabIndex = 17;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            this.password.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.password.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPasswordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showPasswordToolStripMenuItem
            // 
            this.showPasswordToolStripMenuItem.CheckOnClick = true;
            this.showPasswordToolStripMenuItem.Name = "showPasswordToolStripMenuItem";
            this.showPasswordToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showPasswordToolStripMenuItem.Text = "&Show Password";
            this.showPasswordToolStripMenuItem.Click += new System.EventHandler(this.showPasswordToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Username:";
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.userName.Location = new System.Drawing.Point(67, 2);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(246, 20);
            this.userName.TabIndex = 19;
            this.userName.WatermarkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.userName.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.userName.WatermarkText = "Username";
            // 
            // RunAsUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.domainName);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(2048, 76);
            this.MinimumSize = new System.Drawing.Size(323, 76);
            this.Name = "RunAsUserDetails";
            this.Size = new System.Drawing.Size(323, 76);
            this.Load += new System.EventHandler(this.RunAsUserDetails_Load);
            this.SizeChanged += new System.EventHandler(this.RunAsUserDetails_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox domainName;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPasswordToolStripMenuItem;
        private System.Windows.Forms.Controls.WatermarkTextBox userName;
    }
}
