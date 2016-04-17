using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Model;
using IceCreamManager.Controller;

namespace IceCreamManager.UnitTests.Model
{
    /// <summary>
    /// Summary description for TestsCity
    /// </summary>
    [TestClass]
    public class TestsCity
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        CityFactory cityFactory = CityFactory.Reference;

        [TestMethod]
        public void Label_SetTooShort_ThrowCityLabelException()
        {
            City city = cityFactory.New();
            string shortLabel = "".PadRight(Requirement.MinCityLabelLength - 1, '#');

            try
            {
                city.Label = shortLabel;
                Assert.Fail("Short label did not throw exception.");
            }
            catch (CityLabelException e)
            {
                Assert.AreEqual(Outcome.ValueTooSmall, e.Outcome, "Did not send ValueTooSmall Outcome.");
            }
        }

        [TestMethod]
        public void Label_SetTooLong_ThrowCityLabelException()
        {
            City city = cityFactory.New();
            string longLabel = "".PadRight(Requirement.MaxCityLabelLength + 1, '#');

            try
            {
                city.Label = longLabel;
                Assert.Fail("Long label did not throw exception.");
            }
            catch (CityLabelException e)
            {
                Assert.AreEqual(Outcome.ValueTooLarge, e.Outcome, "Did not send ValueTooLarge Outcome.");
            }
        }


        [TestMethod]
        public void Name_SetTooShort_ThrowCityNameException()
        {
            City city = cityFactory.New();
            string shortName = "".PadRight(Requirement.MinCityNameLength - 1, '#');

            try
            {
                city.Name = shortName;
                Assert.Fail("Short name did not throw exception.");
            }
            catch (CityNameException e)
            {
                Assert.AreEqual(Outcome.ValueTooSmall, e.Outcome, "Did not send ValueTooSmall Outcome.");
            }
        }

        [TestMethod]
        public void Name_SetTooLong_ThrowCityNameException()
        {
            City city = cityFactory.New();
            string longName = "".PadRight(Requirement.MaxCityNameLength + 1, '#');

            try
            {
                city.Name = longName;
                Assert.Fail("Long name did not throw exception.");
            }
            catch (CityNameException e)
            {
                Assert.AreEqual(Outcome.ValueTooLarge, e.Outcome, "Did not send ValueTooLarge Outcome.");
            }
        }


        [TestMethod]
        public void MethodName_Action_ExpectedResult()
        {
            RouteFactory routeFactory = RouteFactory.Reference;
            Route route = routeFactory.LoadByNumber(23);
            route.AddCity(cityFactory.Load("Dearborn 1"));
            if(route.Save())
            {
                Logger.Log(EntityType.Route, route.ID, EntityType.City, route.LastCityAddedID(), ActionSource.BatchFile, ActionType.AddCityToRoute, Outcome.Success);
            }

        }
    }
}
