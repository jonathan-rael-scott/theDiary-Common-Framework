namespace theDiary.Tools.Development.HostFileManager.Controls
{
    partial class OptionsControl
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.confirmWhenExiting = new System.Windows.Forms.CheckBox();
            this.autoSave = new System.Windows.Forms.CheckBox();
            this.minimizeToTaskbar = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(468, 297);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.minimizeToTaskbar);
            this.tabPage1.Controls.Add(this.autoSave);
            this.tabPage1.Controls.Add(this.confirmWhenExiting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(460, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(460, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // confirmWhenExiting
            // 
            this.confirmWhenExiting.AutoSize = true;
            this.confirmWhenExiting.Location = new System.Drawing.Point(6, 6);
            this.confirmWhenExiting.Name = "confirmWhenExiting";
            this.confirmWhenExiting.Size = new System.Drawing.Size(123, 17);
            this.confirmWhenExiting.TabIndex = 0;
            this.confirmWhenExiting.Text = "Confirm when exiting";
            this.confirmWhenExiting.UseVisualStyleBackColor = true;
            // 
            // autoSave
            // 
            this.autoSave.AutoSize = true;
            this.autoSave.Location = new System.Drawing.Point(6, 29);
            this.autoSave.Name = "autoSave";
            this.autoSave.Size = new System.Drawing.Size(158, 17);
            this.autoSave.TabIndex = 1;
            this.autoSave.Text = "Automatically save changes";
            this.autoSave.UseVisualStyleBackColor = true;
            // 
            // minimizeToTaskbar
            // 
            this.minimizeToTaskbar.AutoSize = true;
            this.minimizeToTaskbar.Location = new System.Drawing.Point(6, 52);
            this.minimizeToTaskbar.Name = "minimizeToTaskbar";
            this.minimizeToTaskbar.Size = new System.Drawing.Size(120, 17);
            this.minimizeToTaskbar.TabIndex = 2;
            this.minimizeToTaskbar.Text = "Minimize to Taskbar";
            this.minimizeToTaskbar.UseVisualStyleBackColor = true;
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(468, 297);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox autoSave;
        private System.Windows.Forms.CheckBox confirmWhenExiting;
        private System.Windows.Forms.CheckBox minimizeToTaskbar;
    }
}
