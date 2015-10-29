using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    public class AdministratorInitializeEventArgs
        : ContextEventArgs
    {
        public AdministratorInitializeEventArgs(DbContext context)
            : base(context)
        {
        }

        public AdministratorInitializeEventArgs(DbContext context, dynamic administratorInformation, params string[] roles)
            : base(context)
        {
            this.UserName = administratorInformation.UserName;
            this.FirstName = administratorInformation.FirstName;
            this.LastName = administratorInformation.LastName;
            this.Password = administratorInformation.Password;
            this.EmailAddress = administratorInformation.EmailAddress;
            this.ForcePasswordChange = administratorInformation.ForcePasswordChange;
            this.roles = ((IEnumerable<string>)administratorInformation.Roles).ToArray() ?? roles ?? new string[] { };
        }

        #region Private Declarations
        private string[] roles;
        #endregion

        #region Public Read-Only Properties
        public string UserName { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string EmailAddress { get; protected set; }

        public string Password { get; protected set; }

        public bool ForcePasswordChange { get; protected set; }

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
