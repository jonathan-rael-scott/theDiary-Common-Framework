namespace theDiary.Tools.Development.HttpChecker.Controls
{
    partial class RequestDetails
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
            this.timeOutTrackBar = new System.Windows.Forms.TrackBar();
            this.destinationUrl = new System.Windows.Forms.Controls.WatermarkTextBox();
            this.timeOut = new System.Windows.Forms.Controls.WatermarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timeOutTrackBar
            // 
            this.timeOutTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeOutTrackBar.LargeChange = 60;
            this.timeOutTrackBar.Location = new System.Drawing.Point(101, 30);
            this.timeOutTrackBar.Maximum = 180;
            this.timeOutTrackBar.Name = "timeOutTrackBar";
            this.timeOutTrackBar.Size = new System.Drawing.Size(138, 45);
            this.timeOutTrackBar.TabIndex = 0;
            this.timeOutTrackBar.TickFrequency = 10;
            this.timeOutTrackBar.ValueChanged += new System.EventHandler(this.timeOutTrackBar_ValueChanged);
            // 
            // destinationUrl
            // 
            this.destinationUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationUrl.Location = new System.Drawing.Point(4, 4);
            this.destinationUrl.Name = "destinationUrl";
            this.destinationUrl.Size = new System.Drawing.Size(235, 20);
            this.destinationUrl.TabIndex = 1;
            this.destinationUrl.WatermarkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.destinationUrl.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.destinationUrl.WatermarkText = "Destination Url";
            // 
            // timeOut
            // 
            this.timeOut.Location = new System.Drawing.Point(4, 31);
            this.timeOut.Name = "timeOut";
            this.timeOut.Size = new System.Drawing.Size(100, 20);
            this.timeOut.TabIndex = 2;
            this.timeOut.WatermarkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.timeOut.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.timeOut.WatermarkText = "Timeout";
            // 
            // RequestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timeOut);
            this.Controls.Add(this.destinationUrl);
            this.Controls.Add(this.timeOutTrackBar);
            this.MaximumSize = new System.Drawing.Size(0, 64);
            this.MinimumSize = new System.Drawing.Size(242, 64);
            this.Name = "RequestDetails";
            this.Size = new System.Drawing.Size(242, 64);
            ((System.ComponentModel.ISupportInitialize)(this.timeOutTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar timeOutTrackBar;
        private System.Windows.Forms.Controls.WatermarkTextBox destinationUrl;
        private System.Windows.Forms.Controls.WatermarkTextBox timeOut;
    }
}
