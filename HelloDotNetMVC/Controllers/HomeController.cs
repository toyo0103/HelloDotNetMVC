using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloDotNetMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string id)
        {
            ViewBag.Message = string.Concat("Your id is ", id);

            return View();
        }

        public ActionResult Contact(string name)
        {
            ViewBag.Message = string.Concat("My name is ",name);

            return View();
        }
    }
}