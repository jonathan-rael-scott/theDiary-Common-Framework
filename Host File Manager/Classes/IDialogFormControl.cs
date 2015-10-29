using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theDiary.Tools.Development.HostFileManager
{
    public interface IDialogFormControl
    {
        #region Event Definitions
        event EventHandler EnableOkButton;

        event EventHandler DisableOkButton;
        #endregion

        #region Property Definitions
        System.Windows.Forms.FormClosingEventHandler DialogClosingDelegate { get; }

        string Title { get; }
        #endregion
    }
}
