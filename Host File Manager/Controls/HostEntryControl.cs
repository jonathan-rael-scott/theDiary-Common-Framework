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
            EventHandler validateOkButton = (s, e) =>
            {
                this.ValidateOkButton(!this.ipAddress.IsEmpty);
                this.ValidateOkButton(!string.IsNullOrWhiteSpace(this.hostName.Text));
            };
            this.ipAddress.IPAddressChanged += validateOkButton;
            this.hostName.TextChanged += validateOkButton;
            this.description.TextChanged += validateOkButton;
            this.enabled.CheckedChanged += validateOkButton;

            this.dialogClosingDelegate = new FormClosingEventHandler(delegate (object sender, FormClosingEventArgs e)
            {
                if (((sender as Form).DialogResult != System.Windows.Forms.DialogResult.OK))
                    return;
                if (MessageBox.Show(this, "Do you want to save the Host Entry?", "Save Host Entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    HostsFileHelper.SetEntry(this.SelectedItem);
            });


            this.Load += (s, e) =>
            {
                this.enabledPanel.Visible = !this.SelectedItem.IsNew;
                this.Title = this.SelectedItem.IsNew ? "Add Host Entry..." : "Edit Host Entry...";

                this.ipAddress.DataBindings.Add(new Binding("Value", this.SelectedItem, "IPAddress"));
                this.description.DataBindings.Add(new Binding("Text", this.SelectedItem, "Description"));
                this.hostName.DataBindings.Add(new Binding("Text", this.SelectedItem, "Destination"));
                this.enabled.DataBindings.Add(new Binding("Checked", this.SelectedItem, "Enabled"));
            };

        }

        public HostEntryControl(HostEntry hostEntry)
            : this()
        {
            if (hostEntry == null)
                throw new ArgumentNullException(nameof(hostEntry));

            //this.Description = hostEntry.Description;
            //this.IPAddress = hostEntry.IPAddress;
            //this.Active = hostEntry.Enabled;
            //this.Destination = hostEntry.Destination;
            this.SelectedItem = hostEntry;
        }
        #endregion

        #region Private Declarations
        private FormClosingEventHandler dialogClosingDelegate;
        private HostEntry selectedItem;
        #endregion

        #region Public Events
        public event EventHandler EnableOkButton;

        public event EventHandler DisableOkButton;
        #endregion

        #region Public Properties

        public HostEntry SelectedItem
        {
            get
            {
                if (this.selectedItem == null)
                    this.selectedItem = new HostEntry();
                return this.selectedItem;
            }
            private set
            {
                if (this.selectedItem == value)
                    return;

                this.selectedItem = value;
            }
        }

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

        public string Title
        {
            get; private set;
        }
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
