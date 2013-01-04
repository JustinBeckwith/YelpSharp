using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using YelpSharp;
using YelpSharp.Data.Options;

namespace YelpSharpTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class YelpTest
    {
        //--------------------------------------------------------------------------
        //
        //	Variables
        //
        //--------------------------------------------------------------------------

        #region Variables

        private TestContext testContextInstance;

        #endregion

        //--------------------------------------------------------------------------
        //
        //	Properties
        //
        //--------------------------------------------------------------------------

        #region Properties

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

        #endregion

        //--------------------------------------------------------------------------
        //
        //	Constructors
        //
        //--------------------------------------------------------------------------

        #region Constructors

        public YelpTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

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

        #region BasicTest
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            var y = new Yelp(Config.Options);
            var results = y.Search("coffee", "seattle, wa").Result;
            if (results.error != null)
            {
                Assert.Fail(results.error.text);
            }
            Console.WriteLine(results);
        }
        #endregion

        #region AdvancedTest
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void AdvancedTest()
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
        /// Verify URL escaped characters do not cause search to fail
        /// </summary>
        [TestMethod]
        public void UrlEscapedCharacters()
        {
            var y = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();
            searchOptions.GeneralOptions = new GeneralOptions()
            {
                term = "coffee $&`:<>[]{}\"#%@/;=?\\^|~', tea"
                //term = "coffee $`:<>[]{}\"#%@/;=?\\^|~', tea"
            };

            searchOptions.LocationOptions = new LocationOptions()
            {
                location = "seattle"
            };


            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses != null);
            Assert.IsTrue(results.businesses.Count > 0);
            Console.WriteLine(results);
        }
        #endregion

        #region BusinessTest
        /// <summary>
        /// test loading a business explicitely by name
        /// </summary>
        [TestMethod]
        public void BusinessTest()
        {
            var y = new Yelp(Config.Options);
            var results = y.GetBusiness("yelp-san-francisco").Result;
            Assert.IsTrue(results != null);
        }
        #endregion

        #region LocationWithCoordinates
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
        #endregion

        #region LocationByCoordinates
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
        #endregion

        #region LocationByBounds
        /// <summary>
        /// check using bounds location options
        /// </summary>
        [TestMethod]
        public void LocationByBounds()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharp.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() { radius_filter = 5 },
                LocationOptions = new CoordinateOptions()
                {
                    latitude = 37.788022,
                    longitude = -122.399797
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses.Count > 0);
        }
        #endregion

        #region LocationWithRadius
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
        #endregion

        #region MultipleCategories
        /// <summary>
        /// perform a search with multiple categories on the general options filter
        /// </summary>
        [TestMethod]
        public void MultipleCategories()
        {
            var yelp = new Yelp(Config.Options);
            var searchOptions = new YelpSharp.Data.Options.SearchOptions()
            {
                GeneralOptions = new GeneralOptions() { category_filter = "climbing,bowling" },
                LocationOptions = new LocationOptions()
                {
                    location = "Seattle"
                }
            };
            var results = yelp.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses.Count > 0);
        }
        #endregion

        #region ErrorTests       

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
        #endregion       
    }
}
