using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YelpSharp;
using YelpSharp.Data;
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
        /// Verify LOCATION_NOT_FOUND is returned in error.code
        /// </summary>
        [TestMethod]
        public void ErrorTest_LOCATION_NOT_FOUND()
        {
            var y = new Yelp(Config.Options);

            var results = y.Search("asbdgaosidugfnasdfn", "some fake place").Result;
            Assert.IsTrue(results.error != null);
            Assert.IsTrue(results.error.code == ErrorCode.LOCATION_NOT_FOUND.ToString());
            Console.WriteLine(results);
        }

        /// <summary>
        ///  Verify UNSPECIFIED_LOCATION is returned in error.code
        /// </summary>
        [TestMethod]
        public void ErrorTest_VALIDATION_ERROR()
        {            
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.error != null);
            Assert.IsTrue(results.error.code == ErrorCode.VALIDATION_ERROR.ToString());
            Console.WriteLine(results);
        }

        [TestMethod]
        public void ErrorTest_UNAVAILABLE_BUSINESS()
        {
            Yelp y = new Yelp(Config.Options);
            Business business = y.GetBusiness("foo-bar").Result;

            Assert.IsNull(business);
        }

        /// <summary>
        ///  Verify AREA_TOO_LARGE is returned in error.code
        /// </summary>
        [TestMethod]
        public void ErrorTest_AREA_TOO_LARGE()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new SearchOptions
            {
                GeneralOptions = new GeneralOptions { term = "food", radius = 999999999 },
                LocationOptions = new LocationOptions
                {
                    location = "bellevue"
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.error.code == ErrorCode.AREA_TOO_LARGE.ToString() || results.error.code == ErrorCode.VALIDATION_ERROR.ToString());
            Console.WriteLine(results);
        }
    }
}
