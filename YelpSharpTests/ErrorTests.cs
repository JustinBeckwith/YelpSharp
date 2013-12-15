using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using YelpSharp;
using YelpSharp.Data.Options;

namespace YelpSharpTests
{
    /// <summary>
    /// Tests focused on verifying errors.
    /// </summary>
    [TestClass]
    public class ErrorTests
    {
        //--------------------------------------------------------------------------
        //
        //	Variables
        //
        //--------------------------------------------------------------------------

        private TestContext testContextInstance;

        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

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

        //--------------------------------------------------------------------------
        //
        //	Constructors
        //
        //--------------------------------------------------------------------------

        public ErrorTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //--------------------------------------------------------------------------
        //
        //	Test Methods
        //
        //--------------------------------------------------------------------------

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

        /// <summary>
        /// Verify UNAVAILABLE_FOR_LOCATION is returned in error.id
        /// </summary>
        [TestMethod]
        public void ErrorTest_UNAVAILABLE_FOR_LOCATION()
        {
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions()
            {
                LocationOptions = new CoordinateOptions()
                {
                    latitude = 1,
                    longitude = 1
                }
            };

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.error != null);
            Assert.IsTrue(results.error.id == YelpSharp.Data.ErrorId.UNAVAILABLE_FOR_LOCATION);
            Console.WriteLine(results);
        }

        /// <summary>
        ///  Verify UNSPECIFIED_LOCATION is returned in error.id
        /// </summary>
        [TestMethod]
        public void ErrorTest_UNSPECIFIED_LOCATION()
        {            
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.error != null);
            Assert.IsTrue(results.error.id == YelpSharp.Data.ErrorId.UNSPECIFIED_LOCATION);
            Console.WriteLine(results);
        }    

    }
}
