using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DocumentGeneration.Templating
{
    public class TemplateOptions
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateOptions"/> class.
        /// </summary>
        public TemplateOptions()
            : this(TemplateOptions.DefaultTemplateExtension, TemplateOptions.DefaultTemplateLocation)
        { 
        }

        public TemplateOptions(Uri templateLocation)
            : this(TemplateOptions.DefaultTemplateExtension, templateLocation)
        {
        }

        public TemplateOptions(string templateExtension, Uri templateLocation)
            : base()
        {
            if (templateExtension == null)
                throw new ArgumentException("The Template Extension can not be Null");

            if (templateLocation == null)
                throw new ArgumentNullException("The Template Location can not be Null.");

            this.TemplateExtension = templateExtension;
            this.TemplateLocation = templateLocation;
        }
        #endregion

        #region Public Constant Declarations
        public static readonly string DefaultTemplateExtension = ".template";
        
        public static readonly Uri DefaultTemplateLocation = new Uri("Templates", UriKind.Relative);
        
        public static readonly TemplateOptions DefaultOptions = new TemplateOptions();

        public static readonly string DefaultNullDisplayText = string.Empty;
        #endregion
        
        #region Private Declarations
        private string templateExtension;
        private string nullDisplayText;
        #endregion
        
        #region Public Properties
        public string NullDisplayText
        {
            get
            {
                return this.nullDisplayText;
            }
            protected set
            {
                this.nullDisplayText = value ?? TemplateOptions.DefaultNullDisplayText;
            }
        }

        public string TemplateExtension
        {
            get
            {
                return this.templateExtension;
            }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException("The Template Location can not be Null.");

                this.templateExtension = string.Format("{1}{0}", value, value.StartsWith(".") ? string.Empty : ".");
            }
        }

        public Uri TemplateLocation { get; protected set; }
        #endregion
    }
}
