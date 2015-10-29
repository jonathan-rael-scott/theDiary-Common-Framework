namespace theDiary.Tools.Development.HostFileManager.Controls
{
    partial class IPAddressControl
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
            this.part1 = new System.Windows.Forms.TextBox();
            this.part2 = new System.Windows.Forms.TextBox();
            this.part3 = new System.Windows.Forms.TextBox();
            this.part4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // part1
            // 
            this.part1.Location = new System.Drawing.Point(0, 0);
            this.part1.Name = "part1";
            this.part1.Size = new System.Drawing.Size(40, 20);
            this.part1.TabIndex = 0;
            this.part1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateValue);
            // 
            // part2
            // 
            this.part2.Location = new System.Drawing.Point(46, 0);
            this.part2.Name = "part2";
            this.part2.Size = new System.Drawing.Size(40, 20);
            this.part2.TabIndex = 1;
            this.part2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateValue);
            // 
            // part3
            // 
            this.part3.Location = new System.Drawing.Point(92, 0);
            this.part3.Name = "part3";
            this.part3.Size = new System.Drawing.Size(40, 20);
            this.part3.TabIndex = 2;
            this.part3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateValue);
            // 
            // part4
            // 
            this.part4.Location = new System.Drawing.Point(138, 0);
            this.part4.Name = "part4";
            this.part4.Size = new System.Drawing.Size(40, 20);
            this.part4.TabIndex = 3;
            this.part4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateValue);
            // 
            // IPAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.part4);
            this.Controls.Add(this.part3);
            this.Controls.Add(this.part2);
            this.Controls.Add(this.part1);
            this.Name = "IPAddressControl";
            this.Size = new System.Drawing.Size(178, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox part1;
        private System.Windows.Forms.TextBox part2;
        private System.Windows.Forms.TextBox part3;
        private System.Windows.Forms.TextBox part4;
    }
}
