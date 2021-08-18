using ERA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace ERA.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index()
        {
            var model = new GreetingViewModel();
            model.DisplayHeaderMessage = ConfigurationManager.AppSettings["HeaderMessage"];
            model.DisplayMessage = ConfigurationManager.AppSettings["Message"];
            return View(model);
        }
    }
}