using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Controller;
using IceCreamManager.Model;

namespace IceCreamManager.UnitTests.Controller
{
    [TestClass]
    public class TestLanguageParser
    {
        LanguageManager Lang = LanguageManager.Reference;
        DatabaseManager Database = DatabaseManager.Reference;

        [TestMethod]
        public void TestLanguageFileParsing()
        {
            Lang.UserLanguage = "English";
            Lang.Save();
            // Test base English
            Assert.AreEqual("This could be anything.", Lang["Test"]);
            Assert.AreEqual("English test 2", Lang["Test2"]);
            Assert.AreEqual("English test 3", Lang["Test3"]);
            Assert.AreEqual("English test 4", Lang["Test4"]);
        }

        [TestMethod]
        public void TestLanguageSwitching()
        {

            Lang.UserLanguage = "Russian";
            Lang.Save();
            Assert.AreEqual("Russian test 1", Lang["Test"]);
            Assert.AreEqual("Russian test 2", Lang["Test2"]);
        }

        [TestMethod]
        public void TestUnicodeCharacters()
        {
            Lang.UserLanguage = "Russian";
            Lang.Save();
            Assert.AreEqual("номер", Lang["Test3"]);
        }

        [TestMethod]
        public void TestEnglishFallback()
        {
            Lang.UserLanguage = "Russian";
            Lang.Save();
            Assert.AreEqual("English test 4", Lang["Test4"]);
        }
    }
}
