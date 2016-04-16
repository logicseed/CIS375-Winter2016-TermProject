using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Controller;

namespace IceCreamManager.UnitTests.Controller
{
    [TestClass]
    public class TestLanguageParser
    {
        LanguageParser Lang = LanguageParser.Reference;

        [TestMethod]
        public void TestLanguageFileParsing()
        {
            // Test base English
            Assert.AreEqual("This can be anything.", Lang["Test"]);
            Assert.AreEqual("English test 2", Lang["Test2"]);
            Assert.AreEqual("English test 3", Lang["Test3"]);
            Assert.AreEqual("English test 4", Lang["Test4"]);
        }

        [TestMethod]
        public void TestLanguageSwitching()
        {
            Lang.SelectedLangauge = "Russian";
            Assert.AreEqual("Russian test 1", Lang["Test"]);
            Assert.AreEqual("Russian test 2", Lang["Test2"]);
        }

        [TestMethod]
        public void TestUnicodeCharacters()
        {
            Lang.SelectedLangauge = "Russian";
            Assert.AreEqual("номер", Lang["Test3"]);
        }

        [TestMethod]
        public void TestEnglishFallback()
        {
            Lang.SelectedLangauge = "Russian";
            Assert.AreEqual("English test 4", Lang["Test4"]);
        }
    }
}
