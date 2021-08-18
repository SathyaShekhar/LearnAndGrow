using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ERA.Web.Models;

namespace ERA.Web.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        public EmployeeDetailsController()
        {
        }

        // GET: EmployeeDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployee()
        {
            var model = new EmployeeViewModel();
            return PartialView(model);
        }

        [HttpGet]
        public JsonResult GetAllRoles()
        {
            List<RoleViewModel> returnResult = EmployeeUtils.GetAllRoles().ToList();
            return Json(returnResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetAllLocations()
        {
            List<LocationViewModel> returnResult =  EmployeeUtils.GetAllLocations().ToList();
            return Json(returnResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllEmployeeDetails(DataSourceRequest request, int selectedRoleID = 0, int selectedlocation = 0)
        {
            DataSourceResult retValue = null;
            List<EmployeeViewModel> returnResult = EmployeeUtils.GetAllEmployeeDetails(selectedRoleID, selectedlocation).ToList();
            retValue = returnResult.ToDataSourceResult(request);
            return Json(retValue, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateEmployee([DataSourceRequest] DataSourceRequest request, EmployeeViewModel addEmployee)
        {
            int result = -1;
            if (addEmployee != null && ModelState.IsValid)
            {
                result = EmployeeUtils.CreateEmployee(addEmployee);
            }
            return Json(new[] { result }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateEmployee([DataSourceRequest] DataSourceRequest request, EmployeeViewModel updateEmployee)
        {
            if (updateEmployee != null && ModelState.IsValid)
            {
                updateEmployee = EmployeeUtils.UpdateEmployee(updateEmployee);
            }

            return Json(new[] { updateEmployee }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteEmployee([DataSourceRequest] DataSourceRequest request, EmployeeViewModel deleteEmployee)
        {
            if (deleteEmployee != null)
            {
                deleteEmployee = EmployeeUtils.UpdateEmployee(deleteEmployee);
            }

            return Json(new[] { deleteEmployee }.ToDataSourceResult(request, ModelState));
        }
    }
}