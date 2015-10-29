using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace Guid_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += (s, e) =>
            {
                this.newGuid_Click(this.newGuid, EventArgs.Empty);
            };
            
        }

        public Guid CurrentGuid { get; private set; }

        private void newGuid_Click(object sender, EventArgs e)
        {
            this.CurrentGuid = Guid.NewGuid();
            this.radioButton1_CheckedChanged(this.radioButton1, EventArgs.Empty);
            this.radioButton1_CheckedChanged(this.radioButton2, EventArgs.Empty);
            this.radioButton1_CheckedChanged(this.radioButton3, EventArgs.Empty);
            this.radioButton1_CheckedChanged(this.radioButton4, EventArgs.Empty);
            this.radioButton1_CheckedChanged(this.radioButton5, EventArgs.Empty);
            this.radioButton1_CheckedChanged(this.radioButton6, EventArgs.Empty);
            this.radioButton1_CheckedChanged(this.radioButton7, EventArgs.Empty);
        }

        private void copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.guidResult.Text);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GuidRadioButton choice = (GuidRadioButton) sender;
            if (choice.Checked)
                this.guidResult.Text = choice.CreateFormatedGuid(this.CurrentGuid);
        }
    }

    public class GuidRadioButton
        : RadioButton
    {
        public GuidRadioButton()
            : base()
        {
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string GuidFormat
        {
            get
            {
                return this.Tag as string;
            }
            set
            {
                this.Tag = value;
            }
        }

        public string CreateFormatedGuid()
        {
            return this.CreateFormatedGuid(Guid.NewGuid());
        }

        public string CreateFormatedGuid(Guid guid)
        {
            if (string.IsNullOrEmpty(this.GuidFormat) 
                || string.IsNullOrEmpty(this.GuidFormat.Trim()))
                return guid.ToString();

            string returnValue = this.GuidFormat.Replace("{GUID:VALUE}", guid.ToString("D"));
            returnValue = returnValue.Replace("{GUID:XVALUE}", guid.ToString("X"));
            returnValue = returnValue.Replace("{GUID:NVALUE}", guid.ToString("N"));
            returnValue = returnValue.Replace("{GUID:BVALUE}", guid.ToString("B"));
            returnValue = returnValue.Replace("{GUID:PVALUE}", guid.ToString("P"));

            return returnValue;
        }
    }
}
