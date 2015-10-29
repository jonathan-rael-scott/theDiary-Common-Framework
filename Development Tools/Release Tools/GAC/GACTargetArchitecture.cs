using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.GAC
{
    [Flags]
    public enum GACTargetArchitecture
        : byte
    {
        x32 = 1,

        x64 = 2,
    }
}
