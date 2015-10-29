using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents a configuration element containing a collection <see cref="HostedApplicationMetaDataConfigurationElement"/> instances of <see cref="Type"/> <typeparamref name="TElement"/>.
    /// </summary>
    public class HostedApplicationMetaDataConfigurationElementCollection
        : ConfigurationElementCollection<HostedApplicationMetaDataConfigurationElement>,
        IEnumerable<HostedApplicationMetaDataConfigurationElement>,
        IApplicationMetaDataCollection
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleConfigurationElementCollection"/> class.
        /// </summary>
        public HostedApplicationMetaDataConfigurationElementCollection()
            : base()
        {
        }
        #endregion

        #region IEnumerable Methods & Functions
        IEnumerator<HostedApplicationMetaDataConfigurationElement> IEnumerable<HostedApplicationMetaDataConfigurationElement>.GetEnumerator()
        {
            foreach (HostedApplicationMetaDataConfigurationElement element in ((IEnumerable<HostedApplicationMetaDataConfigurationElement>)this))
                yield return (HostedApplicationMetaDataConfigurationElement)element;
        }

        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
        {
            foreach (HostedApplicationMetaDataConfigurationElement element in ((IEnumerable<HostedApplicationMetaDataConfigurationElement>)this))
                yield return (KeyValuePair<string,string>) element;
        }
        #endregion

        IApplicationMetaData IApplicationMetaDataCollection.this[string metaDataKey]
        {
            get
            {
                foreach (HostedApplicationMetaDataConfigurationElement element in ((IEnumerable<HostedApplicationMetaDataConfigurationElement>)this))
                    if (element.Key.Equals(metaDataKey, StringComparison.InvariantCultureIgnoreCase))
                        return element;

                return null;
            }
        }

        IEnumerator<IApplicationMetaData> IEnumerable<IApplicationMetaData>.GetEnumerator()
        {
            foreach (HostedApplicationMetaDataConfigurationElement element in ((IEnumerable<HostedApplicationMetaDataConfigurationElement>)this))
                yield return (IApplicationMetaData)element;
        }
    }
}
