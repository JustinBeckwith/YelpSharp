using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;

namespace YelpSharpTests
{
    /// <summary>
    /// Tests focused on searching the API by location.
    /// </summary>
    [TestClass]
    public class LocationTests
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
        /// Test search with location and search term
        /// </summary>
        [TestMethod]
        public void LocationBasic()
        {
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();
            searchOptions.GeneralOptions = new GeneralOptions
            {
                term = "coffee"
            };

            searchOptions.LocationOptions = new LocationOptions
            {
                location = "seattle"
            };

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses != null);
            Assert.IsTrue(results.businesses.Count > 0);
        }

        /// <summary>
        /// check using location options with coordinates
        /// </summary>
        [TestMethod]
        public void LocationWithCoordinates()
        {
            var yelp = new Yelp(Config.Options);

            var searchOptions = new SearchOptions
            {
                GeneralOptions = new GeneralOptions { term = "food" },
                LocationOptions = new LocationOptions
                {
                    location = "bellevue"
                }
            };

            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses.Count > 0);
        }

        /// <summary>
        /// check using location options with coordinates
        /// </summary>
        [TestMethod]
        public void LocationByCoordinates()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new SearchOptions
            {
                LocationOptions = new LocationOptions
                {
                    latitude = 37.788022,
                    longitude = -122.399797
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses.Count > 0);
        }

        /// <summary>
        /// Verify searching by coordinates with a radius filter.
        /// </summary>
        [TestMethod]
        public void VerifyCoordinatesWithRadius()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new SearchOptions
            {
                GeneralOptions = new GeneralOptions
                {
                    radius = 3000
                },
                LocationOptions = new LocationOptions
                {
                    latitude = 47.603525,
                    longitude = -122.329580
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses.Count > 0);
        }

        /// <summary>
        /// check using location options with coordinates
        /// </summary>
        [TestMethod]
        public void LocationWithRadius()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new SearchOptions
            {
                GeneralOptions = new GeneralOptions { term = "food", radius = 8000 },
                LocationOptions = new LocationOptions
                {
                    location = "bellevue"
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses.Count > 0);
        }

        /// <summary>
        /// search for a business, and ensure the lat & long are available
        /// </summary>
        [TestMethod]
        public void VerifyLocationInResult()
        {
            var y = new Yelp(Config.Options);
            var results = y.Search("coffee", "seattle, wa").Result;
            if (results.error != null)
            {
                Assert.Fail(results.error.code);
            }
            var bus = results.businesses[0];
            if (bus.location.address1 == null)
                Assert.Fail("No coordinate found on location for business");

        }
    }
}
