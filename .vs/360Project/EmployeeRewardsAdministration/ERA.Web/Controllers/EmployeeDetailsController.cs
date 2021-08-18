using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERA.Data.Services;
using ERA.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ERA.Web.Models;

namespace ERA.Web.Controllers
{
    public class EmployeeDetailsController : Controller
    {

        EmployeeService empService;
        public EmployeeDetailsController()
        {
            empService = new EmployeeService();
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
            var roleDetails = empService.GetAllRoles();
            List<RoleViewModel> returnResult = new List<RoleViewModel>();

            if (roleDetails != null && roleDetails.Any())
            {
                foreach (var item in roleDetails)
                {
                    RoleViewModel rvm = new RoleViewModel()
                    {
                        RoleDescription = item.RoleDescription,
                        RoleID = item.RoleID,
                        IsActive = item.IsActive
                    };
                    returnResult.Add(rvm);
                    rvm = null;
                }
            }
            return Json(returnResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetAllLocations()
        {

            List<LocationViewModel> returnResult = new List<LocationViewModel>();
            var locationDetails = empService.GetAllLocations();

            if (locationDetails != null && locationDetails.Any())
            {
                foreach (var item in locationDetails)
                {
                    LocationViewModel lvm = new LocationViewModel()
                    {
                        LocationDescription = item.LocationDescription,
                        LocationID = item.LocationID,
                        IsActive = item.IsActive
                    };
                    returnResult.Add(lvm);
                    lvm = null;
                }

            }
            return Json(returnResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllEmployeeDetails(DataSourceRequest request, int selectedRoleID = 0, int selectedlocation = 0)
        {
            DataSourceResult retValue = null;
            List<EmployeeViewModel> returnResult = new List<EmployeeViewModel>();

            var result = empService.GetAllEmployeeDetails();

            if (result != null && result.Any())
            {
                if (selectedRoleID > 0)
                    result = result.Where(s => s.RoleID == selectedRoleID).ToList();
                if (selectedlocation > 0)
                    result = result.Where(s => s.LocationID == selectedlocation).ToList();

                result = result.Where(s => s.IsActive == true).ToList();


                foreach (var item in result)
                {
                    EmployeeViewModel emp = new EmployeeViewModel()
                    {
                        EmployeeID = item.EmployeeID,
                        Email = item.Email,
                        EmployeeName = item.EmployeeName,                       
                        RoleID = item.RoleID.Value,
                        EmployeeRole = empService.GetRoleByID(item.RoleID.Value),
                        LocationID = item.LocationID.Value,
                        Location = empService.GetLocationByID(item.LocationID.Value),
                        RewardPoints = item.RewardPoints.Value
                    };

                    returnResult.Add(emp);
                    emp = null;
                }

                retValue = returnResult.ToDataSourceResult(request);
            }
            return Json(retValue, JsonRequestBehavior.AllowGet);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateEmployee([DataSourceRequest] DataSourceRequest request, EmployeeViewModel addEmployee)
        {
            int result = -1;
            if (addEmployee != null && ModelState.IsValid)
            {
                var addEmp = new Employee()
                {
                    Email = addEmployee.Email,
                    EmployeeName = addEmployee.EmployeeName,
                    LocationID = addEmployee.LocationID,
                    RoleID = addEmployee.RoleID,
                    RewardPoints = 0,
                    IsActive = true
                };
              result=  empService.UpdateEmployee(addEmp);
            }

            return Json(new[] { result }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateEmployee([DataSourceRequest] DataSourceRequest request, EmployeeViewModel updateEmployee)
        {
            if (updateEmployee != null && ModelState.IsValid)
            {
                var updateEmp = new Employee()
                {
                    Email = updateEmployee.Email,
                    EmployeeID = updateEmployee.EmployeeID,
                    EmployeeName = updateEmployee.EmployeeName,
                    LocationID = updateEmployee.LocationID,
                    RoleID = updateEmployee.RoleID,
                    RewardPoints = updateEmployee.RewardPoints,
                    IsActive = true
                };
                empService.UpdateEmployee(updateEmp);
            }

            return Json(new[] { updateEmployee }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteEmployee([DataSourceRequest] DataSourceRequest request, EmployeeViewModel deleteEmployee)
        {
            if (deleteEmployee != null)
            {
                var delEmp = new Employee()
                {
                    Email = deleteEmployee.Email,
                    EmployeeID = deleteEmployee.EmployeeID,
                    EmployeeName = deleteEmployee.EmployeeName,
                    LocationID = deleteEmployee.LocationID,
                    RoleID = deleteEmployee.RoleID,
                    RewardPoints = deleteEmployee.RewardPoints,
                    IsActive = false
                };
                empService.UpdateEmployee(delEmp);
            }

            return Json(new[] { deleteEmployee }.ToDataSourceResult(request, ModelState));
        }
            }
}