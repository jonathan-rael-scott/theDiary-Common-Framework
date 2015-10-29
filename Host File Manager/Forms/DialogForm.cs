using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace theDiary.Tools.Development.HostFileManager
{
    public partial class DialogForm
        : Form
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        public DialogForm(IDialogFormControl dialogControl)
            : this()
        {
            this.DialogControl = dialogControl;
        }

        private IDialogFormControl dialogControl;

        public IDialogFormControl DialogControl
        {
            get
            {
                return this.dialogControl;
            }
            set
            {
                if (this.dialogControl != null)
                {
                    this.dialogControl.EnableOkButton -= dialogControl_EnableOkButton;
                    this.dialogControl.DisableOkButton -= dialogControl_DisableOkButton;
                    this.FormClosing -= this.dialogControl.DialogClosingDelegate;
                    this.DialogControlContainer.Controls.Clear();
                }
                this.dialogControl = value;
                if (this.dialogControl != null)
                    this.InitializeLayout();
            }
        }

        private void InitializeLayout()
        {
            IDialogFormIcon dialogFormIcon = this.dialogControl as IDialogFormIcon;
            this.InitializeIcon(dialogFormIcon);
            this.dialogControl.EnableOkButton += dialogControl_EnableOkButton;
            this.dialogControl.DisableOkButton += dialogControl_DisableOkButton;
            this.FormClosing += this.dialogControl.DialogClosingDelegate;
            this.Text = this.dialogControl.Title;
            this.DialogControlContainer.Controls.Add((Control)this.dialogControl);
        }

        private void InitializeIcon(IDialogFormIcon dialogFormIcon)
        {
            this.ShowIcon = (dialogFormIcon != null);
            if (dialogFormIcon == null)
                return;
            
            this.Icon = dialogFormIcon.DialogIcon;            
        }

        void dialogControl_DisableOkButton(object sender, EventArgs e)
        {
            this.OkButton.Enabled = false;
        }

        void dialogControl_EnableOkButton(object sender, EventArgs e)
        {
            this.OkButton.Enabled = true;
        }
    }
}
