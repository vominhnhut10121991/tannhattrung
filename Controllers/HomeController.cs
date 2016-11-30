using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using ThaiWood.Models;

namespace ThaiWood.Controllers
{
    public class HomeController : ApplicationController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData["Product"] = new ProductViewModel().Load(0);
            return View();
        }

        public ActionResult ContactUs() 
        {
            return View();
        }

        public ActionResult AboutUs() 
        {
            return View();
        }

        public ActionResult Error() 
        {
            return View();
        }

        public ActionResult ChangeCulture(string lang, string returnUrl) 
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

    }
}
