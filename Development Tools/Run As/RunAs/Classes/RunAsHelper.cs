using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    internal static class RunAsHelper
    {
        #region Private Static Constants
        private static readonly string RunAsArgumentsFormat = "\"{0}\" \"{2}\" \"{1}\" \"{3}\"";
        #endregion

        #region Internal Static Methods & Functions
        internal static System.Diagnostics.Process CreateRunAsProcess(string applicationPath, IRunAsDetails runAsDetails)
        {
            if (runAsDetails == null)
                runAsDetails = Configuration.Instance;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(RunAsHelper.GetRunAsPath());
            process.StartInfo.Arguments = string.Format(RunAsHelper.RunAsArgumentsFormat, runAsDetails.UserName, runAsDetails.Password, runAsDetails.DomainName, applicationPath);
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            
            return process;
        }
        
        internal static string GetRunAsPath()
        {
            string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "RunAs.exe");
            if (!System.IO.File.Exists(fileName))
            {
                using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    byte[] runAsBytes = RunAsHelper.GetRunAsBytes();
                    stream.Write(runAsBytes, 0, runAsBytes.Length);
                }
            }

            return fileName;
        }

        internal static IEnumerable<IRunAs> GetAvailableRunAsApplications()
        {
            foreach (Guid runAsId in ConfigurationHelper.GetAvailableRunAsIds())
                yield return new RegisteredRunAs(runAsId);

            if (Configuration.Instance.AllowCustomApplicationRunAs)
                yield return new SelectApplicationRunAs();
        }
        #endregion

        private static byte[] GetRunAsBytes()
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream resFilestream = a.GetManifestResourceStream("Iterative.Tools.RunAs.Resources.RunAs.exe"))
            {
                if (resFilestream == null) return null;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
}
