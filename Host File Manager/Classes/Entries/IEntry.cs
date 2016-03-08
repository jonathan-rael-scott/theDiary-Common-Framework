using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public interface IEntry
    {
        Guid EntryId
        {
            get;
        }

        string LineText
        {
            get;
        }
    }
}
