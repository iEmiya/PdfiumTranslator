// Copyright (c) 2015 Ravi Bhavnani
// License: Code Project Open License
// http://www.codeproject.com/info/cpol10.aspx
// https://www.codeproject.com/kb/ip/googletranslator.aspx

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;


namespace PdfiumTranslator
{
    /// <summary>
    /// Translates text using Google's online language tools.
    /// </summary>
    public class GoogleTranslate
    {
        #region Properties

        /// <summary>
        /// Gets the supported languages.
        /// </summary>
        public static IEnumerable<string> Languages
        {
            get
            {
                GoogleTranslate.EnsureInitialized();
                return GoogleTranslate._languageModeMap.Keys.OrderBy(p => p);
            }
        }

        /// <summary>
        /// Gets the time taken to perform the translation.
        /// </summary>
        public TimeSpan TranslationTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the url used to speak the translation.
        /// </summary>
        /// <value>The url used to speak the translation.</value>
        public string TranslationSpeechUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public Exception Error
        {
            get;
            private set;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Translates the specified source text.
        /// </summary>
        /// <param name="sourceText">The source text.</param>
        /// <param name="sourceLanguage">The source language.</param>
        /// <param name="targetLanguage">The target language.</param>
        /// <returns>The translation.</returns>
        public string Translate
            (string sourceText,
             string sourceLanguage,
             string targetLanguage)
        {
            // Initialize
            GoogleTranslate.EnsureInitialized();
            this.Error = null;
            this.TranslationSpeechUrl = null;
            this.TranslationTime = TimeSpan.Zero;
            DateTime tmStart = DateTime.Now;
            string translation = string.Empty;

            try
            {
                // Download translation
                sourceText = StringBuilderReplace(sourceText, _replaceCharsBeforeTranslate);
                string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                                            GoogleTranslate.LanguageEnumToIdentifier(sourceLanguage),
                                            GoogleTranslate.LanguageEnumToIdentifier(targetLanguage),
                                            HttpUtility.UrlEncode(sourceText));
                string outputFile = Path.GetTempFileName();
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    wc.DownloadFile(url, outputFile);
                }

                // Get translated text
                if (File.Exists(outputFile))
                {

                    // Get phrase collection
                    string text = File.ReadAllText(outputFile);
                    int index = text.IndexOf(string.Format(",,\"{0}\"", GoogleTranslate.LanguageEnumToIdentifier(sourceLanguage)));
                    if (index == -1)
                    {
                        // Translation of single word
                        int startQuote = text.IndexOf('\"');
                        if (startQuote != -1)
                        {
                            int endQuote = text.IndexOf('\"', startQuote + 1);
                            if (endQuote != -1)
                            {
                                translation = text.Substring(startQuote + 1, endQuote - startQuote - 1);
                            }
                        }
                    }
                    else
                    {
                        // Translation of phrase
                        text = text.Substring(0, index);
                        text = text.Replace("],[", ",");
                        text = text.Replace("]", string.Empty);
                        text = text.Replace("[", string.Empty);
                        text = text.Replace("\",\"", "\"");

                        // Get translated phrases
                        string[] phrases = text.Split(new[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; (i < phrases.Count()); i += 2)
                        {
                            string translatedPhrase = phrases[i];
                            if (translatedPhrase.StartsWith(",,"))
                            {
                                i--;
                                continue;
                            }

                            translatedPhrase = StringBuilderReplace(translatedPhrase, _replaceCharsAfterTranslate);
                            translation += translatedPhrase + "  ";
                        }
                    }

                    // Fix up translation
                    translation = translation.Trim();
                    translation = translation.Replace(" ?", "?");
                    translation = translation.Replace(" !", "!");
                    translation = translation.Replace(" ,", ",");
                    translation = translation.Replace(" .", ".");
                    translation = translation.Replace(" ;", ";");

                    // And translation speech URL
                    this.TranslationSpeechUrl = string.Format("https://translate.googleapis.com/translate_tts?ie=UTF-8&q={0}&tl={1}&total=1&idx=0&textlen={2}&client=gtx",
                                                               HttpUtility.UrlEncode(translation), GoogleTranslate.LanguageEnumToIdentifier(targetLanguage), translation.Length);
                }
            }
            catch (Exception ex)
            {
                this.Error = ex;
            }

            // Return result
            this.TranslationTime = DateTime.Now - tmStart;
            return translation;
        }

        private string StringBuilderReplace(string text, Dictionary<string, string> replaceChars)
        {
            var builder = new StringBuilder(text);
            foreach (var p in replaceChars) builder.Replace(p.Key, p.Value);
            return builder.ToString();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Converts a language to its identifier.
        /// </summary>
        /// <param name="language">The language."</param>
        /// <returns>The identifier or <see cref="string.Empty"/> if none.</returns>
        private static string LanguageEnumToIdentifier
            (string language)
        {
            string mode = string.Empty;
            GoogleTranslate.EnsureInitialized();
            GoogleTranslate._languageModeMap.TryGetValue(language, out mode);
            return mode;
        }

        /// <summary>
        /// Ensures the translator has been initialized.
        /// </summary>
        private static void EnsureInitialized()
        {
            if (GoogleTranslate._languageModeMap == null)
            {
                GoogleTranslate._languageModeMap = new Dictionary<string, string>();
                GoogleTranslate._languageModeMap.Add("Afrikaans", "af");
                GoogleTranslate._languageModeMap.Add("Albanian", "sq");
                GoogleTranslate._languageModeMap.Add("Arabic", "ar");
                GoogleTranslate._languageModeMap.Add("Armenian", "hy");
                GoogleTranslate._languageModeMap.Add("Azerbaijani", "az");
                GoogleTranslate._languageModeMap.Add("Basque", "eu");
                GoogleTranslate._languageModeMap.Add("Belarusian", "be");
                GoogleTranslate._languageModeMap.Add("Bengali", "bn");
                GoogleTranslate._languageModeMap.Add("Bulgarian", "bg");
                GoogleTranslate._languageModeMap.Add("Catalan", "ca");
                GoogleTranslate._languageModeMap.Add("Chinese", "zh-CN");
                GoogleTranslate._languageModeMap.Add("Croatian", "hr");
                GoogleTranslate._languageModeMap.Add("Czech", "cs");
                GoogleTranslate._languageModeMap.Add("Danish", "da");
                GoogleTranslate._languageModeMap.Add("Dutch", "nl");
                GoogleTranslate._languageModeMap.Add("English", "en");
                GoogleTranslate._languageModeMap.Add("Esperanto", "eo");
                GoogleTranslate._languageModeMap.Add("Estonian", "et");
                GoogleTranslate._languageModeMap.Add("Filipino", "tl");
                GoogleTranslate._languageModeMap.Add("Finnish", "fi");
                GoogleTranslate._languageModeMap.Add("French", "fr");
                GoogleTranslate._languageModeMap.Add("Galician", "gl");
                GoogleTranslate._languageModeMap.Add("German", "de");
                GoogleTranslate._languageModeMap.Add("Georgian", "ka");
                GoogleTranslate._languageModeMap.Add("Greek", "el");
                GoogleTranslate._languageModeMap.Add("Haitian Creole", "ht");
                GoogleTranslate._languageModeMap.Add("Hebrew", "iw");
                GoogleTranslate._languageModeMap.Add("Hindi", "hi");
                GoogleTranslate._languageModeMap.Add("Hungarian", "hu");
                GoogleTranslate._languageModeMap.Add("Icelandic", "is");
                GoogleTranslate._languageModeMap.Add("Indonesian", "id");
                GoogleTranslate._languageModeMap.Add("Irish", "ga");
                GoogleTranslate._languageModeMap.Add("Italian", "it");
                GoogleTranslate._languageModeMap.Add("Japanese", "ja");
                GoogleTranslate._languageModeMap.Add("Korean", "ko");
                GoogleTranslate._languageModeMap.Add("Lao", "lo");
                GoogleTranslate._languageModeMap.Add("Latin", "la");
                GoogleTranslate._languageModeMap.Add("Latvian", "lv");
                GoogleTranslate._languageModeMap.Add("Lithuanian", "lt");
                GoogleTranslate._languageModeMap.Add("Macedonian", "mk");
                GoogleTranslate._languageModeMap.Add("Malay", "ms");
                GoogleTranslate._languageModeMap.Add("Maltese", "mt");
                GoogleTranslate._languageModeMap.Add("Norwegian", "no");
                GoogleTranslate._languageModeMap.Add("Persian", "fa");
                GoogleTranslate._languageModeMap.Add("Polish", "pl");
                GoogleTranslate._languageModeMap.Add("Portuguese", "pt");
                GoogleTranslate._languageModeMap.Add("Romanian", "ro");
                GoogleTranslate._languageModeMap.Add("Russian", "ru");
                GoogleTranslate._languageModeMap.Add("Serbian", "sr");
                GoogleTranslate._languageModeMap.Add("Slovak", "sk");
                GoogleTranslate._languageModeMap.Add("Slovenian", "sl");
                GoogleTranslate._languageModeMap.Add("Spanish", "es");
                GoogleTranslate._languageModeMap.Add("Swahili", "sw");
                GoogleTranslate._languageModeMap.Add("Swedish", "sv");
                GoogleTranslate._languageModeMap.Add("Tamil", "ta");
                GoogleTranslate._languageModeMap.Add("Telugu", "te");
                GoogleTranslate._languageModeMap.Add("Thai", "th");
                GoogleTranslate._languageModeMap.Add("Turkish", "tr");
                GoogleTranslate._languageModeMap.Add("Ukrainian", "uk");
                GoogleTranslate._languageModeMap.Add("Urdu", "ur");
                GoogleTranslate._languageModeMap.Add("Vietnamese", "vi");
                GoogleTranslate._languageModeMap.Add("Welsh", "cy");
                GoogleTranslate._languageModeMap.Add("Yiddish", "yi");
            }

            if (_replaceCharsBeforeTranslate == null)
            {
                _replaceCharsBeforeTranslate = new Dictionary<string, string>()
                {
                    {"%", "<p0c>"},
                    {"&", "<c0e>"},
                    {";", "<p0v>"},
                    {"[", "<sb0l>"},
                    {"]", "<sb0r>"},
                    {"\"", "<sb1a>"},
                    {"’", "<sb1b>"},
                };
            }

            if (_replaceCharsAfterTranslate == null)
            {
                _replaceCharsAfterTranslate = new Dictionary<string, string>()
                {
                    {@"\u003cp0c\u003e", "%"},
                    {@"\u003cc0e\u003e", "&"},
                    {@"\u003cp0v\u003e", ";"},
                    {@"\u003csb0l\u003e", "["}, {@"\u003cSb0l\u003e", "[" }, 
                    {@"\u003csb0r\u003e", "]"}, {@"\u003cSb0r\u003e", "]" },
                    {@"\u003csb1a\u003e", "\""}, {@"\u003cSb1a\u003e", "\""},
                    {@"\u003csb1b\u003e", "’"}, {@"\u003cSb1b\u003e", "’"},
                };
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// The language to translation mode map.
        /// </summary>
        private static Dictionary<string, string> _languageModeMap;

        private static Dictionary<string, string> _replaceCharsBeforeTranslate;
        private static Dictionary<string, string> _replaceCharsAfterTranslate;

        #endregion
    }
}
