using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Areas.ProductAdmin.Controllers
{
    public class IndexController : Controller
    {
        // GET: ProductAdmin/Index
        public ActionResult Index()
        {
            return Content("Hello World");

        }
    }
}