using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERA.Data.Services;
using ERA.Data;
using ERA.Web.Models;

namespace ERA.Web
{
    public static class EmployeeUtils
    {
        public static IEnumerable<RoleViewModel> GetAllRoles()
        {
            List<RoleViewModel> returnResult = new List<RoleViewModel>();

            using (var empService = new EmployeeService())
            {
                var roleDetails = empService.GetAllRoles();

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
            }

            return returnResult;
        }
        public static IEnumerable<EmployeeViewModel> GetAllEmployeeDetails(int selectedRoleID = 0, int selectedlocation = 0)
        {
            List<EmployeeViewModel> returnResult = new List<EmployeeViewModel>();
            using (var empService = new EmployeeService())
            {
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
                }
            }
            return returnResult;
        }
        public static IEnumerable<LocationViewModel> GetAllLocations()
        {

            List<LocationViewModel> returnResult = new List<LocationViewModel>();

            using (var empService = new EmployeeService())
            {
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
            }

            return returnResult;
        }

        public static EmployeeViewModel UpdateEmployee(EmployeeViewModel updateEmployee)
        {

            if (updateEmployee != null)
            {
                using (var empService = new EmployeeService())
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
            }
            return updateEmployee;
        }

        public static EmployeeViewModel DeleteEmployee(EmployeeViewModel deleteEmployee)
        {
            if (deleteEmployee != null)
            {
                using (var empService = new EmployeeService())
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
            }

            return deleteEmployee;
        }
        public static int CreateEmployee(EmployeeViewModel addEmployee)
        {
            int result = -1;
            if (addEmployee != null)
            {
                using (var empService = new EmployeeService())
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
                    result = empService.UpdateEmployee(addEmp);
                }
            }

            return result;
        }

        public static string GetLocationByID(int locationID)
        {
            using (var empService = new EmployeeService())
            {
                return empService.GetLocationByID(locationID);
            }

        }

        public static string GetRoleByID(int roleID)
        {
            using (var empService = new EmployeeService())
            {
                return empService.GetRoleByID(roleID);
            }

        }
    }
}