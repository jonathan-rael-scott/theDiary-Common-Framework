using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Routing;
using System.IO;

namespace System.Web.Mvc.Hosting
{
    public static partial class HostingExtensions
    {
        public static T GetAdditionalProperty<T>(this IApplicationMetaData metaData, string propertyName)
        {
            return (T)metaData.GetAdditionalProperty(propertyName);
        }

        public static T GetAdditionalProperty<T>(this IApplicationMetaData metaData, string propertyName, T defaultValue)
        {
            if (!metaData.HasAdditionalProperty(propertyName))
                return defaultValue;

            return (T)metaData.GetAdditionalProperty(propertyName);
        }

        public static string GetMetaDataValue(this IHostedApplication hostedApplication, string metaDataKey)
        {
            IApplicationMetaData metaData = hostedApplication.MetaData[metaDataKey];

            return metaData.Value;
        }

        public static string GetDescription(this IHostedApplication hostedApplication)
        {
            return hostedApplication.GetMetaDataValue("Description");
        }

        public static bool HasIcon(this IHostedApplication hostedApplication)
        {
            return !hostedApplication.GetMetaDataValue("Icon").IsNullEmptyOrWhiteSpace();
        }

        public static byte[] GetIconData(this IHostedApplication hostedApplication)
        {
            Stream value = hostedApplication.GetIconStream();
            if (value == null)
                return null;

            return value.ToByteArray();
        }

        public static Stream GetIconStream(this IHostedApplication hostedApplication)
        {
            if (hostedApplication.HasIcon())
            {
                ResourceLocation location = hostedApplication.MetaData["Icon"].GetAdditionalProperty<ResourceLocation>("location", ResourceLocation.File);
                string iconPath = hostedApplication.MetaData["Icon"].Value;
                switch (location)
                {
                    case ResourceLocation.AbsoluteUri:
                        return GetWebResponseStream(new Uri(iconPath, UriKind.Absolute));
                    case ResourceLocation.RelativeUri:
                        return GetWebResponseStream(new Uri(iconPath, UriKind.Relative));
                    case ResourceLocation.File:
                        return new System.IO.FileStream(iconPath, IO.FileMode.Open, IO.FileAccess.Read);
                    case ResourceLocation.EmbeddedResource:
                        return MvcHostingEnvironment.Instance[hostedApplication.Identifier].ModuleAssembly.GetManifestResourceStream(iconPath);
                }
            }
            return null ;
        }

        private static Stream GetWebResponseStream(Uri uri)
        {
            Net.HttpWebRequest helper = Net.HttpWebRequest.CreateHttp(uri);
            return ((System.Net.HttpWebResponse) helper.GetResponse()).GetResponseStream();
        }
    }

    public enum ResourceLocation
    {
        File,

        RelativeUri,

        AbsoluteUri,

        EmbeddedResource,
    }
}
