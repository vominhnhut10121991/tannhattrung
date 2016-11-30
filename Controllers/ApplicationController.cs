using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThaiWood.Models;

namespace ThaiWood.Controllers
{
    public class ApplicationController : Controller
    {

        public ApplicationController() 
        {
            ViewData["Master"] = new MasterViewModel().Load(0);
        }

    }
}
