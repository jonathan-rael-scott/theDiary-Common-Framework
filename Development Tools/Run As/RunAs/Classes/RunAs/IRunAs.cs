using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    public interface IApplicationDetail
    {
        #region Property Definitions
        string DisplayName { get; set; }

        string Path { get; set; }
        #endregion
    }

    public interface IRegisteredRunAs
        : IRunAsOther
    {
        Guid RunAsId { get; set; }
    }

    public interface IRunAs
        : IApplicationDetail
    {
        #region Methods & Functions
        void Execute();
        #endregion
    }

    public interface IRunAsOther
        : IRunAs
    {
        void Execute(IRunAsDetails runAsDetails);
    }
}
