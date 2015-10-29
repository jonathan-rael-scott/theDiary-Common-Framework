using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Translation;
using System.Threading.Tasks;

namespace theDiary.Google.Translation
{
    public sealed class GoogleTranslater
        : System.Text.Translation.ITranslationProviderAsync
    {
        #region Constructors
        public GoogleTranslater()
            : this(System.Globalization.CultureInfo.InstalledUICulture)
        {

        }

        public GoogleTranslater(System.Globalization.CultureInfo sourceCulture)
            : base()
        {
            if (sourceCulture == null)
                throw new ArgumentNullException("sourceCulture");

            this.translationHelper = new GoogleTranslateWithNoApiHelper.TranslateHelper();
            this.sourceCulture = sourceCulture;
        }
        #endregion

        #region Private Declarations
        private GoogleTranslateWithNoApiHelper.TranslateHelper translationHelper;
        private static RegExPattern languagePattern = new RegExPattern("((?:[a-z][a-z]+))", System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        private string uiCultureLanguage = null;
        private string defaultCultureLanguage = null;
        private System.Globalization.CultureInfo sourceCulture;
        private string sourceCultureLanguage = null;
        #endregion

        #region Public Read-Only Properties
        public System.Globalization.CultureInfo CurrentUICulture
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentUICulture;
            }
        }

        public string CurrentUILanguageCode
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            }
        }

        public string CurrentUILanguage
        {
            get
            {
                if (this.uiCultureLanguage == null)
                    this.uiCultureLanguage = GoogleTranslater.languagePattern.Match(System.Globalization.CultureInfo.CurrentUICulture.EnglishName).Value;

                return this.uiCultureLanguage;
            }
        }

        public System.Globalization.CultureInfo DefaultUICulture
        {
            get
            {
                return System.Globalization.CultureInfo.InstalledUICulture;
            }
        }

        public string DetaultUILanguageCode
        {
            get
            {
                return this.DefaultUICulture.TwoLetterISOLanguageName;
            }
        }

        public string DefaultUILanguage
        {
            get
            {
                if (this.defaultCultureLanguage == null)
                    this.defaultCultureLanguage = GoogleTranslater.languagePattern.Match(this.DefaultUICulture.EnglishName).Value;

                return this.defaultCultureLanguage;
            }
        }

        public System.Globalization.CultureInfo SourceCulture
        {
            get
            {
                return this.sourceCulture;
            }
        }

        public string SourceLanguageCode
        {
            get
            {
                return this.sourceCulture.TwoLetterISOLanguageName;
            }
        }

        public string SourceLanguage
        {
            get
            {
                if (this.sourceCultureLanguage == null)
                    this.sourceCultureLanguage = GoogleTranslater.languagePattern.Match(this.sourceCulture.EnglishName).Value;

                return this.sourceCultureLanguage;
            }
        }
        #endregion

        #region Public Methods & Functions
        public string Translate(string input, System.Globalization.CultureInfo targetCulture)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (targetCulture == null)
                throw new ArgumentNullException("targetCulture");

            if (this.SourceCulture == targetCulture)
                throw new InvalidOperationException("The input does not require translation.");

            var result = this.translationHelper.TranslateThis(input, this.SourceCulture.TwoLetterISOLanguageName, targetCulture.TwoLetterISOLanguageName);
            return result.TranslatedText;
        }

        public string Translate(string input, System.Globalization.CultureInfo sourceCulture, System.Globalization.CultureInfo targetCulture)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (sourceCulture == null)
                throw new ArgumentNullException("sourceCulture");

            if (targetCulture == null)
                throw new ArgumentNullException("targetCulture");

            if (sourceCulture == targetCulture)
                throw new InvalidOperationException("The input does not require translation.");
            string returnValue = string.Empty;
            try
            {
                var result = this.translationHelper.TranslateThis(input, sourceCulture.TwoLetterISOLanguageName, targetCulture.TwoLetterISOLanguageName);
                returnValue = (result.Meanings.Count > 0 && result.Meanings.FirstOrDefault().Terms.Count > 0) ? result.Meanings.FirstOrDefault().Terms.FirstOrDefault() : result.TranslatedText;
            }
            catch(NullReferenceException)
            {
                try
                {                    
                    
                    string[] words = input.Split(' ');
                    if (words.Length == 1)
                    {
                        returnValue = input;
                    }
                    else
                    {
                        System.StringBuilder sb = new System.StringBuilder();
                        foreach (string val in words)

                            sb.AppendFormat("{0} ", this.Translate(val, sourceCulture, targetCulture));

                        returnValue = sb.ToString();
                    }
                }
                catch(NullReferenceException)
                {
                    returnValue = input;
                }
            }
            return this.KeepCaseSentitivity(input, returnValue);
        }

        private string KeepCaseSentitivity(string original, string translated)
        {
            if (original.Equals(translated))
                return original;

            string[] originalWords = original.Split(' ');
            string[] translatedWords = translated.Split(' ');
            System.StringBuilder returnValue = new System.StringBuilder();
            for (int i = 0; i < originalWords.Length; i++)
            {
                if (char.IsUpper(originalWords[i][0]) && !char.IsUpper(translatedWords[i][0]))
                    translatedWords[i] = char.ToUpper(translatedWords[i][0]) + translatedWords[i].Substring(1);
                
                returnValue.Append(translatedWords[i]);
                if (i < originalWords.Length - 1)
                    returnValue.Append(" ");
            }

            return returnValue;
        }
        public string Translate(string input, string targetLanguage)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (string.IsNullOrWhiteSpace(targetLanguage))
                throw new ArgumentNullException("targetLanguage");

            System.Globalization.CultureInfo targetCulture = System.Globalization.CultureInfo.GetCultureInfo(targetLanguage);

            return this.Translate(input, this.SourceCulture, targetCulture);
        }

        public string Translate(string input, string sourceLanguage, string targetLanguage)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (string.IsNullOrWhiteSpace(sourceLanguage))
                throw new ArgumentNullException("sourceLanguage");

            if (string.IsNullOrWhiteSpace(targetLanguage))
                throw new ArgumentNullException("targetLanguage");

            System.Globalization.CultureInfo targetCulture = System.Globalization.CultureInfo.GetCultureInfo(targetLanguage);
            System.Globalization.CultureInfo sourceCulture = System.Globalization.CultureInfo.GetCultureInfo(targetLanguage);

            return this.Translate(input, sourceCulture, targetCulture);
        }
        #endregion

        #region Public Astnc Methods & Functions
        public void TranslateAsync(string input, System.Globalization.CultureInfo targetCulture, TranslateTextCallBack callBack)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (targetCulture == null)
                throw new ArgumentNullException("targetCulture");

            if (callBack == null)
                throw new ArgumentNullException("callBack");

            this.TranslateAsync(input, this.SourceCulture, targetCulture, callBack);
        }

        public void TranslateAsync(string input, System.Globalization.CultureInfo sourceCulture, System.Globalization.CultureInfo targetCulture, TranslateTextCallBack callBack)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (sourceCulture == null)
                throw new ArgumentNullException("sourceCulture");

            if (targetCulture == null)
                throw new ArgumentNullException("targetCulture");

            if (callBack == null)
                throw new ArgumentNullException("callBack");


            TranslateDetails translationDetails = this.CreateTranslateDetails(input, sourceCulture, targetCulture);
            System.Threading.ThreadPool.QueueUserWorkItem(a=>{
                try
                {
                    this.SetTranslationDetails(translationDetails, this.Translate(input, sourceCulture, targetCulture));
                }
                catch (Exception ex)
                {
                    this.SetTranslationDetails(translationDetails, ex);
                }
                finally
                {
                    callBack.Invoke(translationDetails);
                }
            });
        }

        public void TranslateAsync(string input, string targetLanguage, TranslateTextCallBack callBack)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (string.IsNullOrWhiteSpace(targetLanguage))
                throw new ArgumentNullException("targetLanguage");

            if (callBack == null)
                throw new ArgumentNullException("callBack");

            System.Globalization.CultureInfo targetCulture = System.Globalization.CultureInfo.GetCultureInfo(targetLanguage);
            
            this.TranslateAsync(input, this.SourceCulture, targetCulture, callBack);
        }

        public void TranslateAsync(string input, string sourceLanguage, string targetLanguage, TranslateTextCallBack callBack)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");

            if (string.IsNullOrWhiteSpace(sourceLanguage))
                throw new ArgumentNullException("sourceLanguage");

            if (string.IsNullOrWhiteSpace(targetLanguage))
                throw new ArgumentNullException("targetLanguage");

            if (callBack == null)
                throw new ArgumentNullException("callBack");

            System.Globalization.CultureInfo targetCulture = System.Globalization.CultureInfo.GetCultureInfo(targetLanguage);
            System.Globalization.CultureInfo sourceCulture = System.Globalization.CultureInfo.GetCultureInfo(targetLanguage);
            
            this.TranslateAsync(input, this.SourceCulture, targetCulture, callBack);
        }
        #endregion
    }    
}
