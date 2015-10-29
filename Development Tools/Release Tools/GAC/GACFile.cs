using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.GAC
{
    public sealed class GACFile
    {
        #region Constructors
        private GACFile()
        {
        }

        internal GACFile(string gacDetail)
            : this()
            
        {
            AssemblyName assemblyName = new AssemblyName(gacDetail.Trim());
            this.Populate(assemblyName);
            this.assemblyLocation = Assembly.ReflectionOnlyLoad(assemblyName.FullName).Location;
        }

        public GACFile(System.IO.FileInfo file)
            : this()
        {
            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(file.FullName);
            this.Populate(assembly.GetName());
            this.assemblyLocation = file.FullName;
        }

        public GACFile(Assembly assembly)
            : this()
        {
            this.Populate(assembly.GetName());
            this.assemblyLocation = assembly.Location;
        }

        public GACFile(AssemblyName assemblyName)
            : this()
        {
            this.Populate(assemblyName);
            this.assemblyLocation = Assembly.ReflectionOnlyLoad(this.assemblyName.FullName).Location;
        }
        #endregion

        #region Private Declarations
        private AssemblyName assemblyName;
        private string assemblyLocation;
        #endregion

        #region Public Read-Only Properties
        public string Path
        {
            get
            {
                if (this.assemblyLocation == null)
                    this.assemblyLocation = Assembly.ReflectionOnlyLoad(this.assemblyName.FullName).Location;

                return this.assemblyLocation;
            }
        }

        public string FileName
        {
            get
            {
                return System.IO.Path.GetFileName(this.Path);
            }
        }

        public string Name 
        {
            get
            {
                return this.assemblyName.Name;
            }
        }

        public Version Version
        {
            get
            {
                return this.assemblyName.Version;
            }
        }

        public System.Globalization.CultureInfo Culture
        {
            get
            {
                return this.assemblyName.CultureInfo;
            }
        }

        public string PublicKeyToken
        {
            get
            {

                return System.Text.UnicodeEncoding.Unicode.GetString(this.assemblyName.GetPublicKeyToken());
            }
        }

        private void Populate(AssemblyName assemblyName)
        {
            this.assemblyName = assemblyName;
        }
        #endregion
    }
}
