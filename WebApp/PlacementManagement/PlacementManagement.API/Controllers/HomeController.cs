using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlacementManagement.API.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home Page of API which contains Documentation Link
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
    }
}
