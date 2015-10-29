using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HttpChecker
{
    public interface IRequestGroup
        : IRequestItem
    {
        #region Property Definitions
        IEnumerable<IRequestItem> Children { get; }
        #endregion
    }
}
