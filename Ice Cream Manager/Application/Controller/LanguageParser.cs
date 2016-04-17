/// <project> IceCreamManager </project>
/// <module> LanguageParser </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-16 </date_created>

using System.Collections.Generic;
using System.IO;

namespace IceCreamManager.Controller
{
    public class LanguageParser
    {
        #region Public Methods

        /// <summary>
        ///   Creates a Dictionary of phrase key and phrase value from a file. File has format "Key=Value" per line,
        ///   extra spaces are trimmed. A line can begin with # to be considered a comment.
        /// </summary>
        /// <param name="fileURI"> Location of file. </param>
        /// <returns> Strings as key-value pairs. </returns>
        public Dictionary<string, string> ParseLanguageFile(string fileURI)
        {
            if (!File.Exists(fileURI)) return null;

            var ParsedStrings = new Dictionary<string, string>();

            string[] LanguageKeyValuePairs = File.ReadAllLines(fileURI);

            foreach (string KeyValuePair in LanguageKeyValuePairs)
            {
                if (KeyValuePair.StartsWith("#")) continue; // Ignore comment lines
                if (KeyValuePair.Trim().Length == 0) continue; // Ignore blank lines

                int Index = KeyValuePair.IndexOf("=");

                if (Index > 0)
                {
                    var Key = KeyValuePair.Substring(0, Index).Trim();
                    var Value = KeyValuePair.Substring(Index + 1).Trim();
                    if (!ParsedStrings.ContainsKey(Key)) ParsedStrings.Add(Key, Value);
                }
            }

            return ParsedStrings;
        }

        /// <summary>
        ///   Builds an array of strings contains the names of languages for which there exists a [LanguageName].lang
        ///   file in the application directory.
        /// </summary>
        /// <returns> Array of language names. </returns>
        public string[] GetValidLanguages(string FilesLocation, string FilesExtension)
        {
            string[] ValidLanguages = Directory.GetFiles(FilesLocation, $"*{FilesExtension}");

            // Strip off paths
            for (int i = 0; i < ValidLanguages.Length; i++)
            {
                ValidLanguages[i] = Path.GetFileNameWithoutExtension(ValidLanguages[i]);
            }

            return ValidLanguages;
        }
        #endregion Public Methods
    }
}
