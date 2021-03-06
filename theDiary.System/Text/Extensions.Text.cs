﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.Text
{
    /// <summary>
    /// Provides extension methods and functions used in Text and <see cref="String"/> manipulation.
    /// </summary>
    public static class TextExtensions
    {
        #region Private Constant Declarations
        private const char WhiteSpace = ' ';
        private static readonly Regex readableRegEx = new Regex(@"(\S)([A-Z]+|(\d+)(?![A-Z_\-\.]|\b|\s)|[_\-\.]+)", RegexOptions.Compiled);
        private static readonly Regex readableRemovedRegEx = new Regex(@"[_\-\.]+");
        private static readonly Regex readableRegEx2 = new Regex(@"(\S)([A-Z]+|(\d+)(?![A-Z_\-\.]|\b|\s)|[_\-\.]+)", RegexOptions.Compiled);
        private static readonly Regex readableRemovedRegEx2 = new Regex(@"[_\-\.]+");
        private static readonly Func<Group, string> replace = (g) => readableRemovedRegEx.Replace(g.Value, string.Empty);
        private static readonly Func<Group, string> replace2 = (g) => readableRemovedRegEx2.Replace(g.Value, string.Empty);
        #endregion Private Constant Declarations

        #region Public Methods & Functions

        //public static string AsReadable6(this string text)
        //{
        //    Regex regex = new Regex(@"(\S)([A-Z]+|(\d+)(?![A-Z_\-\.]|\b|\s)|[_\-\.]+)");
        //    List<string> result = new List<string>();

        //    return regex.Replace(text, delegate(Match m)
        //    {
        //        Regex removed = new Regex(@"[_\-\.]+");
        //        return removed.Replace(m.Groups[1].Value, String.Empty) + " " + removed.Replace(m.Groups[2].Value, String.Empty);
        //    });

        //}

        //public static string AsReadable5(this string text)
        //{
        //    Regex regex = new Regex(@"(\S)([A-Z]+|(\d+)(?![A-Z_\-\.]|\b|\s)|[_\-\.]+)", RegexOptions.Compiled);
        //    Regex removed = new Regex(@"[_\-\.]+", RegexOptions.Compiled);
        //    Func<Group, string> replace = (g) => removed.Replace(g.Value, string.Empty);
        //    return regex.Replace(text, (m) => string.Format("{0} {1}", replace(m.Groups[1]), replace(m.Groups[2])));
        //}

        //public static string AsReadable4(this string text)
        //{
        //    Regex regex = new Regex(@"(\S)([A-Z]+|(\d+)(?![A-Z_\-\.]|\b|\s)|[_\-\.]+)");
        //    Regex removed = new Regex(@"[_\-\.]+");
        //    Func<Group, string> replace = (g) => removed.Replace(g.Value, string.Empty);
        //    return regex.Replace(text, (m) => string.Format("{0} {1}", replace(m.Groups[1]), replace(m.Groups[2])));
        //}

        //public static string AsReadable2(this string text)
        //{
        //    return readableRegEx.Replace(text, (m) => string.Format("{0} {1}", replace(m.Groups[1]), replace(m.Groups[2])));
        //}

        //public static string AsReadable3(this string text)
        //{
        //    return readableRegEx2.Replace(text, (m) => string.Format("{0} {1}", replace2(m.Groups[1]), replace2(m.Groups[2])));
        //}

        /// <summary>
        /// Determines if the <paramref name="value"/> is numeric in its content.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><c>True</c> if the value is numeric; otherwise <c>False</c>.</returns>
        public static bool IsNumber(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            double val;
            return double.TryParse(value, out val);
        }

        /// <summary>
        /// Attempts to make the specified <see cref="String"/> <paramref name="value"/> human readable.
        /// </summary>
        /// <param name="value">The <see cref="String"/> to make readable.</param>
        /// <param name="normalizeConditions">A bitwise combination of <see cref="ReadablilityCondition"/> used to specify how readability is determined.</param>
        /// <returns>A human readable <see cref="string"/>.</returns>
        public static string AsReadable(this string value, ReadablilityCondition normalizeConditions = ReadablilityCondition.Default)
        {
            if (value.IsNullEmptyOrWhiteSpace())
                return value;

            if (normalizeConditions == 0)
                normalizeConditions = ReadablilityCondition.Default;

            string workingValue = value;

            // Validate Whitespace Trim Conditions
            if (normalizeConditions.TrimStartWhitespace())
                workingValue = workingValue.TrimStart();

            if (normalizeConditions.TrimEndWhitespace())
                workingValue = workingValue.TrimEnd();

            // Validate Normalization Conditions
            if (!normalizeConditions.CanMakeReadable(workingValue))
                return workingValue;

            // Declarations
            System.StringBuilder returnValue = new System.StringBuilder();
            IEnumerable<string> workingValues = workingValue.SeperateForReadability(normalizeConditions);
            var iterator = workingValues.GetEnumerator();
            bool hasValue = iterator.MoveNext();
            bool isFirst = true;

            while (hasValue)
            {
                returnValue.Append(isFirst, normalizeConditions.Capitalize(iterator.Current), iterator.Current);
                hasValue = iterator.MoveNext();
                isFirst = false;
                if (hasValue)
                    returnValue.Append(TextExtensions.WhiteSpace);
            }

            return returnValue;
        }
        #endregion Public Methods & Functions

        #region Private Static Methods & Functions
        private static IEnumerable<string> SeperateForReadability(this string value, ReadablilityCondition conditions)
        {
            Char[] valueContent = value.ToCharArray();
            List<List<char>> vals = new List<List<char>>();
            for (int i = 0; i < valueContent.Length; i++)
            {
                if (i == 0
                    || (valueContent.IsUpper(i)
                        && (valueContent.PreviousIsLower(i)
                            || (valueContent.PreviousIsDigit(i) && conditions.HasFlag(ReadablilityCondition.ByDigit))
                            || valueContent.PreviousIsUnderscore(i)
                            || valueContent.NextIsLower(i)))
                    || (conditions.HasFlag(ReadablilityCondition.ByDigit) && valueContent.IsDigit(i) && !valueContent.PreviousIsDigit(i))
                    || (conditions.HasFlag(ReadablilityCondition.ByUnderscore) && valueContent.IsUnderscore(i)))
                    vals.Add(new List<char>());

                if (!valueContent.IsUnderscore(i))
                    vals[vals.Count - 1].Add(valueContent[i]);
            }

            foreach (var i in vals)
                yield return new string(i.ToArray());
        }

        private static bool CanMakeReadable(this ReadablilityCondition conditions, string value)
        {
            if (conditions.HasFlag(ReadablilityCondition.StopIfAnyWhitespace)
                && value.Contains(TextExtensions.WhiteSpace))
                return false;

            return true;
        }

        private static bool TrimStartWhitespace(this ReadablilityCondition conditions)
        {
            return conditions.HasFlag(ReadablilityCondition.TrimLeadingWhiteSpace);
        }

        private static bool TrimEndWhitespace(this ReadablilityCondition conditions)
        {
            return conditions.HasFlag(ReadablilityCondition.TrimTrailingWhiteSpace);
        }

        private static bool Capitalize(this ReadablilityCondition conditions)
        {
            return conditions.HasFlag(ReadablilityCondition.CapitalizeFirstCharacter);
        }

        private static string Capitalize(this ReadablilityCondition conditions, string value)
        {
            if (conditions.Capitalize() && !value.IsNullEmptyOrWhiteSpace())
            {
                char firstChar = value[0];
                string substring = value.Length == 0 ? string.Empty : value.Substring(1);

                if (Char.IsLower(firstChar))
                    return string.Format("{0}{1}", Char.ToUpper(firstChar), substring);
            }
            return value;
        }

        private static void Capitalize(this ReadablilityCondition conditions, ref string value)
        {
            value = conditions.Capitalize(value);
        }

        private static bool NextIsUpper(this Char[] value, int index)
        {
            Char @char;
            if (!value.HasNext(index, out @char))
                return false;

            return Char.IsUpper(@char);
        }

        private static bool IsUpper(this Char[] value, int index)
        {
            return Char.IsUpper(value[index]);
        }

        private static bool IsDigit(this Char[] value, int index)
        {
            return Char.IsDigit(value[index])
                || Char.IsNumber(value[index]);
        }

        private static bool IsUnderscore(this Char[] value, int index)
        {
            return value.IsOther(index, '_');
        }

        private static bool IsOther(this Char[] value, int index, params char[] other)
        {
            return other.Contains(value[index]);
        }

        private static bool PreviousIsUpper(this Char[] value, int index)
        {
            Char @char;
            if (!value.HasPrevious(index, out @char))
                return false;

            return Char.IsUpper(@char);
        }

        private static bool IsLower(this Char[] value, int index)
        {
            return Char.IsLower(value[index]);
        }

        private static bool NextIsLower(this Char[] value, int index)
        {
            Char @char;
            if (!value.HasNext(index, out @char))
                return false;

            return Char.IsLower(@char);
        }

        private static bool PreviousIsLower(this Char[] value, int index)
        {
            Char @char;
            if (!value.HasPrevious(index, out @char))
                return false;

            return Char.IsLower(@char);
        }

        private static bool NextIsDigit(this Char[] value, int index)
        {
            Char @char;
            if (!value.HasNext(index, out @char))
                return false;

            return Char.IsDigit(@char)
                || Char.IsNumber(@char);
        }

        private static bool PreviousIsDigit(this Char[] value, int index)
        {
            Char @char;
            if (!value.HasPrevious(index, out @char))
                return false;

            return Char.IsDigit(@char)
                || Char.IsNumber(@char);
        }

        private static bool NextIsUnderscore(this Char[] value, int index)
        {
            return value.NextIsOther(index, '_');
        }

        private static bool PreviousIsUnderscore(this Char[] value, int index)
        {
            return value.PreviousIsOther(index, '_');
        }

        private static bool NextIsOther(this Char[] value, int index, params char[] others)
        {
            Char @char;
            if (!value.HasNext(index, out @char))
                return false;

            return others.Contains(@char);
        }

        private static bool PreviousIsOther(this Char[] value, int index, params char[] others)
        {
            Char @char;
            if (!value.HasPrevious(index, out @char))
                return false;

            return others.Contains(@char);
        }

        private static bool HasNext(this Char[] value, int index)
        {
            return (index + 1 < value.Length);
        }

        private static bool HasNext(this Char[] value, int index, out Char @char)
        {
            @char = default(char);
            if (!value.HasNext(index))
                return false;

            @char = value[index + 1];
            return true;
        }

        private static bool HasPrevious(this Char[] value, int index)
        {
            return index > 0;
        }

        private static bool HasPrevious(this Char[] value, int index, out Char @char)
        {
            @char = default(char);
            if (!value.HasPrevious(index))
                return false;

            @char = value[index - 1];
            return true;
        }

        private static bool InsertLeadingWhiteSpace(this Char[] value, int index)
        {
            if (value.HasPrevious(index)
                && value.PreviousIsUpper(index)
                && (Char.IsLower(value[index])
                    || Char.IsUpper(value[index])
                        && value.NextIsLower(index)))
                return true;

            return false;
        }

        private static bool InsertTrailingWhiteSpace(this Char[] value, int index)
        {
            if (value.HasNext(index)
                && value.NextIsLower(index))
                return true;

            return false;
        }

        #endregion  Private Static Methods & Functions
    }

}
