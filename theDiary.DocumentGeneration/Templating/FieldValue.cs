using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Deployment;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
namespace System.DocumentGeneration.Templating
{
    [System.Diagnostics.DebuggerDisplay("{Name:Value}")]
    public class FieldValue
        : IFormattable
    {
        #region Constructors
        public FieldValue(FieldKey fieldKey, object value)
            : base()
        {
            this.fieldKey = fieldKey;
            this.value = value;
        }

        public FieldValue(FieldKey fieldKey, object value, string formatString)
            : this(fieldKey, value)
        {
            this.formatString = formatString;
        }

        public FieldValue(string identifier, string name, object value)
            : this(new FieldKey(identifier, name), value)
        {
        }

        public FieldValue(string identifier, string name, object value, string formatString)
            : this(new FieldKey(identifier, name), value, formatString)
        {
        }
        #endregion

        #region Private Declarations
        private object value;
        private string formatString;
        private FieldKey fieldKey;
        #endregion

        #region Protected Properties
        protected bool HasFormatString
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.FormatString);
            }
        }
        #endregion

        #region Public Properties
        public object Value
        {
            get
            {
                return this.value;
            }
        }

        public string FormatString
        {
            get
            {
                return this.formatString ?? string.Empty;
            }
        }
        #endregion

        #region Public Methods & Functions
        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, format, this.Value);
        }
        #endregion

        public static IEnumerable<FieldValue> CreateFrom(params object[] instances)
        {
            if (instances.IsNullOrEmpty())
                yield break;
            foreach (var instance in instances)
            {
                if (instance == null)
                    yield break;

                var type = instance.GetType();
                if (type.Namespace.Contains("dynamicproxies", StringComparison.OrdinalIgnoreCase))
                    type = type.BaseType;
                string typeName = type.Name;
                foreach (var property in instance.GetType().GetProperties().Where(prop => prop.CanRead))
                    yield return new FieldValue(typeName, property.Name, property.GetValue(instance, null), GetFormatString(property));
            }
        }

        private static string GetFormatString(PropertyInfo property)
        {
            DisplayFormatAttribute att = property.GetAttribute<DisplayFormatAttribute>(true);
            if (att == null || att.DataFormatString.IsNullEmptyOrWhiteSpace())
            {
                MetadataTypeAttribute metaAtt = property.DeclaringType.GetAttribute<MetadataTypeAttribute>(true);
                if (metaAtt != null && metaAtt.MetadataClassType.GetProperty(property.Name) != null)
                    return GetFormatString(metaAtt.MetadataClassType.GetProperty(property.Name));

                return null;
            }
            return att.DataFormatString;
        }
        #region Internal Methods & Functions
        internal void ReplaceFieldKey(ref System.Text.StringBuilder builder, TemplateOptions options)
        {
            object refVal = this.Value ?? options.NullDisplayText;
            string replacementValue = (this.HasFormatString) ? string.Format(CultureInfo.CurrentUICulture, this.FormatString, (refVal ?? "")) : (refVal ?? "").ToString();
            builder.Replace(this.fieldKey.ToString(), replacementValue);
        }
        #endregion
    }
}
