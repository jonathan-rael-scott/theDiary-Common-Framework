using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DocumentGeneration.Templating
{
    public class TemplateValueFormatter
        : IFormatProvider, 
        ICustomFormatter
    {
        #region Constructors
        public TemplateValueFormatter(string format)
            : this(format, CultureInfo.CurrentUICulture)
        {
        }

        public TemplateValueFormatter(string format, CultureInfo culture)
            : base()
        {
            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentNullException("format");
            if (culture == null)
                throw new ArgumentNullException("culture");

            this.format = format;
            this.culture = culture;
        }
        #endregion

        #region Private Declarations
        private string format;
        private CultureInfo culture;
        #endregion

        #region Public Methods & Functions
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        public string Format(object arg)
        {
            return string.Format(this.culture, this.format, arg);
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return string.Format(this.culture, this.format, arg);
        }
        #endregion
    }
}
