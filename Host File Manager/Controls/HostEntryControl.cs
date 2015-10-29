using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace theDiary.Tools.Development.HostFileManager.Controls
{
    public partial class HostEntryControl : UserControl, IDialogFormControl
    {
        #region Constructors
        public HostEntryControl()
        {
            InitializeComponent();
            this.ipAddress.IPAddressChanged += (s, e) =>
            {
                this.ValidateOkButton(!this.ipAddress.IsEmpty);
            };

            this.hostName.TextChanged += (s, e) =>
            {
                this.ValidateOkButton(!string.IsNullOrWhiteSpace(this.hostName.Text));
            };

            this.dialogClosingDelegate = new FormClosingEventHandler(delegate(object sender, FormClosingEventArgs e)
            {
                if (((sender as Form).DialogResult != System.Windows.Forms.DialogResult.OK))
                    return;

                if (MessageBox.Show(this, "Do you want to save the Host Entry?", "Save Host Entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    HostsFileHelper.SetEntry(new HostEntry(this.Destination, this.IPAddress, this.Description));
                }
                else
                {
                    this.SelectedItem = null;
                }
            });
            this.Title = "Add Host Entry...";
            this.enabledPanel.Visible = false;
        }

        public HostEntryControl(HostEntry hostEntry)
            : this()
        {
            if (hostEntry == null)
                return;
            this.Description = hostEntry.Description;
            this.IPAddress = hostEntry.IPAddress;
            this.Active = hostEntry.Enabled;
            this.Destination = hostEntry.Destination;
            this.SelectedItem = hostEntry;
            this.Title = "Edit Host Entry...";
            this.enabledPanel.Visible = true;
        }
        #endregion

        #region Private Declarations
        private FormClosingEventHandler dialogClosingDelegate;
        #endregion

        #region Public Events
        public event EventHandler EnableOkButton;

        public event EventHandler DisableOkButton;
        #endregion

        #region Public Properties
        public HostEntry SelectedItem { get; private set; }
        
        public string Destination
        {
            get
            {
                return this.hostName.Text;
            }
            set
            {
                this.hostName.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description.Text;
            }
            set
            {
                this.description.Text = value;
            }
        }

        public bool Active
        {
            get
            {
                return this.enabled.Checked;
            }
            set
            {
                this.enabled.Checked = value;
            }
        }

        public IPAddress IPAddress
        {
            get
            {
                return this.ipAddress.Value;
            }
            set
            {
                this.ipAddress.Value = value;
            }

        }

        public FormClosingEventHandler DialogClosingDelegate
        {
            get
            {
                return this.dialogClosingDelegate;
            }
        }

        public string Title { get; private set; }
        #endregion

        #region Private Methods & Functions
        private void ValidateOkButton(bool result)
        {
            if (!result && this.DisableOkButton != null)
            {
                this.DisableOkButton(this, new EventArgs());
            }
            else if (result && this.EnableOkButton != null)
            {
                this.EnableOkButton(this, new EventArgs());
            }
        }
        #endregion
    }
}
