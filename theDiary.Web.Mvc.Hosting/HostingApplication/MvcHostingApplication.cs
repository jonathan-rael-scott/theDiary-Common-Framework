using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Hosting;
using System.Web.Routing;

namespace System.Web.Mvc.Hosting
{
    public abstract class MvcHostingApplication
        : System.Web.HttpApplication
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MvcHostingApplication"/> class.
        /// </summary>
        public MvcHostingApplication()
            : base()
        {
            
        }
        #endregion

        #region Event Declarations
        /// <summary>
        /// The event that is raised to initialize the Application Security Provider.
        /// </summary>
        public event EventHandler InitializeApplicationSecurityProvider;

        /// <summary>
        /// The event that is raised to initialize the Roles for a Hosted Application.
        /// </summary>
        public event ApplicationRolesInitializationHandler InitializeApplicationRoles;

        /// <summary>
        /// The event that is raised to initialize the Application Administrator.
        /// </summary>
        public event AdministratorInitializationHandler InitializeApplicationAdministrator;

        /// <summary>
        /// The event that is raised when any additional Metadata can be registered or initialized.
        /// </summary>
        /// <remarks>This covers the registration of Routes, Bundles etc.</remarks>
        public event EventHandler RegisterMetaData;

        /// <summary>
        /// The event that is raised when the application has started.
        /// </summary>
        public event EventHandler ApplicationStarted;
        #endregion

        #region Public Properties
        public ApplicationHostConfiguration Configuration
        {
            get
            {
                return ApplicationHostConfiguration.Instance;
            }
        }
        #endregion

        #region Protected Methods & Functions
        protected void Application_Start()
        {
            if (this.InitializeApplicationSecurityProvider != null)
                this.InitializeApplicationSecurityProvider(this, new EventArgs());

            MvcHostingEnvironment.Instance.InitializeHostedApplications(this.InitializeApplicationRoles, this.InitializeApplicationAdministrator);

            if (this.RegisterMetaData != null)
                this.RegisterMetaData(this, new EventArgs());

            ModelMetadataProviders.Current = new EnumMetadataProvider();
            
            if (this.ApplicationStarted != null)
                this.ApplicationStarted(this, new EventArgs());
        }
        #endregion
    }
}
