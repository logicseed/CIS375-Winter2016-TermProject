using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManager.Controller;

namespace IceCreamManager.Model
{
    public class LanguageManager
    {
        #region Singleton
        private static readonly LanguageManager SingletonInstance = new LanguageManager();
        public static LanguageManager Reference { get { return SingletonInstance; } }
        private LanguageManager() { }
        #endregion Singleton

        private string userCurrency = "$";
        private LanguageParser Parser = new LanguageParser();

        public void Save()
        {
            throw new NotImplementedException();
        }

        private string userLanguage = "English";
        private Dictionary<string, string> LoadedDefaultLanguage;
        private Dictionary<string, string> LoadedUserLanguage;

        public string UserCurrency { get { return userCurrency;}
        set
            {
                userCurrency = value;
            }
        }
        public string UserLanguage { get { return userLanguage; }
        set
            {
                userLanguage = value;
            }
        }

        public string this[string key]
        {
            get
            {
                if (LoadedUserLanguage.ContainsKey(key)) return LoadedUserLanguage[key];
                return LoadedDefaultLanguage[key];
            }
        }
    }
}
