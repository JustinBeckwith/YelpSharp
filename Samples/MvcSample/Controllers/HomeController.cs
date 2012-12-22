using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

using MvcSample.Models;

using YelpSharp;
using YelpSharp.Data;

namespace MvcSample.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        //--------------------------------------------------------------------------
        //
        //	Action Methods
        //
        //--------------------------------------------------------------------------

        #region Index
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
        #endregion


        #region Results
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Results(SimpleSearchModel model)
        {
            Yelp yelp = new Yelp(Config.Options);
            var results = yelp.Search(model.Term, model.Location).Result;
            return View(results);
        }

        #endregion

        #region About
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }
        #endregion


        
    }
}
