using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents a configuration element containing a collection <see cref="HostedApplicationRoleConfigurationElement"/> instances.
    /// </summary>
    public sealed class HostedApplicationRoleConfigurationElementCollection
        : ApplicationRoleConfigurationElementCollection<HostedApplicationRoleConfigurationElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MvcHostedApplicationRoleConfigurationElementCollection"/> class.
        /// </summary>
        public HostedApplicationRoleConfigurationElementCollection()
            : base()
        {
        }
    }
}
