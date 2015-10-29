using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    /// <summary>
    /// The event data that contains the Name and Roles for a Hosted Application.
    /// </summary>
    public class ApplicationRolesInitializationEventArgs
        : ContextEventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRolesEventArgs"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> instance associated to the Hosted Application.</param>
        public ApplicationRolesInitializationEventArgs(DbContext context)
            : base(context)
        {
            this.roles = new string[] { };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRolesEventArgs"/> class, containing the details of the Hosted Application.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> instance associated to the Hosted Application.</param>
        /// <param name="hostedApplication">An instance of the <see cref="IHostedApplication"/>.</param>
        /// <exception cref="ArgumentNullException">thrown if the <paramref name="hostedApplication"/> is <c>Null</c>.</exception>
        public ApplicationRolesInitializationEventArgs(DbContext context, IHostedApplication hostedApplication)
            : base(context)
        {
            if (hostedApplication == null)
                throw new ArgumentNullException("hostedApplication");

            this.roles = hostedApplication.Roles.ToArray();
            this.Identifier = hostedApplication.Identifier;
            this.ApplicationName = hostedApplication.ApplicationName;
        }
        #endregion

        #region Private Declarations
        private string[] roles;
        #endregion

        #region Public Read-Only Properties
        /// <summary>
        /// Gets the value identifing the Hosted Application.
        /// </summary>
        public string Identifier { get; protected set; }

        /// <summary>
        /// Gets the Display Name of the Hosted Application.
        /// </summary>
        public string ApplicationName { get; protected set; }

        /// <summary>
        /// Gets a sequence of <see cref="String"/> instances containing the Roles associated to the Hosted Application.
        /// </summary>
        public IEnumerable<string> Roles
        {
            get
            {
                return this.roles;
            }
            protected set
            {
                this.roles = (!value.IsNullOrEmpty()) ? value.ToArray() : new string[] { };
            }
        }
        #endregion
    }
}
