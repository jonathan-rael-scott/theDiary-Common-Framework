using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents a configuration element containing a collection 
    /// of <see cref="HostedApplicationConfigurationElement"/> instances.
    /// </summary>
    public sealed class HostedApplicationConfigurationElementCollection
        : System.Configuration.ConfigurationElementCollection<HostedApplicationConfigurationElement>,
        IEnumerable<IHostedApplication>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HostedApplicationConfigurationElementCollection"/> class.
        /// </summary>
        public HostedApplicationConfigurationElementCollection()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostedApplicationConfigurationElementCollection"/> class.
        /// </summary>
        /// <param name="comparer">The <see cref="IComparer"/> to use.</param>
        public HostedApplicationConfigurationElementCollection(IComparer comparer)
            : base(comparer)
        {
        }
        #endregion

        #region Public Methods & Functions
        IEnumerator<IHostedApplication> IEnumerable<IHostedApplication>.GetEnumerator()
        {
            List<IHostedApplication> returnValue = new List<IHostedApplication>();
            foreach (HostedApplicationConfigurationElement element in this)
                returnValue.Add(element);

            return returnValue.GetEnumerator();
        }
        #endregion
    }
}
