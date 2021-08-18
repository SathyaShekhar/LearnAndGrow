using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERA.Data.Services;
using ERA.Web.Models;

namespace ERA.Web.API
{
    [RoutePrefix("EmployeeDetailsAPI")]
    public class EmployeeDetailsAPIController : ApiController
    {
        EmployeeService empService;
        public EmployeeDetailsAPIController()
        {
        }

        [HttpGet]
        [Route("GetAllEmployeeDetails")]
        public IEnumerable<EmployeeViewModel> GetAllEmployeeDetails()
        {
            List<EmployeeViewModel> returnResult = new List<EmployeeViewModel>();
            using (empService = new EmployeeService())
            {
                var result = empService.GetAllEmployeeDetails();
                if (result != null && result.Any())
                {
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
                }
            }
            return returnResult;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public List<RoleViewModel> GetAllRoles()
        {
            using (empService = new EmployeeService())
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
                return returnResult;
            }
        }

        [HttpGet]
        [Route("GetAllLocations")]
        public IEnumerable<LocationViewModel> GetAllLocations()
        {
            using (empService = new EmployeeService())
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
                return returnResult;
            }
        }

        [HttpGet]
        [Route("{roleID}/GetRoleByID")]
        public string GetRoleByID(int roleID)
        {
            using (empService = new EmployeeService())
            {
                return empService.GetRoleByID(roleID);
            }

        }
        [HttpGet]
        [Route("{locationID}/GetLocationByID")]
        public string GetLocationByID(int locationID)
        {
            using (empService = new EmployeeService())
            {
                return empService.GetLocationByID(locationID);
            }

        }

    }
}
