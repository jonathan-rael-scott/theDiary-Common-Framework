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
    public partial class RunAsUserDetails
        : UserControl, IDialogFormControl, IRunAsDetails, INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Constructors
        public RunAsUserDetails()
        {
            InitializeComponent();
        }
        #endregion

        public event EventHandler EnableOkButton;

        public event EventHandler DisableOkButton;

        #region Public Properties
        public string Title
        {
            get
            {
                return "Authentication Details...";
            }
        }

        public bool DataBind { get; set; }

        public string UserName
        {
            get
            {
                return this.userName.Text;
            }
            set
            {
                if (this.PropertyChanging != null)
                    this.PropertyChanging(this, new PropertyChangingEventArgs("UserName"));

                this.userName.Text = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        public string DomainName
        {
            get
            {
                return this.domainName.Text;
            }
            set
            {
                if (this.PropertyChanging != null)
                    this.PropertyChanging(this, new PropertyChangingEventArgs("DomainName"));

                this.domainName.Text = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("DomainName"));
            }
        }

        public string Password
        {
            get
            {
                return this.password.Text;
            }
            set
            {
                if (this.PropertyChanging != null)
                    this.PropertyChanging(this, new PropertyChangingEventArgs("Password"));

                this.password.Text = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        #endregion

        #region Private Methods & Functions
        private void SetTooltip(object sender, EventArgs e)
        {
            this.AccessibleDescription = ((Control)sender).AccessibleDescription;
        }

        private void ClearTooltip(object sender, EventArgs e)
        {
            this.AccessibleDescription = string.Empty;
        }

        private void RunAsUserDetails_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height > 76)
                this.Height = 76;
        }

        private void RunAsUserDetails_Load(object sender, EventArgs e)
        {
            if (!this.DataBind)
                return;


        }
        #endregion

        public FormClosingEventHandler DialogClosingDelegate
        {
            get { return null; }
        }

        private void UserDetailsChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.DomainName) && !string.IsNullOrWhiteSpace(this.UserName))
            {
                if (this.EnableOkButton != null)
                    this.EnableOkButton(this, new EventArgs());
            }
            else
            {
                if (this.DisableOkButton != null)
                    this.DisableOkButton(this, new EventArgs());
            }
        }



        string IRunAsDetails.UserName
        {
            get 
            { 
                return this.UserName; 
            }
        }

        string IRunAsDetails.Password
        {
            get
            {
                return this.Password;
            }
        }

        string IRunAsDetails.DomainName
        {
            get
            {
                return this.DomainName;
            }
        }

        private void showPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.password.PasswordChar = !showPasswordToolStripMenuItem.Checked ? 'l' : '\0';
            if (this.password.PasswordChar == '\0')
            {
                this.password.Font = SystemFonts.DefaultFont;
            }
            else
            {
                this.password.Font = new System.Drawing.Font("Wingdings", SystemFonts.DefaultFont.Size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.showPasswordToolStripMenuItem.Checked = (this.password.PasswordChar == '\0');
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs("Password"));

        }
    }
}
