/// <project> IceCreamManager </project>
/// <module> LanguageManager </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-25 </date_created>

using System;
using System.Collections.Generic;
using IceCreamManager.Controller;

namespace IceCreamManager.Model
{
    public class LanguageManager
    {
        #region Singleton

        public static LanguageManager Reference { get { return SingletonInstance; } }
        private static readonly LanguageManager SingletonInstance = new LanguageManager();

        private LanguageManager()
        {
            
        }

        internal void InitializeLanguages()
        {
            BuildDefaultLanguage();
            LoadUserLanguage();
        }

        internal Dictionary<string, string> GetAvailableLanguages()
        {
            var languages = new Dictionary<string, string>();
            var languageFiles = Parser.GetValidLanguageFiles(fileLocation, fileExtension);

            for (int i = 0; i < languageFiles.Length; i++)
            {
                var name = Parser.ParseLanguageFile(fileLocation + languageFiles[i] + fileExtension, true)["Language"];
                languages.Add(languageFiles[i], name);
            }

            return languages;
        }

        internal KeyValuePair<string,string> GetCurrentLanguagePair()
        {
            var name = Parser.ParseLanguageFile(fileLocation + userLanguage + fileExtension, true)["Language"];
            var pair = new KeyValuePair<string, string>(userLanguage, name);
            return pair;
        }

        #endregion Singleton

        #region Public Properties

        public string UserCurrency
        {
            get { return userCurrency; }
            set { userCurrency = value; }
        }

        public string UserLanguage
        {
            get { return userLanguage; }
            set { userLanguage = value; }
        }

        #endregion Public Properties

        #region Public Indexers

        public string this[string key]
        {
            get
            {
                if (LoadedUserLanguage.ContainsKey(key)) return LoadedUserLanguage[key];
                return LoadedDefaultLanguage[key];
            }
        }

        #endregion Public Indexers

        #region Public Methods

        public void Save()
        {
            var sql = $"UPDATE Settings SET Language = '{userLanguage}', Currency = '{userCurrency}' WHERE ID = 1";
            Database.NonQuery(sql);
            LoadUserLanguage();
            Manage.Events.ChangedLanguage();
        }

        

        #endregion Public Methods

        #region Private Fields

        private Dictionary<string, string> LoadedDefaultLanguage;
        private Dictionary<string, string> LoadedUserLanguage;
        private LanguageParser Parser = new LanguageParser();
        private string userCurrency = "$";
        private string userLanguage = "English";
        private string defaultLanguage = "English";
        private string fileExtension = ".lang";
#if DEBUG   // Development
        private string fileLocation = "../../../";
#else       // Production
        private string fileLocation = "";
#endif


        #endregion Private Fields

        private void BuildDefaultLanguage()
        {
            LoadedDefaultLanguage = Parser.ParseLanguageFile(fileLocation + defaultLanguage + fileExtension);
        }

        private void BuildUserLanguage()
        {
            LoadedUserLanguage = Parser.ParseLanguageFile(fileLocation + userLanguage + fileExtension);

        }

        private void LoadUserLanguage()
        {
            var sql = $"SELECT * FROM Settings WHERE ID = 1";
            var table = Database.Query(sql);
            userLanguage = table.Row().Col<string>("Language");
            userCurrency = table.Row().Col<string>("Currency");
            BuildUserLanguage();
        }
    }
}
