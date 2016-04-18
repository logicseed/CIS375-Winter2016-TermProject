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
        public Dictionary<string, string> ParseLanguageFile(string fileURI, bool languageNameOnly = false)
        {
            if (!File.Exists(fileURI)) return null;

            var ParsedStrings = new Dictionary<string, string>();

            string[] LanguageKeyValuePairs = File.ReadAllLines(fileURI);

            foreach (string KeyValuePair in LanguageKeyValuePairs)
            {
                var Line = KeyValuePair.Trim();
                if (Line.StartsWith("#")) continue; // Ignore comment lines
                if (Line.Length == 0) continue; // Ignore blank lines

                var Index = KeyValuePair.IndexOf('=', 1);
                if (Index < 1) continue; // Ignore invalid assignments

                var Key = Line.Substring(0, Index).Trim();
                var Value = Line.Substring(Index + 1).Trim();

                if(languageNameOnly)
                {
                    if (Key == "@Language")
                    {
                        ParsedStrings.Add(Key.TrimStart('@'), Value);
                        break;
                    }
                }
                else
                {
                    if (!ParsedStrings.ContainsKey(Key)) ParsedStrings.Add(Key, Value);
                }
            }

            return ParsedStrings;
        }



        
        #endregion Public Methods

        /// <summary>
        ///   Builds an array of strings contains the names of languages for which there exists a [LanguageName].lang
        ///   file in the application directory.
        /// </summary>
        /// <returns> Array of language names. </returns>
        public string[] GetValidLanguageFiles(string filesLocation, string filesExtension)
        {
            string[] ValidLanguageFiles = Directory.GetFiles(filesLocation, $"*{filesExtension}");

            // Strip off paths
            for (int i = 0; i < ValidLanguageFiles.Length; i++)
            {
                ValidLanguageFiles[i] = Path.GetFileNameWithoutExtension(ValidLanguageFiles[i]);
            }

            return ValidLanguageFiles;
        }






    }
}
