using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theDiary.Tools.Development.HostFileManager.Controls
{
    public partial class OptionsControl : UserControl, IDialogFormControl
    {
        public OptionsControl()
        {
            InitializeComponent();
            this.autoSave.Checked = Configuration.Instance.AutoSave; 
            this.minimizeToTaskbar.Checked = Configuration.Instance.MinimizeToTaskbar;
            this.confirmWhenExiting.Checked = Configuration.Instance.ConfirmWhenExiting;
            this.DialogClosingDelegate += (s, e) =>
            {
                Configuration.Instance.AutoSave = this.autoSave.Checked;
                Configuration.Instance.MinimizeToTaskbar = this.minimizeToTaskbar.Checked;
                Configuration.Instance.ConfirmWhenExiting = this.confirmWhenExiting.Checked;
            };
            this.ParentForm.Shown +=(s,e)=>this.EnableOkButton(s, e);
        }

        private void ValueChangedHandler(object sender, EventArgs e)
        {
            bool changed = typeof (Configuration).GetProperties().Any(property =>
            {
                Control control = this.Controls.Find(
                    string.Format("{0}{1}",
                        Char.ToLower(property.Name[0]),
                        property.Name.Substring(1)), true)
                    .FirstOrDefault();

                if (control == null)
                    return false;
                return property.GetValue(Configuration.Instance, null) != control.Tag;
            });
            if (changed)
            {
                this.EnableOkButton(this, EventArgs.Empty);
            }
            else
            {
                this.DisableOkButton(this, EventArgs.Empty);
            }
    }

    public FormClosingEventHandler DialogClosingDelegate { get; private set; }

        public string Title
        {
            get { return "Options"; }
        }

        public event EventHandler DisableOkButton;
        public event EventHandler EnableOkButton;
    }
}
