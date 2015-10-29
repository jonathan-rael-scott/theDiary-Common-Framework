using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Configuration
{
    public class HostedApplicationMetaDataConfigurationElement
        : ConfigurationKeyValueElement<string, string>,
        IApplicationMetaData
    {
        public HostedApplicationMetaDataConfigurationElement()
            : base()
        {
        }

        public HostedApplicationMetaDataConfigurationElement(string key)
            : base(key)
        {
        }

        public HostedApplicationMetaDataConfigurationElement(string key, string value)
            : base(key, value)
        {
        }

        string IApplicationMetaData.Key
        {
            get
            {
                return this.Key;
            }
        }

        string IApplicationMetaData.Value
        {
            get
            {
                return this.Value;
            }
            set
            {
                this.Value = value;
            }
        }

        object IApplicationMetaData.GetAdditionalProperty(string propertyName)
        {
            if (this.Properties.Contains(propertyName))
                return this.Properties[propertyName];
            
            return null;
        }

        bool IApplicationMetaData.HasAdditionalProperty(string propertyName)
        {
            return this.Properties.Contains(propertyName) != null;
        }
    }
}
