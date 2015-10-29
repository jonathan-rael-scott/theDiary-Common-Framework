namespace Iterative.Tools.RunAs.Controls
{
    partial class AddApplication
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
            this.SelectApplicationButton = new System.Windows.Forms.Button();
            this.applicationPath = new System.Windows.Forms.TextBox();
            this.applicationDisplayName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectApplicationButton
            // 
            this.SelectApplicationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectApplicationButton.Location = new System.Drawing.Point(313, -1);
            this.SelectApplicationButton.Name = "SelectApplicationButton";
            this.SelectApplicationButton.Size = new System.Drawing.Size(27, 23);
            this.SelectApplicationButton.TabIndex = 5;
            this.SelectApplicationButton.Text = "...";
            this.SelectApplicationButton.UseVisualStyleBackColor = true;
            this.SelectApplicationButton.Click += new System.EventHandler(this.SelectApplicationButton_Click);
            // 
            // applicationPath
            // 
            this.applicationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationPath.Location = new System.Drawing.Point(84, 1);
            this.applicationPath.MinimumSize = new System.Drawing.Size(223, 20);
            this.applicationPath.Name = "applicationPath";
            this.applicationPath.Size = new System.Drawing.Size(223, 20);
            this.applicationPath.TabIndex = 3;
            this.applicationPath.TextChanged += new System.EventHandler(this.applicationPath_TextChanged);
            // 
            // applicationDisplayName
            // 
            this.applicationDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationDisplayName.Location = new System.Drawing.Point(84, 27);
            this.applicationDisplayName.Name = "applicationDisplayName";
            this.applicationDisplayName.Size = new System.Drawing.Size(256, 20);
            this.applicationDisplayName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Display Name:";
            // 
            // AddApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectApplicationButton);
            this.Controls.Add(this.applicationPath);
            this.Controls.Add(this.applicationDisplayName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddApplication";
            this.Size = new System.Drawing.Size(343, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectApplicationButton;
        private System.Windows.Forms.TextBox applicationPath;
        private System.Windows.Forms.TextBox applicationDisplayName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
