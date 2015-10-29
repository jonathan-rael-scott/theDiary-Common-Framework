using theDiary.Tools.Development.GAC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace theDiary.Tools.Development
{
    public static class GlobalAssemblyCacheUtility
    {
        #region Private Static Declarations
        private static string sdkVersionPattern = "(V)([+-]?\\d*\\.\\d+)(?![-+0-9\\.])(A)";

        private static string SigningProcessArgumentsFormat = @"/f ""{Signing:CertificatePath}"" /p ""{Signing:SigningPassword}"" /tr ""{Signing:SigningTimestampUrl}"" /td SHA256 ""{Signing:File}""";
        private static string GACInstallProcessArgumentsFormat = "{1} {0} {2}";

        private static string ForceReInstallArgument = "/f";
        private static string InstallArgument = "/i";
        private static string UninstallArgument = "/u";
        private static string ListArgument = "/l";
        #endregion

        #region Public Static Read-Only Properties
        public static string GACUtilPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(System.Configuration.ConfigurationManager.AppSettings["GACUtilPath"]))
                    return System.Configuration.ConfigurationManager.AppSettings["GACUtilPath"];

                return GlobalAssemblyCacheUtility.GetGACUtilFilePath();

            }
        }
        #endregion

        #region Public Methods & Functions
        public static void AddToGlobalAssembly(string fileName, GACTargetArchitecture gacTarget, bool force = false)
        {
            ProcessStartInfo psi = new ProcessStartInfo(GlobalAssemblyCacheUtility.GACUtilPath, GlobalAssemblyCacheUtility.GenerateGlobalAssemblyCacheArguments(fileName, true, force));
            psi.WorkingDirectory = System.IO.Path.GetDirectoryName(fileName);
            Process signProcess = Process.Start(psi);
            signProcess.WaitForExit();
        }

        public static void RemoveFromGlobalAssembly(string fileName, GACTargetArchitecture gacTarget)
        {
            ProcessStartInfo psi = new ProcessStartInfo(GlobalAssemblyCacheUtility.GACUtilPath, GlobalAssemblyCacheUtility.GenerateGlobalAssemblyCacheArguments(fileName, false));
            psi.WorkingDirectory = System.IO.Path.GetDirectoryName(fileName);
            Process signProcess = Process.Start(psi);
            signProcess.WaitForExit();
        }

        public static GACFileCollection LoadGlobalAssemblyCache(AsyncCallback callBack)
        {
            GACFileCollection returnValue = new GACFileCollection();
            ProcessStartInfo psi = new ProcessStartInfo(GlobalAssemblyCacheUtility.GACUtilPath, "/l");
            psi.EnvironmentVariables["Path"] += System.IO.Path.GetDirectoryName(GlobalAssemblyCacheUtility.GACUtilPath);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;

            Process process = new Process();
            process.StartInfo = psi;

            process.OutputDataReceived += (s, e) =>
            {

                if (string.IsNullOrWhiteSpace(e.Data))
                    return;
                try
                {
                    returnValue.Add(new AssemblyName(e.Data));
                }
                catch
                {
                }
            };

            process.EnableRaisingEvents = true;
            bool processFinished = false;
            process.Exited += (s, e) =>
            {
                processFinished = true;
            };
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();

            return returnValue;

        }
        #endregion

        #region Private Static Methods & Functions
        private static string GetGACUtilFilePath()
        {
            string rootFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(rootFolder);

            var sdkFolder = d.GetDirectories("Microsoft SDKs").FirstOrDefault();
            if (sdkFolder != null)
            {
                var msd = sdkFolder.GetDirectories("Windows").FirstOrDefault();
                if (msd != null)
                {
                    Regex p = new Regex(sdkVersionPattern);
                    var vd = msd.GetDirectories().Where(d1 => p.IsMatch(d1.Name)).OrderByDescending(d1 => float.Parse(p.Match(d1.Name).Groups[2].Value)).Where(d1 => d1.GetFiles("gacutil.exe", System.IO.SearchOption.AllDirectories).Count() > 0).FirstOrDefault();
                    if (vd != null)
                        return vd.GetFiles("gacutil.exe", System.IO.SearchOption.AllDirectories).FirstOrDefault().FullName;
                }
            }
            return null;
        }

        private static string GenerateGACUtilArguments(GACUtilCallType callType, string fileName = null)
        {
            if (callType == GACUtilCallType.List)
                return GlobalAssemblyCacheUtility.ListArgument;

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("fileName");

            switch (callType)
            {
                case GACUtilCallType.Install:
                    return string.Format(GlobalAssemblyCacheUtility.GACInstallProcessArgumentsFormat, fileName, GlobalAssemblyCacheUtility.InstallArgument, string.Empty).Trim();
                case GACUtilCallType.ForceInstall:
                    return string.Format(GlobalAssemblyCacheUtility.GACInstallProcessArgumentsFormat, fileName, GlobalAssemblyCacheUtility.InstallArgument, GlobalAssemblyCacheUtility.ForceReInstallArgument).Trim();
                default:
                    return string.Format(GlobalAssemblyCacheUtility.GACInstallProcessArgumentsFormat, fileName, GlobalAssemblyCacheUtility.UninstallArgument, string.Empty).Trim();
            }
        }

        private static string GenerateGlobalAssemblyCacheArguments(string fileName, bool install, bool force = false)
        {
            return string.Format(GlobalAssemblyCacheUtility.GACInstallProcessArgumentsFormat, fileName, (install) ? InstallArgument : UninstallArgument, (install && force) ? ForceReInstallArgument : string.Empty).Trim();
        }
        #endregion

        private enum GACUtilCallType
        {
            Install,

            ForceInstall,

            Remove,

            List,
        }
    }
}
