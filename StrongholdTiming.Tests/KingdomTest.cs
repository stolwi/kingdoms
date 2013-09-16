using SHKEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StrongholdTiming.Tests
{
    
    
    /// <summary>
    ///This is a test class for KingdomTest and is intended
    ///to contain all KingdomTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KingdomTest
    {


        private TestContext testContextInstance;
        private Kingdom kingdom;

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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            kingdom = new Kingdom(1);

            Village v1 = kingdom.GetVillageByName("Polaris");
            Village v2 = kingdom.GetVillageByName("Sirius");
            Village v3 = kingdom.GetVillageByName("Betelguese");

            int x = 128;
            int u = 93;
            int t = 80;

            kingdom.AddEdge(new Edge { FromVillageId = v1.Id, ToVillageId = v2.Id, Time = x, TimeType = "m" });
            kingdom.AddEdge(new Edge { FromVillageId = v1.Id, ToVillageId = v3.Id, Time = u, TimeType = "m" });
            kingdom.AddEdge(new Edge { FromVillageId = v2.Id, ToVillageId = v3.Id, Time = t, TimeType = "m" });

            // Set positions on three villages.
            // First one is at 0,0
            // Second one is X distance along the X axis
            // Third one is calculated from the other two, selecting the positive Y direction alternative (of two possibilities)
            Location pos3 = MathLogic.Bilaterate(x, u, t);
            v1.Position = new Location(0, 0);
            v2.Position = new Location(x, 0);
            v3.Position = new Location(x - pos3.X, pos3.Y);
            v1.Confidence = v2.Confidence = v3.Confidence = 30;
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FixVillageLocation
        ///</summary>
        [TestMethod()]
        public void FixVillageLocationTest()
        {
            //Kingdom target = kingdom; // get from the generic setup.

            //Village v4 = new Village { Name = "Sx", WorldId = 1 };
            //int v4Id = kingdom.AddVillage(v4);

            //Edge e1 = new Edge { FromVillageId = v1Id, ToVillageId = v4Id, Time = 71, TimeType = "m" };
            //Edge e2 = new Edge { FromVillageId = v2Id, ToVillageId = v4Id, Time = 124, TimeType = "m" };
            //Edge e3 = new Edge { FromVillageId = v3Id, ToVillageId = v4Id, Time = 128, TimeType = "m" };

            //kingdom.AddEdge(e1);
            //kingdom.AddEdge(e2);
            //kingdom.AddEdge(e3);
            //target.FixVillageLocation(v4Id);

            //v4 = kingdom.GetVillage(v4Id);

            //Assert.AreEqual(23.629, v4.Position.X, .01F);
            //Assert.AreEqual(-52.976, v4.Position.Y, .01F);

        }

        /// <summary>
        ///A test for IsConfidentVillage
        ///</summary>
        [TestMethod()]
        public void IsConfidentVillageTest()
        {
            Kingdom target = new Kingdom(1);
            Village v1 = new Village { Name = "ConfidentVillage" };
            v1.Confidence = 30;
            Village v2 = new Village { Name = "NonConfidentVillage" };
            v2.Confidence = 29;

            int v1Id = target.AddVillage(v1);
            int v2Id = target.AddVillage(v2);

            bool expectedv1 = true; 
            bool actualv1;
            actualv1 = target.IsConfidentVillage(v1Id);

            Assert.AreEqual(expectedv1, actualv1);

            bool expectedv2 = false;
            bool actualv2;
            actualv2 = target.IsConfidentVillage(v2Id);

            Assert.AreEqual(expectedv2, actualv2);
        }

        /// <summary>
        ///A test for DistanceBetweenVillageIds
        ///</summary>
        [TestMethod()]
        public void DistanceBetweenVillageIdsTest1()
        {
            Kingdom target = kingdom;
            int id1 = 2;
            int id2 = 3;
            double expected = 80F;
            double actual;
            actual = target.DistanceBetweenVillageIds(id1, id2);
            Assert.AreEqual(expected, actual, .01F);
        }
        [TestMethod()]
        public void DistanceBetweenVillageIdsTest2()
        {
            Kingdom target = kingdom;
            int id1 = 1;
            int id2 = 2;
            double expected = 128F;
            double actual;
            actual = target.DistanceBetweenVillageIds(id1, id2);
            Assert.AreEqual(expected, actual, .01F);
        }
        [TestMethod()]
        public void DistanceBetweenVillageIdsTest3()
        {
            Kingdom target = kingdom;
            int id1 = 1;
            int id2 = 3;
            double expected = 93F;
            double actual;
            actual = target.DistanceBetweenVillageIds(id1, id2);
            Assert.AreEqual(expected, actual, .01F);
        }
    }
}
