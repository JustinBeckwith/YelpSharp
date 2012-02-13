using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 
        /// </summary>
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
            var o = GetOptions();
			var y = new Yelp(o);
			var results = y.Search("coffee", "seattle");
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
            var o = GetOptions();
            var y = new Yelp(o);
            
            var searchOptions = new SearchOptions();
            searchOptions.GeneralOptions = new GeneralOptions()
            {
                term = "coffee"
            };

            searchOptions.LocationOptions = new LocationOptions()
            {
                location="seattle"
            };


            var results = y.Search(searchOptions);
            Console.WriteLine(results);
        }
        #endregion

        #region GetOptions
        /// <summary>
        /// return the oauth options in this case from app.config
        /// </summary>
        /// <returns></returns>
        protected Options GetOptions()
        {
            return new Options()
            {
                AccessToken = ConfigurationManager.AppSettings["AccessToken"],
                AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"],
                ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"],
                ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"]
            };
        }
        #endregion
    }
}
