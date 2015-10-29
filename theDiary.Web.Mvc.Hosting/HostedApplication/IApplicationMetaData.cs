using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting
{
    public interface IApplicationMetaDataCollection
        : IEnumerable<IApplicationMetaData>,
        IEnumerable<KeyValuePair<string,string>>        
    {
        IApplicationMetaData this[string metaDataKey] { get; }
    }

    public interface IApplicationMetaData
    {
        string Key { get; }

        string Value { get; set; }

        object GetAdditionalProperty(string propertyName);

        bool HasAdditionalProperty(string propertyName);
    }
}
