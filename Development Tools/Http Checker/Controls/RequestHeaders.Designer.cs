namespace theDiary.Tools.Development.HttpChecker.Controls
{
    partial class RequestHeaders
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ParameterName = new System.Windows.Forms.Controls.WatermarkTextBox();
            this.ParameterValue = new System.Windows.Forms.Controls.WatermarkTextBox();
            this.UpdateValue = new System.Windows.Forms.Button();
            this.RemoveValue = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.96217F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.037825F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 423);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(608, 382);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.UpdateValue);
            this.panel1.Controls.Add(this.RemoveValue);
            this.panel1.Location = new System.Drawing.Point(3, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 29);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ParameterName);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ParameterValue);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(430, 29);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 7;
            // 
            // ParameterName
            // 
            this.ParameterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParameterName.Location = new System.Drawing.Point(0, 4);
            this.ParameterName.Name = "ParameterName";
            this.ParameterName.Size = new System.Drawing.Size(124, 20);
            this.ParameterName.TabIndex = 0;
            this.ParameterName.WatermarkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ParameterName.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.ParameterName.WatermarkText = "Name";
            // 
            // ParameterValue
            // 
            this.ParameterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParameterValue.Location = new System.Drawing.Point(0, 4);
            this.ParameterValue.Name = "ParameterValue";
            this.ParameterValue.Size = new System.Drawing.Size(302, 20);
            this.ParameterValue.TabIndex = 1;
            this.ParameterValue.WatermarkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ParameterValue.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.ParameterValue.WatermarkText = "Value";
            // 
            // UpdateValue
            // 
            this.UpdateValue.Location = new System.Drawing.Point(436, 4);
            this.UpdateValue.Name = "UpdateValue";
            this.UpdateValue.Size = new System.Drawing.Size(88, 23);
            this.UpdateValue.TabIndex = 5;
            this.UpdateValue.Text = "Add / Update";
            this.UpdateValue.UseVisualStyleBackColor = true;
            this.UpdateValue.Click += new System.EventHandler(this.UpdateValue_Click);
            // 
            // RemoveValue
            // 
            this.RemoveValue.Location = new System.Drawing.Point(530, 4);
            this.RemoveValue.Name = "RemoveValue";
            this.RemoveValue.Size = new System.Drawing.Size(75, 23);
            this.RemoveValue.TabIndex = 6;
            this.RemoveValue.Text = "Remote";
            this.RemoveValue.UseVisualStyleBackColor = true;
            this.RemoveValue.Click += new System.EventHandler(this.RemoveValue_Click);
            // 
            // RequestHeaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RequestHeaders";
            this.Size = new System.Drawing.Size(614, 423);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Controls.WatermarkTextBox ParameterName;
        private System.Windows.Forms.Controls.WatermarkTextBox ParameterValue;
        private System.Windows.Forms.Button UpdateValue;
        private System.Windows.Forms.Button RemoveValue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
