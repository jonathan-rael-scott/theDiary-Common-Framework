using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    /// <summary>
    /// Defines the requirements used to load a Hosted Mvc Application.
    /// </summary>
    public interface IHostedApplication
    {
        #region Property Definitions
        /// <summary>
        /// Gets the value used to identify the Hosted Application.
        /// </summary>
        string Identifier { get; }

        /// <summary>
        /// Gets the display name the Hosted Application.
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// Gets the roles required by the Hosted Application.
        /// </summary>
        IEnumerable<string> Roles { get; }

        /// <summary>
        /// Gets the MetaData for a Hosted Application.
        /// </summary>
        IApplicationMetaDataCollection MetaData { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> used for Code First MigrationConfiguration.
        /// </summary>
        Type MigrationConfigurationType { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> used for the DbContext.
        /// </summary>
        Type ApplicationContextType { get; }
        #endregion

        #region Method & Function Definitions
        /// <summary>
        /// Gets the Code First MigrationConfiguration instance.
        /// </summary>
        /// <returns>The <see cref="Object"/> instance of the Code First MigrationConfiguration if exists; otherwise <c>Null</c>.</returns>
        object GetMigrationConfiguration();
        #endregion
    }
}
