using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Controller;

namespace IceCreamManager.UnitTests.Controller
{
    [TestClass]
    public class TestsBatchFileProcessing
    {
        HeaderFooter file;
        [TestMethod]
        public void Headercheck()
        {
            Assert.IsTrue(file.ProcessHeaderFooter("C:/Users/rodne/Desktop/batchfile/cityUpload.txt", BatchFileType.City));
        }
    }
}
