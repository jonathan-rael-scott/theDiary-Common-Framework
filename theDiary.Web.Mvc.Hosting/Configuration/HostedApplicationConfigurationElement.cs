using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents a configuration element containing the information for a Hosted Application within a configuration file.
    /// </summary>
    public sealed class HostedApplicationConfigurationElement
        : ConfigurationElement,
        IHostedApplication
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HostedApplicationConfigurationElement"/> class.
        /// </summary>
        public HostedApplicationConfigurationElement()
            : base()
        {
        }
        #endregion

        #region Private Declarations
        private object migrationConfiguration;
        private bool migrationConfigurationLoaded = false;
        private Type applicationContextType;
        private bool applicationContextTypeLoaded = false;
        private Type migrationConfigurationType;
        private bool migrationConfigurationTypeLoaded = false;
        private readonly object syncObject = new object();
        #endregion

        #region Public Configuration Element Properties
        /// <summary>
        /// Gets or Sets the name identifing the Hosted Application.
        /// </summary>
        [ConfigurationProperty("name", IsRequired=true, IsKey=true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the name identifing the Hosted Application.
        /// </summary>
        [ConfigurationProperty("fullName", IsRequired = false)]
        public string FullName
        {
            get
            {
                return (string)this["fullName"];
            }
            set
            {
                this["fullName"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the name of the Connection String associated to the Hosted Application.
        /// </summary>
        [ConfigurationProperty("connectionString", IsRequired = false, DefaultValue = "DefaultConnection")]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionString"];
            }
            set
            {
                this["connectionString"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the <see cref="Type"/> that implements the Code First MigrationConfiguration.
        /// </summary>
        [ConfigurationProperty("migrationConfigurationType", IsRequired = false)]
        public string MigrationConfigurationTypeFullName
        {
            get
            {
                return (string) this["migrationConfigurationType"];
            }
            set
            {
                this["migrationConfigurationType"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the <see cref="Type"/> that implements the DbContext.
        /// </summary>
        [ConfigurationProperty("contextType", IsRequired = true)]
        public string ApplicationContextTypeFullName
        {
            get
            {
                return (string)this["contextType"];
            }
            set
            {
                this["contextType"] = value;
            }
        }
        
        /// <summary>
        /// Gets or Sets the Roles associated to the Hosted Application.
        /// </summary>
        [ConfigurationCollection(typeof(HostedApplicationRoleConfigurationElement), AddItemName="add", ClearItemsName="clear", RemoveItemName="removeRole")]
        [ConfigurationProperty("roles", IsDefaultCollection=false)]
        public HostedApplicationRoleConfigurationElementCollection Roles
        {
            get
            {
                return (HostedApplicationRoleConfigurationElementCollection)this["roles"];
            }
            set
            {
                this["roles"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the MetaData associated to the Hosted Application.
        /// </summary>
        [ConfigurationCollection(typeof(HostedApplicationMetaDataConfigurationElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "removeRole")]
        [ConfigurationProperty("metaData", IsDefaultCollection = false)]
        public HostedApplicationMetaDataConfigurationElementCollection MetaData
        {
            get
            {
                return (HostedApplicationMetaDataConfigurationElementCollection)this["metaData"];
            }
            set
            {
                this["metaData"] = value;
            }
        }
        #endregion

        #region IMvcHostedApplication Implementation
        /// <summary>
        /// Gets the name used to identify the Hosted Application.
        /// </summary>
        string IHostedApplication.Identifier
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the Display Name of the Hosted Application.
        /// </summary>
        string IHostedApplication.ApplicationName
        {
            get
            {
                if (this.FullName.IsNullEmptyOrWhiteSpace())
                    return this.Name;
                return this.FullName ;
            }
        }

        /// <summary>
        /// Gets a sequence of <see cref="String"/> instances identifing the Roles associated to the Hosted Application.
        /// </summary>
        IEnumerable<string> IHostedApplication.Roles
        {
            get 
            {
                return (IEnumerable<string>) this.Roles;
            }
        }

        IApplicationMetaDataCollection IHostedApplication.MetaData
        {
            get
            {
                return this.MetaData;
            }
        }
        /// <summary>
        /// Gets the Code First MigrationConfiguration instance associated to the Hosted Application.
        /// </summary>
        /// <returns>The MigrationConfiguration instance associated to the Hosted Application if it exists; otherwise <c>Null</c>.</returns>
        object IHostedApplication.GetMigrationConfiguration()
        {
            if (!this.migrationConfigurationLoaded){
                Type migrationConfigurationType = ((IHostedApplication) this).MigrationConfigurationType;
                if (migrationConfigurationType != null)
                    this.migrationConfiguration = System.Activator.CreateInstance(migrationConfigurationType);
                this.migrationConfigurationLoaded = true;
            }

            return this.migrationConfiguration;
        }

        /// <summary>
        /// Gets the DbContext <see cref="Type"/> used by the Hosted Application.
        /// </summary>
        Type IHostedApplication.ApplicationContextType
        {
            get
            {
                lock (this.syncObject)
                {
                    if (!this.applicationContextTypeLoaded)
                    {
                        this.applicationContextType = Type.GetType(this.ApplicationContextTypeFullName);
                        this.applicationContextTypeLoaded = true;
                    }
                    return this.applicationContextType;
                }
            }
        }

        /// <summary>
        /// Gets the MigrationConfiguration <see cref="Type"/> used by the Hosted Application.
        /// </summary>
        Type IHostedApplication.MigrationConfigurationType
        {
            get
            {
                lock (this.syncObject)
                {
                    if (!this.migrationConfigurationTypeLoaded)
                    {
                        this.migrationConfigurationType = Type.GetType(this.MigrationConfigurationTypeFullName);
                        this.migrationConfigurationTypeLoaded = true;
                    }
                    return this.migrationConfigurationType;
                }
            }
        }
        #endregion
    }
}
