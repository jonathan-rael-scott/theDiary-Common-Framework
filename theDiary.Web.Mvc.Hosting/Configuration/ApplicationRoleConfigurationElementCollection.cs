using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    /// <summary>
    /// Represents a configuration element containing a collection <see cref="ApplicationRoleConfigurationElement"/> instances.
    /// </summary>
    public class ApplicationRoleConfigurationElementCollection
        : ApplicationRoleConfigurationElementCollection<ApplicationRoleConfigurationElement>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleConfigurationElementCollection"/> class.
        /// </summary>
        public ApplicationRoleConfigurationElementCollection()
            : base()
        {
        }
        #endregion
    }

    /// <summary>
    /// Represents a configuration element containing a collection <see cref="ApplicationRoleConfigurationElement"/> instances of <see cref="Type"/> <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">A <see cref="Type"/> derived from <see cref="ApplicationRoleConfigurationElement"/>.</typeparam>
    public class ApplicationRoleConfigurationElementCollection<TElement>
        : System.Configuration.ConfigurationElementCollection<TElement>,
        IEnumerable<string>
        where TElement : ApplicationRoleConfigurationElement, new()
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleConfigurationElementCollection"/> class.
        /// </summary>
        public ApplicationRoleConfigurationElementCollection()
            : base()
        {
        }
        #endregion

        #region IEnumerable Methods & Functions
        /// <summary>
        /// Gets a <see cref="IEnumerable"/> instance used to iterate through a sequence of <see cref="String"/> instances containing the Role Names.
        /// </summary>
        /// <returns><see cref="IEnumerable"/> instance containing the Role Names.</returns>
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            foreach (TElement element in ((IEnumerable<TElement>)this))
                yield return (string)element;
        }
        #endregion
    }
}
