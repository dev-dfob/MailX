using MailX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MailX.Controllers
{
    public class HomeController : Controller
    {
        ProjectContext db = new ProjectContext();

        public ActionResult Index()
        {
            return View(db.Users);
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
    }
}