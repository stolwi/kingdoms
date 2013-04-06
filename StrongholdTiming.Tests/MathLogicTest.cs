using SHKEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StrongholdTiming.Tests
{
    
    
    /// <summary>
    ///This is a test class for MathLogicTest and is intended
    ///to contain all MathLogicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MathLogicTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Bilaterate
        ///</summary>
        [TestMethod()]
        public void BilaterateTest()
        {
            double x = 10.0F; 
            double u = 6.40F; 
            double t = 7.81F; 
            Location expected = new Location(6, 5);
            Location actual;

            actual = MathLogic.Bilaterate(x, u, t);

            Assert.AreEqual(expected.X, actual.X, .01F);
            Assert.AreEqual(expected.Y, actual.Y, .01F);
        }

        /// <summary>
        ///A test for Trilaterate
        ///</summary>
        [TestMethod()]
        public void TrilaterateTest()
        {
            double x = 10F;
            double u = 6.40F;
            double t = 7.81F;

            Location p1 = new Location(0,0); 
            Location p2 = new Location(x, 0); 
            Location offset = MathLogic.Bilaterate(x, u, t);
            Location p3 = new Location(p2.X - offset.X, offset.Y);
            double r1 = Math.Sqrt(34); 
            double r2 = Math.Sqrt(34); 
            double r3 = Math.Sqrt(65); 
            Location expected = new Location(5, -3); 
            Location actual;

            actual = MathLogic.Trilaterate(p1, p2, p3, r1, r2, r3);

            Assert.AreEqual(expected.X, actual.X, .01F);
            Assert.AreEqual(expected.Y, actual.Y, .01F);
        }
    }
}
