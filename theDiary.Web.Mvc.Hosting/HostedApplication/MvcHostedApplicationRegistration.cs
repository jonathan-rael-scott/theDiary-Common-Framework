using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Routing;

namespace System.Web.Mvc.Hosting
{
    /// <summary>
    /// Contains the information detailing the registration of a Hosted Application.
    /// </summary>
    public sealed class MvcHostedApplicationRegistration
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MvcHostedApplicationRegistration"/> class.
        /// </summary>
        /// <param name="identifier">The name used to identify the Hosted Module.</param>
        /// <param name="mvcModuleAssembly">The <see cref="Assembly"/> associated to the Hosted Module.</param>
        public MvcHostedApplicationRegistration(IHostedApplication hostedApplication, RouteCollection routeCollection)
            : base()
        {
            if (hostedApplication.IsInvalid())
                throw new InvalidOperationException("The Hosted Application is not correctly configured.");

            this.HostedApplication = hostedApplication;
            this.ModuleAssembly = hostedApplication.ApplicationContextType.Assembly;
            this.PathProvider = new EmbeddedViewVirtualPathProvider(this.Identifier, this.ModuleAssembly);
            HostingEnvironment.RegisterVirtualPathProvider(this.PathProvider);
            this.ModuleAssembly.RegisterControllers(routeCollection, hostedApplication.Identifier);
            ApplicationHostConfiguration.Instance.AddHostedApplication(this.HostedApplication);
        }
        #endregion

        #region Public Read-Only Properties
        public EmbeddedVirtualFile DefaultFile { get; set; }

        public AreaRegistration AreaRegistration { get; private set; }

        public string RootPath
        {
            get
            {
                return string.Format("~/{0}", this.Identifier);
            }
        }

        public IHostedApplication HostedApplication { get; private set; }

        public DbContext ApplicationContext { get; private set; }

        /// <summary>
        /// Gets the name used to identify the Hosted Module.
        /// </summary>
        public string Identifier
        {
            get
            {
                return this.HostedApplication.Identifier;
            }
        }

        /// <summary>
        /// Gets the <see cref="Assembly"/> associated to the Hosted Module.
        /// </summary>
        public Assembly ModuleAssembly { get; private set; }

        /// <summary>
        /// Gets the <see cref="VirtualPathProvider"/> associated to the Hosted Module.
        /// </summary>
        public VirtualPathProvider PathProvider { get; private set; }
        #endregion
    }
}
