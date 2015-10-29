using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Configuration
{
    public class ConfigurationKeyValueElementCollection<TKey, TValue>
        : ConfigurationElementCollection<ConfigurationKeyValueElement<TKey, TValue>>
    {
        #region Consturctors
        public ConfigurationKeyValueElementCollection()
            : base()
        {
        }

        public ConfigurationKeyValueElementCollection(IComparer comparer)
            : base(comparer)
        {
        }
        #endregion

        #region Public Property
        public TValue this[TKey key]
        {
            get
            {
                return ((ConfigurationKeyValueElement<TKey, TValue>) base.BaseGet(key)).Value;
            }
            set
            {
                int indexOf = this.GetIndexOf(key);
                var element = new ConfigurationKeyValueElement<TKey, TValue>(key, value);
                if (indexOf != -1)
                {
                    base.BaseRemoveAt(indexOf);
                    base.BaseAdd(indexOf, element);
                }
                else
                {
                    base.BaseAdd(element);
                }
            }
        }
        #endregion

        #region Protected Methods & Functions
        /// <summary>
        /// Creates a new <see cref="AuthenticationParameterConfigurationElemement"/>.
        /// </summary>
        /// <returns>An instance of <see cref="AuthenticationParameterConfigurationElemement"/>.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigurationKeyValueElement<TKey, TValue>();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>An <see cref="System.Object"/> that acts as the key for the specified <see cref="System.Configuration.ConfigurationElement"/>.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            //set to whatever Element Property you want to use for a key
            return ((ConfigurationKeyValueElement<TKey, TValue>) element).Key;
        }
        #endregion

        #region Private Methods & Functions
        private int GetIndexOf(TKey key)
        {
            for (int i = 0; i < this.Count; i++)
                if ((this[i] as ConfigurationKeyValueElement<TKey, TValue>).Key.Equals(key))
                    return i;
            return -1;
        }
        #endregion
    }
}
