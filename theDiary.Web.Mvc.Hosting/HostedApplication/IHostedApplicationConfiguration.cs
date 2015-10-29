using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    public interface IHostedApplicationConfiguration
    {
        string ApplicationIdentifier { get; }
        
        DbMigrationsConfiguration GetConfiguration();

        IEnumerable<string> GetRoles();
    }
}
