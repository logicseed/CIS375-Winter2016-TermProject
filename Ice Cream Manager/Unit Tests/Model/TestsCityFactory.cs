using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IceCreamManager.Model;

namespace IceCreamManager.UnitTests.Model
{
    [TestClass]
    public class TestsCityFactory
    {
        CityFactory cityFactory = CityFactory.Reference;


        [TestMethod]
        public void New_CreateNewCity_InstantiatedCityObject()
        {
            City city = cityFactory.New();

            Assert.IsFalse(city == null, "Did not return an instantiated city object.");
            Assert.IsTrue(city.ID == 0, "ID was not set to default.");
            Assert.IsFalse(city.InDatabase, "InDatabase was not set to default.");
        }

    }
}
