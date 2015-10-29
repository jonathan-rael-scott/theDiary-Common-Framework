using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.DocumentGeneration.Templating
{
    public class FieldKey
        : IEquatable<FieldKey>,
        IEquatable<string>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldKey"/> class.
        /// </summary>
        public FieldKey()
            : this(FieldKey.DefaultSeperator)
        {
        }

        public FieldKey(string identifier, string name)
            : this(identifier, name, FieldKey.DefaultSeperator)
        {
        }

        protected FieldKey(string identifier, string name, char seperator)
            : this(seperator)
        {
            this.Identifier = identifier;
            this.Name = name;
        }

        private FieldKey(char seperator)
            : base()
        {
            this.seperator = seperator;
        }
        #endregion

        #region Private Declarations
        private string identifier;
        private string name;
        private char seperator = ':';
        private string fieldKeyValue;
        #endregion

        private const string RegExParsePattern = "(\\{)((?:[a-z][a-z]+))(.)((?:[a-z][a-z]+))(\\})";

        public const char DefaultSeperator = ':';

        #region Private Properties
        private string FieldKeyValue
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.fieldKeyValue))
                    this.SetFieldKeyValue();

                return this.fieldKeyValue;
            }
        }
        #endregion

        #region Public Properties
        public char Seperator
        {
            get
            {
                return this.seperator;
            }
            private set
            {
                this.seperator = value;
            }
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The Field Key Identifier can not be Null, Empty or Whitespace.");

                this.identifier = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The Field Key Identifier can not be Null, Empty or Whitespace.");

                this.name = value;
            }
        }
        #endregion

        #region Public Methods & Functions
        public override string ToString()
        {
            return this.FieldKeyValue;
        }

        public override int GetHashCode()
        {
            return this.FieldKeyValue.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Type objType = obj.GetType();
                if (objType == typeof(string))
                    return this.Equals((string)obj);

                if (objType == typeof(FieldKey))
                    return this.Equals((FieldKey)obj);
            }
            return false;
        }

        public bool Equals(string other)
        {
            return this.Equals(other, StringComparison.CurrentCulture);
        }

        public bool Equals(string other, StringComparison comparisonType)
        {
            return this.FieldKeyValue.Equals(other, comparisonType);
        }

        public bool Equals(FieldKey other)
        {
            if (other == null)
                return false;

            return this.Equals(other.FieldKeyValue);
        }
        #endregion

        #region Private Methods & Functions
        private void SetFieldKeyValue()
        {
            StringBuilder value = new StringBuilder();
            value.Append("{");
            value.AppendFormat("{0}{2}{1}", this.Identifier, this.Name, this.Seperator);
            value.Append("}");

            this.fieldKeyValue = value.ToString();
        }
        #endregion

        #region Public Static Methods & Functions
        public static FieldKey Parse(string value)
        {
            return FieldKey.Parse(value, FieldKey.DefaultSeperator);
        }

        public static FieldKey Parse(string value, char seperator)
        {
            Regex regEx = new Regex(RegExParsePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var match = regEx.Match(value);
            if (!match.Success || match.Groups[3].Value.Equals(seperator))
                throw new FormatException("The value specified can not be parsed.");

            return new FieldKey(match.Groups[2].Value, match.Groups[4].Value, seperator);
        }
        #endregion

        #region Public Static Implicit Operators
        public static implicit operator string(FieldKey value)
        {
            if (value == null)
                return null;

            return value.FieldKeyValue;
        }

        public static explicit operator FieldKey(PropertyInfo property)
        {
            return new FieldKey(property.DeclaringType.Name, property.Name);
        }
        #endregion
    }
}
