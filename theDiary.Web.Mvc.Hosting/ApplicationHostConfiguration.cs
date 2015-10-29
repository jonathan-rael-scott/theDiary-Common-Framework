using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    public sealed class ApplicationHostConfiguration
        : Singleton<ApplicationHostConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationHostConfiguration"/> class.
        /// </summary>
        public ApplicationHostConfiguration()
        {
            this.configurations = new Queue<IHostedApplicationConfiguration>();
            this.configurationCount = 0;
            this.roles = new List<string>();
        }

        private Queue<IHostedApplicationConfiguration> configurations;
        private int configurationCount;
        private List<string> roles;
        public event EventHandler<ContextEventArgs> InitializeSecurity;
        public event EventHandler<ContextEventArgs> InitializeSecurityRoles;

        public void AddHostedApplication(Type hostedApplicationType)
        {
            if (hostedApplicationType == null)
                return;

            IHostedApplication hostedApplication = (IHostedApplication)System.Activator.CreateInstance(hostedApplicationType);
            this.AddHostedApplication(hostedApplication);
        }

        public void AddHostedApplication(IHostedApplication hostedApplication)
        {
            this.roles.AddRange(hostedApplication.Roles);
            //if (configuration is IDatabaseConfiguration)
            //{
            //    ((IDatabaseConfiguration)configuration).SeedingFinished += ApplicationHostConfiguration_SeedingFinished;
            //    this.configurationCount++;
            //}
            //this.configurations.Enqueue(configuration);
        }

        public void ApplicationHostConfiguration_SeedingFinished(object sender, ContextEventArgs e)
        {
            this.configurationCount--;
            if (this.InitializeSecurityRoles != null)
                this.InitializeSecurityRoles(sender, e);  
        }

        public IEnumerable<string> GetHostedApplicationRoles()
        {
            return this.roles.Distinct();
        }

        public IEnumerable<IHostedApplicationConfiguration> GetConfigurations()
        {
            while (this.configurations.Count > 0)
            {
                yield return this.configurations.Dequeue();
            }
            if (this.InitializeSecurity != null)
                this.InitializeSecurity(this, new ContextEventArgs(null));
        }
    }
}
