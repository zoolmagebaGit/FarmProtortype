using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmProtortype.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HomePageView()
        {
            return View();
        }
        public ActionResult AboutView()
        {
            return View();
        }
        public ActionResult AdminDashNew()
        {

            return View();
        }
        public ActionResult ContactView()
        {

            return View();
        }
        public ActionResult AdminDash()
        {

            return View();
        }


    }
}