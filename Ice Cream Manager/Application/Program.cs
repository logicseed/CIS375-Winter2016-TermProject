/// <project> IceCreamManager </project>
/// <module> Program </module>
/// <author> Marc King </author>
/// <date_created> 2016-03-26 </date_created>

using System;
using System.Windows.Forms;

using IceCreamManager.Model;
using IceCreamManager.View;

namespace IceCreamManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LanguageManager.Reference.InitializeLanguages();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
