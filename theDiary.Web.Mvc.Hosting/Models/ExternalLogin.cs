using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Models
{
    public class ExternalLogin
    {
        public string Provider { get; set; }

        public string ProviderDisplayName { get; set; }

        public string ProviderUserId { get; set; }
    }
}
