using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERA.Web.Models;

namespace ERA.Web.API
{
    [RoutePrefix("EmployeeDetailsAPI")]
    public class EmployeeDetailsAPIController : ApiController
    {
        public EmployeeDetailsAPIController()
        {
        }

        [HttpGet]
        [Route("GetAllEmployeeDetails")]
        public IEnumerable<EmployeeViewModel> GetAllEmployeeDetails()
        {
            return EmployeeUtils.GetAllEmployeeDetails();
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public IEnumerable<RoleViewModel> GetAllRoles()
        {
            return EmployeeUtils.GetAllRoles();
        }

        [HttpGet]
        [Route("GetAllLocations")]
        public IEnumerable<LocationViewModel> GetAllLocations()
        {
            return EmployeeUtils.GetAllLocations();
        }

        [HttpGet]
        [Route("{roleID}/GetRoleByID")]
        public string GetRoleByID(int roleID)
        {
            return EmployeeUtils.GetRoleByID(roleID);

        }
        [HttpGet]
        [Route("{locationID}/GetLocationByID")]
        public string GetLocationByID(int locationID)
        {
            return EmployeeUtils.GetLocationByID(locationID);

        }

    }
}
