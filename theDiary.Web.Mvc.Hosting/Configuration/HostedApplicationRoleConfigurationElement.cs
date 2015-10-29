using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents an Hosted Application Role configuration element in a configuration file.
    /// </summary>
    public class HostedApplicationRoleConfigurationElement
        : ApplicationRoleConfigurationElement
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HostedApplicationRoleConfigurationElement"/> class.
        /// </summary>
        public HostedApplicationRoleConfigurationElement()
            : base()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or Sets a value indicating if the Role is automatically applied to the Administrator user.
        /// <remarks>This value is ignored if the <see cref="AdministratorInformationSection"/> contains any <see cref="ApplicationRoleConfigurationElement"/>s.</remarks>
        /// </summary>
        [ConfigurationProperty("administrator", IsRequired = false, IsKey = false, DefaultValue=false)]
        public bool IsAdministrativeRole
        {
            get
            {
                return (bool)this["administrator"];
            }
            set
            {
                this["administrator"] = value;
            }
        }
        #endregion
    }
}
