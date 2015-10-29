using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc.Hosting;
using System.Web.Security;
using WebMatrix.WebData;

namespace $safeprojectname$.Migrations
{
    public sealed class Configuration 
        : UnifiedMigrationConfiguration<$safeprojectname$.Models.Context>
    {
        #region Constructors
        public Configuration()
            : base()
        {
        }
        #endregion

        protected override void Seed($safeprojectname$.Models.Context context)
        {
            // Insert Seeding Code Here
            
            base.Seed(context);
        }
    }
}
