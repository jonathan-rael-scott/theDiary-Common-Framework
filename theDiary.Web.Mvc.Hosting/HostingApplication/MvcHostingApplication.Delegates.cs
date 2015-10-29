using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    /// <summary>
    /// The method that handles the initialization of Roles for a Hosted Application.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ApplicationRolesInitializationEventArgs"/> instance containing the Hosted Application Name and its Roles.</param>
    public delegate void ApplicationRolesInitializationHandler(object sender, ApplicationRolesInitializationEventArgs e);

    /// <summary>
    /// The method that handles the initialization of the Administrator for the Hosting Application.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="AdministratorInitializeEventArgs"/> instance.</param>
    public delegate void AdministratorInitializationHandler(object sender, AdministratorInitializeEventArgs e);
}
