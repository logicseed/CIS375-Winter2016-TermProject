/// <project> IceCreamManager </project>
/// <module> LanguageParser </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-16 </date_created>

using System;
using System.Collections.Generic;
using System.IO;

namespace IceCreamManager.Controller
{
    public sealed class LanguageParser
    {
        #region Singleton

        public static LanguageParser Reference { get { return SingletonInstance; } }

        private static readonly LanguageParser SingletonInstance = new LanguageParser();

        #endregion Singleton

        #region Public Properties

        /// <summary>
        /// Provides access to read and temporarily change the user selected language. Immediately
        /// parses the language file for the language this property was set.
        /// </summary>
        public string SelectedLangauge
        {
            get
            {
                return Properties.Settings.Default.Language;
            }
            set
            {
                Properties.Settings.Default.Language = value;
                if (value != FallbackLanguage)
                {
                    FallbackOnly = false;
                    ParseUserLanguageFile();
                }
            }
        }

        #endregion Public Properties

        #region Public Indexers

        /// <summary>
        /// Provides indexer access to values through their keys.
        /// </summary>
        /// <param name="key">Language phrase code.</param>
        /// <returns>Localized language phrase value.</returns>
        public string this[string key]
        {
            get
            {
                if (FallbackOnly || Properties.Settings.Default.Language == FallbackLanguage)
                {
                    if (FallbackStrings.ContainsKey(key)) return FallbackStrings[key];
                }
                else
                {
                    if (UserLanguageStrings.ContainsKey(key)) return UserLanguageStrings[key];
                    // Last chance English fall-back.
                    if (FallbackStrings.ContainsKey(key)) return FallbackStrings[key];
                }
                return ""; // Fail gracefully
            }
        }

        #endregion Public Indexers

        #region Private Fields

        // Simplifies first conditional to return the default phrase.
        private bool FallbackOnly = false;

        // Language strings in key-value pairs
        private Dictionary<string, string> FallbackStrings;

        private Dictionary<string, string> UserLanguageStrings;

        #endregion Private Fields

        #region Private Constructors

        private LanguageParser() // Private as Singleton
        {
            ParseFallbackLanguageFile();

            if (Properties.Settings.Default.Language == FallbackLanguage) FallbackOnly = true;
            else ParseUserLanguageFile();
        }

        #endregion Private Constructors

        #region Private Properties

        // Language file locations
        private string FallbackLanguageFile => $"../../../{FallbackLanguage}.lang";

        private string FallbackLanguage => "English";
        private string UserLanguageFile => $"../../../{Properties.Settings.Default.Language}.lang";
        #endregion Private Properties

        #region Private Methods

        private void ParseFallbackLanguageFile()
        {
            FallbackStrings = ParseLanguageFile(FallbackLanguageFile);

            if (FallbackStrings == null) throw new Exception("Fall-back language file error.");
        }

        private void ParseUserLanguageFile()
        {
            UserLanguageStrings = ParseLanguageFile(UserLanguageFile);

            if (UserLanguageStrings == null) FallbackOnly = true; // Fail gracefully
        }

        /// <summary>
        ///   Creates a Dictionary of phrase key and phrase value from a file. File has format "Key=Value" per line,
        ///   extra spaces are trimmed.
        /// </summary>
        /// <param name="fileURI"> Location of file. </param>
        /// <returns> Strings as key-value pairs. </returns>
        private Dictionary<string, string> ParseLanguageFile(string fileURI)
        {
            if (!File.Exists(fileURI)) return null;

            var ParsedStrings = new Dictionary<string, string>();

            string[] LanguageKeyValuePairs = File.ReadAllLines(fileURI);

            foreach (string KeyValuePair in LanguageKeyValuePairs)
            {
                int Index = KeyValuePair.IndexOf("=");

                if (Index > 0)
                {
                    var Key = KeyValuePair.Substring(0, Index).Trim(' ');
                    var Value = KeyValuePair.Substring(Index + 1).Trim(' ');
                    if (!ParsedStrings.ContainsKey(Key)) ParsedStrings.Add(Key, Value);
                }
            }

            return ParsedStrings;
        }
        #endregion Private Methods
    }
}
