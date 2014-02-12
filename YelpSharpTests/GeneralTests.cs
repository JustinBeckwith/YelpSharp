using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using YelpSharp;
using YelpSharp.Data.Options;

namespace YelpSharpTests
{
    /// <summary>
    /// General tests for the API.
    /// </summary>
    [TestClass]
    public class GeneralTests
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

        public GeneralTests()
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
        /// Basic search test to verify the API.
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
        
        /// <summary>
        /// Test search with location and search term
        /// </summary>
        [TestMethod]
        public void VerifyGeneralOptions()
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

        /// <summary>
        /// Verify URL escaped characters do not cause search to fail
        /// </summary>
        [TestMethod]
        public void VerifyTermWithEscapedCharacter()
        {
            var y = new Yelp(Config.Options);
            var searchOptions = new SearchOptions
            {
                GeneralOptions = new GeneralOptions
                {
                    term = "Frimark Keller & Associates"
                },
                LocationOptions = new LocationOptions
                {
                    location = "60173"
                }
            };

            var results = y.Search(searchOptions).Result;
            Assert.IsTrue(results.businesses != null);
            Assert.IsTrue(results.businesses.Count > 0);           
        }
        
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

		/// <summary>
		/// test that reviews are returned
		/// </summary>
		[TestMethod]
		public void BusinessReviewTest()
		{
			var y = new Yelp(Config.Options);
			var results = y.GetBusiness("yelp-san-francisco").Result;
			Assert.IsTrue(results != null);

			Assert.IsNotNull(results.reviews);
			Assert.AreNotEqual(0, results.review_count);

			Assert.AreNotEqual(0, results.reviews.Count);

			var firstReview = results.reviews[0];
			Assert.IsNotNull(firstReview.rating_image_url);
			Assert.IsNotNull(firstReview.rating_image_small_url);
			Assert.IsNotNull(firstReview.rating_image_large_url);
		}

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

        /// <summary>
        /// Verify the limit parameter works as expected.
        /// </summary>
        [TestMethod]
        public void LimitTest()
        {
            var y = new Yelp(Config.Options);
            var searchOptions = new SearchOptions()
            {
                GeneralOptions = new GeneralOptions()
                {
                    term = "coffee",
                    limit = 15,
                },
                LocationOptions = new LocationOptions()
                {
                    location = "seattle, wa"
                }
            };
            var results = y.Search(searchOptions).Result;
            if (results.error != null)
            {
                Assert.Fail(results.error.text);
            }
            if (results.businesses.Count != 15)
            {
                Assert.Fail(string.Format("Limit test returned {0} results instead of 15", results.businesses.Count));
            }

            Console.WriteLine(results);
        }
               
    }
}
