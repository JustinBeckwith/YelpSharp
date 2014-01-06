using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using YelpSharp;
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

        public LocationTests()
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
        /// Test search with location and search term
        /// </summary>
        [TestMethod]
        public void LocationBasic()
        {
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();
            searchOptions.GeneralOptions = new GeneralOptions()
            {
                term = "coffee"
            };

            searchOptions.LocationOptions = new LocationOptions()
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

            var searchOptions = new YelpSharp.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() { term = "food" },
                LocationOptions = new LocationOptions()
                {
                    location = "bellevue",
                    coordinates = new CoordinateOptions()
                    {
                        latitude = 37.788022,
                        longitude = -122.399797
                    }
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
            var searchOptions = new YelpSharp.Data.Options.SearchOptions()
            {
                LocationOptions = new BoundOptions()
                {
                    sw_latitude = 37.9,
                    sw_longitude = -122.5,
                    ne_latitude = 37.788022,
                    ne_longitude = -122.399797
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses.Count > 0);
        }

        /// <summary>
        /// check using bounds location options
        /// </summary>
        [TestMethod]
        public void LocationByBounds()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharp.Data.Options.SearchOptions()
            {
                LocationOptions = new CoordinateOptions()
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
            var searchOptions = new YelpSharp.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() {
                    radius_filter = 3000
                },
                LocationOptions = new CoordinateOptions()
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
            var searchOptions = new YelpSharp.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() { term = "food", radius_filter = 5 },
                LocationOptions = new LocationOptions()
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
                Assert.Fail(results.error.text);
            }
            var bus = results.businesses[0];
            if (bus.location.coordinate == null)
                Assert.Fail("No coordinate found on location for business");

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
