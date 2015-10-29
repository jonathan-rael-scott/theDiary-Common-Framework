using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HttpChecker
{
    public interface IRequestItem
    {
        #region Property Definitions
        IRequestItem Parent { get; set; }

        string ItemName { get; set; }
        #endregion
    }
}
