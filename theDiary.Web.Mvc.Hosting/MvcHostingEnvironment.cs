using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Hosting;
using System.Web.Mvc.Hosting.Configuration;
using System.Web.Routing;

namespace System.Web.Mvc.Hosting
{
    public sealed class MvcHostingEnvironment
        : Singleton<MvcHostingEnvironment>
    {
        /// <summary>
        /// Initializes a new instances of the <see cref="MvcHostingEnvironment"/>.
        /// </summary>
        public MvcHostingEnvironment()
            : base()
        {
        }

        #region Private Declarations
        private volatile Dictionary<string, MvcHostedApplicationRegistration> mvcModules;
        private readonly object syncObject = new object();
        private HostingApplicationConfigurationScope configuration;
        private ApplicationRolesInitializationHandler applicationRolesInitializationCallBack;
        private AdministratorInitializationHandler administratorInitializationCallBack;
        #endregion

        #region Private Static Read-Only Declarations
        private static readonly Type ConfigurationType = typeof(UnifiedMigrationConfiguration<>);
        private static readonly Type DatabaseInitializerType = typeof(MigrateDatabaseToLatestVersion<,>);
        private static readonly Type DatabaseContainerType = typeof(Database);
        #endregion

        #region Private Properties

        private Dictionary<string, MvcHostedApplicationRegistration> MvcModules
        {
            get
            {
                lock (this.syncObject)
                {
                    if (this.mvcModules.IsNull())
                        this.mvcModules = new Dictionary<string, MvcHostedApplicationRegistration>();

                    return this.mvcModules;
                }
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the number of Hosted Applications in the environment.
        /// </summary>
        public int Count
        {
            get
            {
                lock (this.syncObject)
                {
                    return this.mvcModules.Count;
                }
            }
        }
        
        public IHostingApplication Configuration
        {
            get
            {
                if (this.configuration.IsNull())
                    this.configuration = new HostingApplicationConfigurationScope();
                
                return this.configuration.Configuration;
            }
        }

        public MvcHostedApplicationRegistration this[string applicationIdentifier]
        {
            get
            {
                if (applicationIdentifier.IsNullEmptyOrWhiteSpace())
                    throw new ArgumentNullException("applicationIdentifier");

                if (!this.MvcModules.ContainsKey(applicationIdentifier))
                    return null;

                return this.MvcModules[applicationIdentifier];
            }
        }
        #endregion

        #region Public Methods & Functions
        public void InitializeHostedApplications(ApplicationRolesInitializationHandler applicationRolesInitializationCallBack, AdministratorInitializationHandler administratorInitializationCallBack)
        {
            this.administratorInitializationCallBack = administratorInitializationCallBack;
            this.InitializeHostedApplications(RouteTable.Routes, applicationRolesInitializationCallBack, administratorInitializationCallBack);
        }

        public void InitializeHostedApplications(RouteCollection routeCollection, ApplicationRolesInitializationHandler applicationRolesInitializationCallBack, AdministratorInitializationHandler administratorInitializationCallBack)
        {
            this.Configuration.HostedApplications.ForEachAsParallel<IHostedApplication>(app => this.InitializeHostedApplication(app, routeCollection, applicationRolesInitializationCallBack));
        }

        public void InitializeHostedApplication(IHostedApplication hostedApplication, ApplicationRolesInitializationHandler applicationRolesInitializationCallBack)
        {
            this.InitializeHostedApplication(hostedApplication, RouteTable.Routes, applicationRolesInitializationCallBack);
        }

        public void InitializeHostedApplication(IHostedApplication hostedApplication, RouteCollection routeCollection, ApplicationRolesInitializationHandler applicationRolesInitializationCallBack)
        {
            if (this.MvcModules.ContainsKey(hostedApplication.Identifier))
                throw new InvalidOperationException("A hosted application '{0}' has already initialized.");

            hostedApplication.InitializeContext(MvcHostingEnvironment.ConfigurationType, MvcHostingEnvironment.DatabaseInitializerType, MvcHostingEnvironment.DatabaseContainerType);
            hostedApplication.InitializeMigration();
                        
            MvcHostedApplicationRegistration hostedModule = new MvcHostedApplicationRegistration(hostedApplication, routeCollection);
            this.MvcModules.Add(hostedApplication.Identifier, hostedModule);
                
            if (applicationRolesInitializationCallBack != null)
                applicationRolesInitializationCallBack(hostedApplication, new ApplicationRolesInitializationEventArgs(hostedModule.ApplicationContext));
            
            if (this.administratorInitializationCallBack != null)
                this.administratorInitializationCallBack(hostedApplication, new AdministratorInitializeEventArgs(hostedModule.ApplicationContext, this.GetAdministratorInformation()));
        }
        #endregion

        private dynamic GetAdministratorInformation()
        {
            dynamic adminInfo = (this.Configuration as HostingApplicationConfigurationSection).AdministratorInformation;
            return new
            {
                FirstName = adminInfo.FirstName,
                LastName = adminInfo.LastName,
                Password = adminInfo.Password,
                EmailAddress = adminInfo.EmailAddress,
                UserName = adminInfo.UserName,
                ForcePasswordChange = adminInfo.ForcePasswordChange,
                Roles = this.GetAdministratorRoles()
            };
        }

        private string[] GetAdministratorRoles()
        {
            List<string> roles = new List<string>();
            foreach(var app in this.Configuration.HostedApplications)
                foreach(var role in app.Roles)
                    roles.Add(role);

            return roles.Distinct().ToArray();
        }
    }
}