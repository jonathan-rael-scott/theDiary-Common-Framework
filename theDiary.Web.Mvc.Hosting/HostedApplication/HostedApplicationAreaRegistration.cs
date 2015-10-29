using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    public class HostedApplicationAreaRegistration
        : AreaRegistration
    {
        public HostedApplicationAreaRegistration(IMvcHostedApplication hostedApplication)
            : base()
        {
            this.areaName = hostedApplication.Name;
        }

        private string areaName;

        public override string AreaName
        {
            get
            {
                return this.areaName;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: string.Format("{0}_default", this.AreaName),
                url: this.AreaName + "/{controller}/{action}/{id}",
                constraints: null,
                defaults: new { controller = "Home", action = "Index", id = "" },
                namespaces: string[]{} );
        }

    }
}

