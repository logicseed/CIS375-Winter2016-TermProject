using System;
using System.Data;
using System.IO;
using IceCreamManager.Model;

namespace IceCreamManager.Controller
{
    class BatchFileProcessing
    {
        DatabaseManager Database = DatabaseManager.DatabaseReference;
        private string fileLine;
        private string temp;
        private string[] recordTypes = { "IR", "TR", "SR", "T " };

        public void processHeaderFooter(string FilePath, int ID)
        {

        }
    }
}

