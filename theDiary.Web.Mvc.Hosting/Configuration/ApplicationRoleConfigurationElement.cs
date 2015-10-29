using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents an Application Role configuration element within a configuration file.
    /// </summary>
    public class ApplicationRoleConfigurationElement
        : ConfigurationElement
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleConfigurationElement"/> class.
        /// </summary>
        public ApplicationRoleConfigurationElement()
            : base()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or Sets the Name identifing an Application Role.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string RoleName
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                if (value.IsNullEmptyOrWhiteSpace())
                    throw new ArgumentNullException("value", "The role name can not be Null or Whitespace.");

                this["name"] = value;
            }
        }
        #endregion

        #region Implicit Operators
        /// <summary>
        /// Returns the <see cref="ApplicationRoleConfigurationElement"/>.<value>RoleName</value> value.
        /// </summary>
        /// <param name="configurationElement">The <see cref="ApplicationRoleConfigurationElement"/> instance.</param>
        /// <returns>The Name of the Role contained in the <paramref name="configurationElement"/>.</returns>
        /// <exception cref="ArgumentNullException">thrown if the <paramref name="configurationElement"/> is <c>Null</c>.</exception>
        public static implicit operator string(ApplicationRoleConfigurationElement configurationElement)
        {
            if (configurationElement == null)
                throw new ArgumentNullException("configurationElement");
            
            return configurationElement.RoleName;
        }
        #endregion
    }
}
