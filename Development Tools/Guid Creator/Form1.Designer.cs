namespace Guid_Creator
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.copy = new System.Windows.Forms.Button();
            this.newGuid = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.guidResult = new System.Windows.Forms.Label();
            this.radioButton7 = new Guid_Creator.GuidRadioButton();
            this.radioButton6 = new Guid_Creator.GuidRadioButton();
            this.radioButton5 = new Guid_Creator.GuidRadioButton();
            this.radioButton4 = new Guid_Creator.GuidRadioButton();
            this.radioButton3 = new Guid_Creator.GuidRadioButton();
            this.radioButton2 = new Guid_Creator.GuidRadioButton();
            this.radioButton1 = new Guid_Creator.GuidRadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the desired format below, then select \"Copy\" to copy the results to the cl" +
    "ipboard (the results can then be pasted into your source code).\r\nChoose \"Exit\" w" +
    "hen done.";
            // 
            // copy
            // 
            this.copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copy.Location = new System.Drawing.Point(273, 8);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(75, 23);
            this.copy.TabIndex = 0;
            this.copy.Text = "&Copy";
            this.copy.UseVisualStyleBackColor = true;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // newGuid
            // 
            this.newGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newGuid.Location = new System.Drawing.Point(273, 37);
            this.newGuid.Name = "newGuid";
            this.newGuid.Size = new System.Drawing.Size(75, 23);
            this.newGuid.TabIndex = 1;
            this.newGuid.Text = "&New GUID";
            this.newGuid.UseVisualStyleBackColor = true;
            this.newGuid.Click += new System.EventHandler(this.newGuid_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.Location = new System.Drawing.Point(273, 66);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 2;
            this.exit.Text = "E&xit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton7);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(16, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 189);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GUID Format";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.guidResult);
            this.groupBox2.Location = new System.Drawing.Point(16, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 87);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // guidResult
            // 
            this.guidResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guidResult.Location = new System.Drawing.Point(3, 16);
            this.guidResult.Name = "guidResult";
            this.guidResult.Size = new System.Drawing.Size(326, 68);
            this.guidResult.TabIndex = 0;
            this.guidResult.Text = "label2";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.GuidFormat = "new Guid(\"{GUID:VALUE}\");";
            this.radioButton7.Location = new System.Drawing.Point(6, 157);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(196, 17);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.Tag = "new Guid(\"{GUID:VALUE}\");";
            this.radioButton7.Text = "&7. new Guid(\"xxxxxxxx-xxxx ...xxxx\");";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.GuidFormat = "<Guid(\"{GUID:VALUE}\")>";
            this.radioButton6.Location = new System.Drawing.Point(6, 134);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(182, 17);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Tag = "<Guid(\"{GUID:VALUE}\")>";
            this.radioButton6.Text = "&6. <Guid(\"xxxxxxxx-xxxx ...xxxx\")>";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.GuidFormat = "[Guid(\"{GUID:VALUE}\")]";
            this.radioButton5.Location = new System.Drawing.Point(6, 111);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(176, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Tag = "[Guid(\"{GUID:VALUE}\")]";
            this.radioButton5.Text = "&5. [Guid(\"xxxxxxxx-xxxx ...xxxx\")]";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.GuidFormat = "{GUID:BVALUE}";
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(239, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Tag = "{GUID:BVALUE}";
            this.radioButton4.Text = "&4. Registry Format (ie. {xxxxxxxx-xxxx ...xxxx })";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.GuidFormat = "// {GUID:BVALUE}\r\nstatic const GUID <<name>> = {GUID:XVALUE};";
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(185, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "// {GUID:BVALUE}\r\nstatic const GUID <<name>> = {GUID:XVALUE};";
            this.radioButton3.Text = "&3. static const struct GUID = { ... }";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.GuidFormat = "// {GUID:BVALUE}\r\nDEFINE_GUID(<<name>>, {GUID:XVALUE});";
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(124, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "// {GUID:BVALUE}\r\nDEFINE_GUID(<<name>>, {GUID:XVALUE});";
            this.radioButton2.Text = "&2. DEFINE_GUID(...)";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.GuidFormat = "// {GUID:BVALUE}\r\nIMPLEMENT_OLECREATE(<<class>>, <<external_name>>, {GUID:XVALUE}" +
    ");";
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(185, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "// {GUID:BVALUE}\r\nIMPLEMENT_OLECREATE(<<class>>, <<external_name>>, {GUID:XVALUE}" +
    ");";
            this.radioButton1.Text = "&1. IMPLEMENT_OLECREATE(...)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.copy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.newGuid);
            this.Controls.Add(this.copy);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(376, 414);
            this.Name = "Form1";
            this.Text = "Create GUID";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button copy;
        private System.Windows.Forms.Button newGuid;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label guidResult;
        private GuidRadioButton radioButton7;
        private GuidRadioButton radioButton6;
        private GuidRadioButton radioButton5;
        private GuidRadioButton radioButton4;
        private GuidRadioButton radioButton3;
        private GuidRadioButton radioButton2;
        private GuidRadioButton radioButton1;
    }
}

