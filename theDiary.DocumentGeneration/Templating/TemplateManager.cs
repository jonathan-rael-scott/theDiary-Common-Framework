using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DocumentGeneration.Templating
{
    public class TemplateManager
    {
        #region Constructors
        public TemplateManager(string rootPath)
            : this(new Uri(rootPath))
        {
        }

        public TemplateManager(string rootPath, TemplateOptions options)
            : this(new Uri(rootPath), options)
        {
        }

        public TemplateManager(Uri rootUri)
            : this(rootUri, TemplateOptions.DefaultOptions)
        {
        }

        public TemplateManager(Uri rootUri, TemplateOptions options)
        {
            if (rootUri == null)
                throw new ArgumentNullException("rootUri");

            if (options == null)
                throw new ArgumentNullException("options", "The Template Options is Null.");

            this.Options = options;
            this.TemplateLocation = new Uri(rootUri, this.Options.TemplateLocation);
        }
        #endregion

        #region Protected Properties
        protected Uri TemplateLocation { get; private set; }
        #endregion

        #region Public Read-Only Properties
        public TemplateOptions Options { get; protected set; }
        #endregion

        #region Public Methods & Functions
        public bool TemplateExists(string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName))
                return false;

            return System.IO.File.Exists(this.GetTemplateUri(templateName).LocalPath);
        }

        public string PopulateTemplate(string templateName, params object[] values)
        {
            FieldValue[] fieldValues = new FieldValue[] { };
            foreach (var value in values)
                fieldValues.Append((FieldValue) value);

            return this.PopulateTemplate(templateName, (IEnumerable<FieldValue>) fieldValues);
        }

        public string PopulateTemplate(string templateName, IEnumerable<FieldValue> fieldValues)
        {
            using (Stream stream = this.GetTemplateFileStream(templateName))
                return this.PopulateTemplate(stream, fieldValues);
        }
        
        public string PopulateTemplate(Stream stream, IEnumerable<FieldValue> fieldValues)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            if (!stream.CanRead)
                throw new ArgumentException("The stream is not in a readable state.", "stream");

            if (fieldValues == null)
                throw new ArgumentException("fieldValues");

            System.Text.StringBuilder returnValue = new System.Text.StringBuilder();
            StreamReader reader = new StreamReader(stream);
            returnValue.Append(reader.ReadToEnd());
            foreach (var fieldValue in fieldValues.ToArray())
                fieldValue.ReplaceFieldKey(ref returnValue, this.Options);

            return returnValue.ToString();
        }
        #endregion

        #region Protected Methods & Functions
        protected Uri GetTemplateUri(string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName))
                throw new ArgumentNullException("templateName");

            string templateFileName = string.Format("{1}{0}", templateName, templateName.StartsWith("/") ? string.Empty : "/");
            if (!templateFileName.EndsWith(this.Options.TemplateExtension, StringComparison.OrdinalIgnoreCase))
                templateFileName = string.Format("{0}{1}", templateFileName, this.Options.TemplateExtension);

            return new Uri(this.TemplateLocation.ToString() + templateFileName);
        }

        protected Stream GetTemplateFileStream(string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName))
                throw new ArgumentNullException("templateName");

            string absolutePath = this.GetTemplateUri(templateName).LocalPath;
            if (!System.IO.File.Exists(absolutePath))
                throw new FileNotFoundException(string.Format("The template '{0}' can not be found.", templateName), absolutePath);

            return new System.IO.FileStream(absolutePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        }
        #endregion
    }
}
