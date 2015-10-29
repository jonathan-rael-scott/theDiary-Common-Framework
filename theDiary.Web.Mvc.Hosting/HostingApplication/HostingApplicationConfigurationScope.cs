using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Hosting.Configuration;

namespace System.Web.Mvc.Hosting
{
    public sealed class HostingApplicationConfigurationScope
        : System.Configuration.ConfigurationScope<HostingApplicationConfigurationSection>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HostingApplicationConfigurationScope"/>.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="sectionName">The name of the <typeparamref name="T"/> <see cref="ConfigurationSection"/> to load.</param>
        public HostingApplicationConfigurationScope(System.Configuration.Configuration configuration, string sectionName)
            : base(configuration, sectionName)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostingApplicationConfigurationScope"/>.
        /// </summary>
        /// <param name="configurationFile"></param>
        /// <param name="sectionName">The name of the <typeparamref name="T"/> <see cref="ConfigurationSection"/> to load.</param>
        public HostingApplicationConfigurationScope(FileInfo configurationFile, string sectionName)
            : base(configurationFile,sectionName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostingApplicationConfigurationScope"/>.
        /// </summary>
        /// <param name="configurationFile"></param>
        /// <param name="sectionName">The name of the <typeparamref name="T"/> <see cref="ConfigurationSection"/> to load.</param>
        public HostingApplicationConfigurationScope(string configurationFile, string sectionName)
            : base(configurationFile, sectionName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostingApplicationConfigurationScope"/>.
        /// </summary>
        /// <param name="sectionName">The name of the <typeparamref name="T"/> <see cref="ConfigurationSection"/> to load.</param>
        public HostingApplicationConfigurationScope(string sectionName)
            : base(sectionName)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostingApplicationConfigurationScope"/>.
        /// </summary>
        public HostingApplicationConfigurationScope()
            : base("mvcHostingApplication")
        {
        }
        #endregion
    }
}
