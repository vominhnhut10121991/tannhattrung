using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThaiWood.Models;
using System.Data;

namespace ThaiWood.Controllers
{
    public class ProductController : ApplicationController
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            ViewData["Product"] = new ProductViewModel().Load(0);
            ViewData["Type"] = new TypeFromProductViewModel().Load(0);
            return View();
        }

        public ActionResult Category(int id) 
        {
            ViewData["Product"] = new ProductFromCategoryViewModel().Load(id);
            ViewData["Type"] = new TypeFromProductViewModel().Load(0);
            return View("../Product/Index");
        }

        public ActionResult Brand(int id)
        {
            ViewData["Product"] = new ProductFromBrandViewModel().Load(id);
            ViewData["Type"] = new TypeFromProductViewModel().Load(0);
            return View("../Product/Index");
        }

        public ActionResult Detail(int id) 
        {
            ProductHelper.HelperIncreaseProductCount(id);
            ViewData["ProductDetail"] = new ProductFromProductIdViewModel().Load(id);
            return View();
        }

        public String Test1(int id) 
        {
            ProductFromProductIdViewModel pfpivm = new ProductFromProductIdViewModel();
            DataTable dt = pfpivm.Load(id).ds.Tables["ProductDetail"];
            string result = pfpivm.productCategory + " - " +pfpivm.productBrand + " - ";
            foreach(DataRow dr in dt.Rows)
            {
                result = result + dr[0];
            }
            return result;
        }

    }
}
