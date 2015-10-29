using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Diagnostics
{
    public static class ProcessExtensions
    {
        public static bool IsElevated(this Process process)
        {
            return System.Security.UAC.UACHelper.IsElevatedProcess(process);
        }
    }
}
