using theDiary.Tools.Development.GAC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development
{
    class Program
    {
        private static string SigningProcessArgumentsFormat = @"/f ""{Signing:CertificatePath}"" /p ""{Signing:SigningPassword}"" /tr ""{Signing:SigningTimestampUrl}"" /td SHA256 ""{Signing:File}""";
        private static string SharedFolderPath = "{CopyTo:SharedFolder}\\{CopyTo:FileName}";
        private static string GacInstallProcessArgumentsFormat = "/i {Gac:File} /f";

        static void Main(string[] args)
        {
            GACFileCollection g = GlobalAssemblyCacheUtility.LoadGlobalAssemblyCache(null);

            Console.ReadLine();
        }

        #region Private Process Methods & Functions
        private static void SignFile(string sourcePath, string destinationPath = null)
        {
            destinationPath = destinationPath ?? GenerateSharedFolderPath(sourcePath);
            ProcessStartInfo psi = new ProcessStartInfo("signtool", GenerateSigningArguments(destinationPath));
            psi.EnvironmentVariables["Path"] += System.Configuration.ConfigurationManager.AppSettings["WindowsSDKPath"];
            psi.WorkingDirectory = System.IO.Path.GetDirectoryName(destinationPath);
            Process signProcess = Process.Start(psi);
            signProcess.WaitForExit();
        }

        private static void CopyToSharedFolder(string sourcePath, ref string destinationPath)
        {
            destinationPath = GenerateSharedFolderPath(sourcePath);
            System.IO.File.Copy(sourcePath, destinationPath);
        }

        private static void AddToGlobalAssemblyCache(string sourcePath, string destinationPath = null)
        {
            destinationPath = destinationPath ?? GenerateSharedFolderPath(sourcePath);
            ProcessStartInfo psi = new ProcessStartInfo("gacutil", GenerateGlobalAssemblyCacheArguments(destinationPath));
            psi.EnvironmentVariables["Path"] += System.Configuration.ConfigurationManager.AppSettings["WindowsSDKPath"];
            psi.WorkingDirectory = System.IO.Path.GetDirectoryName(destinationPath);
            Process signProcess = Process.Start(psi);
            signProcess.WaitForExit();
        }
        #endregion

        private static string GenerateSigningArguments(string fileName)
        {
            string certificatePath = GetSigningCertificatePath();
            System.StringBuilder returnValue = new System.StringBuilder(SigningProcessArgumentsFormat);
            returnValue.Replace("'{Signing:CertificatePath}'", certificatePath);
            returnValue.Replace("'{Signing:File}'", fileName);
            returnValue.Replace("{Signing:SigningPassword}", System.Configuration.ConfigurationManager.AppSettings["SigningPassword"]);
            returnValue.Replace("{Signing:SigningTimestampUrl}", System.Configuration.ConfigurationManager.AppSettings["SigningTimestampUrl"]);

            return returnValue.ToString();
        }

        private static string GenerateSharedFolderPath(string sourcePath)
        {
            string fileName = System.IO.Path.GetFileName(sourcePath);
            System.StringBuilder destinationPath = new System.StringBuilder(SharedFolderPath);
            destinationPath.Replace("{CopyTo:SharedFolder}", System.Configuration.ConfigurationManager.AppSettings["SharedFolder"]);
            destinationPath.Replace("{CopyTo:FileName}", fileName);

            return destinationPath.ToString();
        }

        private static string GenerateGlobalAssemblyCacheArguments(string fileName)
        {
            System.StringBuilder returnValue = new System.StringBuilder(SigningProcessArgumentsFormat);
            returnValue.Replace("{Gac:File}", fileName);
            return returnValue.ToString();
        }
        
        private static string GetSigningCertificatePath()
        {
            string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), @"theDiary Consulting.pfx");
            if (!System.IO.File.Exists(fileName))
            {
                using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    byte[] runAsBytes = GetSigningCertificateBytes();
                    stream.Write(runAsBytes, 0, runAsBytes.Length);
                }
            }

            return fileName;
        }

        private static byte[] GetSigningCertificateBytes()
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream resFilestream = a.GetManifestResourceStream("theDiary.Tools.Development.Resources.Resources.Seth_Consulting.pfx"))
            {
                if (resFilestream == null) return null;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
}
