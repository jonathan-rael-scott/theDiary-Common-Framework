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
    public partial class SearchControl
        : UserControl, IDialogFormControl
    {
        public SearchControl()
        {
            InitializeComponent();

            this.dialogClosingDelegate = new FormClosingEventHandler(delegate(object sender, FormClosingEventArgs e)
            {
                if (((sender as Form).DialogResult != System.Windows.Forms.DialogResult.OK))
                    return;
            });
        }

        #region Private Declarations
        private FormClosingEventHandler dialogClosingDelegate;
        #endregion

        #region Public Events
        public event EventHandler EnableOkButton;

        public event EventHandler DisableOkButton;
        #endregion

        #region Public Properties
        public FormClosingEventHandler DialogClosingDelegate
        {
            get 
            { 
                return this.dialogClosingDelegate; 
            }
        }

        public string Title { get; private set; }
        #endregion
    }
}
