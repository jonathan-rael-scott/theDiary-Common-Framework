using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    public class SelectApplicationRunAs
        : IRunAs
    {
        public string DisplayName
        {
            get
            {
                return "Select Application...";
            }
            set
            {
            }
        }

        public Action<bool> ExecuteHandler { private get; set; }
        
        public void Execute()
        {
            if (this.ExecuteHandler != null)
                this.ExecuteHandler(true);
        }

        public string Path { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.DisplayName))
                return System.IO.Path.GetFileName(this.Path);

            return this.DisplayName;
        }
    }
}
