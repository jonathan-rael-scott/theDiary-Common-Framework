using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc.Hosting;
using System.Web.Mvc.Hosting.Models;

namespace $safeprojectname$.Models
{
    public class Context
        : HostedApplicationDbContext
    {
        #region Constructors
        public Context()
            :base("DefaultConnection")
        {

        }
        #endregion
    }
}