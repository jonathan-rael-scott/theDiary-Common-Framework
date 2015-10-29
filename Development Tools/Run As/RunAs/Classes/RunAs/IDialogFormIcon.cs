using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    public interface IDialogFormIcon
        : IDialogFormControl
    {
        #region Property Definitions
        Icon DialogIcon { get; }
        #endregion
    }
}
