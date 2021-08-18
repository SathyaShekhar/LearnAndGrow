using ERA.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERA.Web.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeDetails dbContext;

        public HomeController()
        {

            dbContext = new EmployeeService();
        }
        public ActionResult Index()
        {
            var model = dbContext.GetAllEmployeeDetails();
            return View(model);
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