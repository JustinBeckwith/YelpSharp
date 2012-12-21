using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YelpSharp;

namespace MvcSample.Controllers
{
    public class BusinessController : Controller
    {
        //
        // GET: /Business/

        public ActionResult Details(string id)
        {
            Yelp y = new Yelp(MvcApplication.Options);
            var result = y.GetBusiness(id);
            return View(result);
        }

    }
}
