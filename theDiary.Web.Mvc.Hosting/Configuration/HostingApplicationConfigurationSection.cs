using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents the Hosting Configuration Section within a configuration file.
    /// </summary>
    public sealed class HostingApplicationConfigurationSection
        : ConfigurationSection,
        IEnumerable<IHostedApplication>,
        IHostingApplication
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HostingApplicationConfigurationSection"/> class.
        /// </summary>
        public HostingApplicationConfigurationSection()
            : base()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or Sets the Display name of the Hosting Application.
        /// </summary>
        [ConfigurationProperty("siteName", IsRequired=true)]
        public string SiteName
        {
            get
            {
                return (string)this["siteName"];
            }
            set
            {
                this["siteName"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the element containing the collection of <see cref="HostedApplicationConfigurationElement"/> instances.
        /// </summary>
        [ConfigurationProperty("", IsDefaultCollection=true, IsRequired=true)]
        [ConfigurationCollection(typeof(HostedApplicationConfigurationElement), AddItemName="application")]
        public HostedApplicationConfigurationElementCollection HostedApplications
        {
            get
            {
                return (HostedApplicationConfigurationElementCollection)this[""];
            }
            set
            {
                this[""] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the configuration element containing the Administrator Information.
        /// </summary>
        [ConfigurationProperty("administratorInformation")]
        public AdministratorInformationSection AdministratorInformation
        {
            get
            {
                return (AdministratorInformationSection)this["administratorInformation"];
            }
            set
            {
                this["administratorInformation"] = value;
            }
        }
        #endregion

        #region IEnumerable Methods & Functions
        IEnumerator<IHostedApplication> IEnumerable<IHostedApplication>.GetEnumerator()
        {
            return ((IEnumerable<IHostedApplication>)this.HostedApplications).GetEnumerator();
        }

        Collections.IEnumerator Collections.IEnumerable.GetEnumerator()
        {
            return this.HostedApplications.GetEnumerator();
        }
        #endregion

        #region IHostingApplication Methods & Functions
        /// <summary>
        /// Gets the Display name of the Hosting Application.
        /// </summary>
        string IHostingApplication.SiteName
        {

            get
            {
                return this.SiteName;
            }
        }

        /// <summary>
        /// Gets a sequence of <see cref="IHostedApplication"/> instances.
        /// </summary>
        IEnumerable<IHostedApplication> IHostingApplication.HostedApplications
        {
            get
            {
                return this.HostedApplications;
            }
        }
        #endregion
    }
}
