using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    /// <summary>
    /// Exposes the simple details required to support a HostedApplication.
    /// </summary>
    public interface IHostingApplication
        : IEnumerable<IHostedApplication>
    {
        /// <summary>
        /// Gets the Display name of the Hosting Application.
        /// </summary>
        string SiteName { get; }

        /// <summary>
        /// Gets a sequence of <see cref="IHostedApplication"/> instances.
        /// </summary>
        IEnumerable<IHostedApplication> HostedApplications { get; }
    }
}
