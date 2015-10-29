using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    public class RegisteredRunAs
        : IRegisteredRunAs
    {
        #region Constructors
        public RegisteredRunAs(Guid runAsId)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(string.Format("Software\\Iterative\\RunAs\\{0}", runAsId), false);
            if (key == null)
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(string.Format("Software\\Iterative\\RunAs\\{0}", runAsId));

            this.RunAsId = runAsId;
            this.DisplayName = (string)key.GetValue("DisplayName", string.Empty);
            this.Path = (string)key.GetValue("Path", string.Empty);
        }

        public RegisteredRunAs(string displayName, string path)
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
        public void Save()
        {
            if (Guid.Empty.Equals(this.RunAsId))
                this.RunAsId = Guid.NewGuid();

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(string.Format("Software\\Iterative\\RunAs\\{0}", this.RunAsId), true);
            if (key == null)
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(string.Format("Software\\Iterative\\RunAs\\{0}", this.RunAsId));

            key.SetValue("DisplayName", this.DisplayName);
            key.SetValue("Path", this.Path);
            key.Close();
        }

        public void Delete()
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Iterative\\RunAs", true);
            if (key == null)
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(string.Format("Software\\Iterative\\RunAs\\{0}", this.RunAsId));
            key.DeleteSubKey(this.RunAsId.ToString());
            key.Close();
        }

        public void Execute()
        {
            RunAsHelper.CreateRunAsProcess(this.Path, null).Start();
        }

        public void Execute(IRunAsDetails runAsDetails)
        {
            RunAsHelper.CreateRunAsProcess(this.Path, runAsDetails).Start();
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.DisplayName))
                return System.IO.Path.GetFileName(this.Path);

            return this.DisplayName;
        }
        #endregion
    }
}
