using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public sealed class HostComment
           : IEntry
    {
        public HostComment(string text)
        {
            this.EntryId = Guid.NewGuid();
            this.LineText = text;
        }
        public Guid EntryId
        {
            get; private set;
        }
        public string LineText
        {
            get; private set;
        }
    }
}
