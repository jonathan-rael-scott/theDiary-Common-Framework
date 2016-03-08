using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public class ToolstripButtonAction<T>
        : ClientActionGroupBase<T>, IClientControlAction<System.Windows.Forms.ToolStripButton>
    {
        #region Constructors
        public ToolstripButtonAction(string groupName, string actionName, ActionEventHandler executeHandler, dynamic additional = null)
            : base(groupName, actionName, executeHandler)
        {
            this.Additional = additional;
        }

        public ToolstripButtonAction(string actionName, ActionEventHandler executeHandler, dynamic additional = null)
            : base(null, actionName, executeHandler)
        {
            this.Additional = additional;
        }
        #endregion

        #region Private Declarations
        private string text;
        #endregion

        #region Public Properties
        public string Text
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.text))
                    return this.ActionName;

                return this.text;
            }
        }

        #endregion

        #region Public Methods & Functions
        public void SetControl(System.Windows.Forms.ToolStripButton control)
        {
            control.Text = this.Text;

            control.Click += (s, e) => this.Execute(s, new ActionEventArgs(this));
            this.SetFromAdditional(control);
        }
        #endregion
    }
}
