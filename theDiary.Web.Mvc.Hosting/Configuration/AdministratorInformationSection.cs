using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents a section containing the Administrator Information for the Hosting Application within
    /// a configuration file.
    /// </summary>
    public sealed class AdministratorInformationSection
        : ConfigurationElement
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministratorInformationSection"/>.
        /// </summary>
        public AdministratorInformationSection()
            : base()
        {
        }
        #endregion

        #region Public Properties
        [ConfigurationProperty("userName", IsRequired = true, DefaultValue = "Admin")]
        public string UserName
        {
            get
            {
                return (string)this["userName"];
            }
            set
            {
                if (value.IsNullEmptyOrWhiteSpace())
                    throw new ArgumentNullException("value", "The Administrator Username can not be Null or Whitespace.");

                this["userName"] = value;
            }
        }

        [ConfigurationProperty("firstName", IsRequired = true, DefaultValue="System")]
        public string FirstName
        {
            get
            {
                return (string)this["firstName"];
            }
            set
            {
                this["firstName"] = value;
            }
        }

        [ConfigurationProperty("lastName", IsRequired = true, DefaultValue="Administrator")]
        public string LastName
        {
            get
            {
                return (string)this["lastName"];
            }
            set
            {
                this["lastName"] = value;
            }
        }

        [ConfigurationProperty("password", IsRequired = false, DefaultValue="")]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

        [ConfigurationProperty("forcePasswordChange", IsRequired = false, DefaultValue = true)]
        public bool ForcePasswordChange
        {
            get
            {
                return (bool)this["forcePasswordChange"];
            }
            set
            {
                this["forcePasswordChange"] = value;
            }
        }

        [ConfigurationProperty("email", IsRequired = true)]
        public string EmailAddress
        {
            get
            {
                return (string)this["email"];
            }
            set
            {
                this["email"] = value;
            }
        }
        [ConfigurationProperty("", IsRequired = false, IsDefaultCollection=true)]
        [ConfigurationCollection(typeof(ApplicationRoleConfigurationElement), AddItemName = "role", ClearItemsName = "clear", RemoveItemName = "removeRole")]
        public ApplicationRoleConfigurationElementCollection Roles
        {
            get
            {
                return (ApplicationRoleConfigurationElementCollection) this[""];
            }
            set
            {
                this[""] = value;
            }
        }
        #endregion
    }
}
