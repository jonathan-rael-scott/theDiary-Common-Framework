using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    public class CustomApplicationRunAs
        : IRunAs
    {
        #region Constructors
        public CustomApplicationRunAs(Guid runAsId)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(string.Format("Software\\Iterative\\RunAs\\{0}", runAsId), false);
            if (key == null)
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(string.Format("Software\\Iterative\\RunAs\\{0}", runAsId));

            this.RunAsId = runAsId;
            this.DisplayName = (string)key.GetValue("DisplayName", string.Empty);
            this.Path = (string)key.GetValue("Path", string.Empty);
        }

        public CustomApplicationRunAs(string displayName, string path)
        {
            this.DisplayName = displayName;
            this.Path = path;
        }
        #endregion

        #region Public Properties
        public Guid RunAsId { get; set; }

        public string DisplayName { get; set; }

        public string Path { get; set; }
        #endregion

        #region Public Methods & Functions
        public void Execute()
        {
            RunAsHelper.CreateRunAsProcess(this.Path, null).Start();
        }
#endregion
    }
}
