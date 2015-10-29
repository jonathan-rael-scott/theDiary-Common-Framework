using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    public interface IRunAsDetails
    {
        string UserName { get; }
        string Password { get; }
        string DomainName { get; }
    }
}
