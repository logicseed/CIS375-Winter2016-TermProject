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

        private static readonly LanguageParser SingletonInstance = new LanguageParser();

        /// <summary>
        ///   Reference to the DatabaseManager Singleton instance. 
        /// </summary>
        public static LanguageParser Reference { get { return SingletonInstance; } }

        #endregion Singleton

        private Dictionary<string, string> EnglishStrings;
        private Dictionary<string, string> UserLanguageStrings;

        private string EnglishFile => "../../../English.lang";
        private string UserLanguageFile => $"../../../{Properties.Settings.Default.Language}.lang";

        private bool EnglishOnly = false;

        private LanguageParser() // Private as Singleton
        {
            ParseEnglishFile();

            if (Properties.Settings.Default.Language == "English") EnglishOnly = true;
            else ParseUserLanguageFile();
        }

        private void ParseEnglishFile()
        {
            EnglishStrings = ParseLanguageFile(EnglishFile);

            if (EnglishStrings == null) throw new Exception("English language file error.");
        }

        private void ParseUserLanguageFile()
        {
            UserLanguageStrings = ParseLanguageFile(UserLanguageFile);

            if (UserLanguageStrings == null) EnglishOnly = true;
        }

        private Dictionary<string,string> ParseLanguageFile(string FileURI)
        {
            if (!File.Exists(FileURI)) return null;

            var ParsedStrings = new Dictionary<string, string>();

            string[] LanguageKeyValuePairs = File.ReadAllLines(FileURI);

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

        public string this[string key]
        {
            get
            {
                if(EnglishOnly || Properties.Settings.Default.Language == "English")
                {
                    if (EnglishStrings.ContainsKey(key)) return EnglishStrings[key];
                }
                else
                {
                    if (UserLanguageStrings.ContainsKey(key)) return UserLanguageStrings[key];
                    if (EnglishStrings.ContainsKey(key)) return EnglishStrings[key];
                }
                return "BAD LANGUAGE CODE";
            }
        }

        public string SelectedLangauge
        {
            get
            {
                return Properties.Settings.Default.Language;
            }
            set
            {
                Properties.Settings.Default.Language = value;
                if (value != "English")
                {
                    EnglishOnly = false;
                    ParseUserLanguageFile();
                }
            }
        }
    }
}
