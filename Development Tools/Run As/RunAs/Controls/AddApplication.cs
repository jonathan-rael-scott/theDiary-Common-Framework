using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iterative.Tools.RunAs.Controls
{
    public partial class AddApplication
        : UserControl, IDialogFormControl
    {
        #region Constructors
        public AddApplication()
        {
            InitializeComponent();
            this.dialogClosingDelegate = new FormClosingEventHandler(delegate(object sender, FormClosingEventArgs e)
            {
                if (((sender as Form).DialogResult != System.Windows.Forms.DialogResult.OK))
                    return;

                if (MessageBox.Show(this, "Do you want to add this application to the RunAs list?", "Save Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    RegisteredRunAs runAs = new RegisteredRunAs(this.DisplayName, this.Path);
                    runAs.Save();
                    this.SelectedApplication = runAs;
                }
                else
                {
                    this.SelectedApplication = new CustomApplicationRunAs(this.DisplayName, this.Path);
                }
            });
        }
        #endregion

        private FormClosingEventHandler dialogClosingDelegate;

        #region Public Events
        public event EventHandler EnableOkButton;

        public event EventHandler DisableOkButton;
        #endregion

        #region Public Methods & Functions
        public IRunAs SelectedApplication { get; private set; }

        public string Path
        {
            get
            {
                return this.applicationPath.Text;
            }
            set
            {
                this.applicationPath.Text = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.applicationDisplayName.Text;
            }
            set
            {
                this.applicationDisplayName.Text = value;
            }
        }


        public string Title
        {
            get
            {
                return "Select RunAs Application...";
            }
        }
        #endregion

        #region Private Methods & Functions
        private void SelectApplicationButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select RunAs application...";
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.AutoUpgradeEnabled = true;
                ofd.Filter = "Executables|*.exe";
                if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    this.applicationPath.Text = ofd.FileName;
            }
        }

        private void applicationPath_TextChanged(object sender, EventArgs e)
        {
            this.DisplayName = System.IO.Path.GetFileNameWithoutExtension(this.Path);
            bool pathExists = System.IO.File.Exists(this.Path);
            if (pathExists && this.EnableOkButton != null)
            {
                this.EnableOkButton(this, new EventArgs());
            }
            else if (!pathExists && this.DisableOkButton != null)
            {
                this.DisableOkButton(this, new EventArgs());
            }
        }
        #endregion


        public FormClosingEventHandler DialogClosingDelegate
        {
            get 
            {
                return this.dialogClosingDelegate;
            }
        }
    }
}
