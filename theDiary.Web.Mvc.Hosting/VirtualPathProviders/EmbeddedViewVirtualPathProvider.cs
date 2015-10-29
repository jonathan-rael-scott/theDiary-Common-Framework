using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Hosting
{
    public sealed class EmbeddedViewVirtualPathProvider
        : EmbeddedVirtualPathProvider
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedViewVirtualPathProvider"/> class.
        /// </summary>
        /// <param name="embeddedAssembly">The <see cref="Assembly"/> instance containing the embedded resources.</param>
        public EmbeddedViewVirtualPathProvider(string identifier, Assembly embeddedAssembly)
            : base(embeddedAssembly)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentNullException("identifier");

            this.RootPath = string.Format("/{0}", identifier);
            this.Identifier = identifier;
        }
        #endregion

        #region Public Read-Only Properties
        public string VirtualRootPath
        {
            get
            {
                return string.Format("~{0}", this.RootPath);
            }
        }

        public string RootPath { get; private set; }

        public string Identifier { get; private set; }
        #endregion

        #region Public Constant Declarations
        /// <summary>
        /// The valid extensions used by Mvc Razor.
        /// </summary>
        public static readonly string[] ValidPathExtensions = new string[]{".ascx", ".aspx", ".cshtml", ".html", ".htm"};
        #endregion

        #region Public Methods & Functions
        public override bool DirectoryExists(string virtualDir)
        {
            if (virtualDir.StartsWith("~/"))
                virtualDir = virtualDir.Substring(1);

            if (this.RootPath.Equals(virtualDir, StringComparison.OrdinalIgnoreCase))
                return true;

            return base.DirectoryExists(virtualDir);
        }

        public override bool FileExists(string virtualPath)
        {
            //if (this.VirtualRootPath.Equals(virtualPath, StringComparison.OrdinalIgnoreCase))
            //{
            //    MvcHostingEnvironment.MvcHostedModule i = MvcHostingEnvironment.Instance[this.Identifier];
            //    if (i != null && i.DefaultFile != null)
            //        return true;
            //}

            return base.FileExists(virtualPath);
        }
        
        /// <summary>
        /// Gets a virtual file from the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>A descendent of the <see cref="System.Web.Hosting.VirtualFile"/> class that represents a file as an embedded resource.</returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            //if (this.VirtualRootPath.Equals(virtualPath, StringComparison.OrdinalIgnoreCase))
            //{
            //    MvcHostingEnvironment.MvcHostedModule i = MvcHostingEnvironment.Instance[this.Identifier];
            //    if (i != null && i.DefaultFile != null)
            //        return i.DefaultFile;
            //}

            return base.GetFile(virtualPath);
        }

        private string CreateActualVirtualPath(string virtualPath)
        {
            if (virtualPath.StartsWith("~/"))
                virtualPath = virtualPath.Substring(1);
            if (virtualPath.StartsWith(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath))
                virtualPath = virtualPath.Remove(0, System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath.Length);

            return string.Format("~{0}/{1}/{2}", System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath, this.Identifier, virtualPath);
        }
        #endregion
    }
}
