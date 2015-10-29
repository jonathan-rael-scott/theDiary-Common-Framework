using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.Web.Mvc.Hosting
{
    public class HostedApplicationHandler
        : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var routeValues = context.Request.RequestContext.RouteData.Values;
            string applicationIdentifier = (string) routeValues["identifier"];

            context.Response.Clear();

            byte[] iconData = MvcHostingEnvironment.Instance[applicationIdentifier].HostedApplication.GetIconData();
            if (iconData.IsNullOrEmpty())
            {
                context.Response.StatusCode = 404;
            }
            else
            {
                context.Response.ContentType = iconData.GetMimeType();
                context.Response.BinaryWrite(iconData);
            }
            context.Response.Flush();
        }
    }
}
