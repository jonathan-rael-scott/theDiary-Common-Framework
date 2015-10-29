using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Configuration
{
    public class ConfigurationKeyValueElement<TKey, TValue>
        : System.Configuration.ConfigurationElement
    {
        #region Constructors
        public ConfigurationKeyValueElement()
            : base()
        {
        }

        public ConfigurationKeyValueElement(TKey key)
            : this()
        {
            if (key.IsNull())
                throw new ArgumentNullException("key");

            this.Key = key;
        }

        public ConfigurationKeyValueElement(TKey key, TValue value)
            : this(key)
        {
            this.Value = value;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the <see cref="T:ConfigurationElement"/> key.
        /// </summary>
        [ConfigurationProperty("Key", IsRequired = true, IsKey=true)]
        public TKey Key
        {
            get
            {
                return (TKey)this["key"];
            }
            set
            {
                if (value.IsNull())
                    throw new ArgumentNullException("value", "The key can not be Null");

                this["key"] = value;
            }
        }

        [ConfigurationProperty("value", IsRequired = false)]
        public TValue Value
        {
            get
            {
                return (TValue)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
        #endregion

        public static explicit operator KeyValuePair<TKey, TValue>(ConfigurationKeyValueElement<TKey, TValue> element)
        {
            return new KeyValuePair<TKey, TValue>(element.Key, element.Value);
        }
    }
}
