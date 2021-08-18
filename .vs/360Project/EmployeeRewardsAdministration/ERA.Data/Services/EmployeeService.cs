using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ERA.Data;
using System.Reflection;

namespace ERA.Data.Services
{
    public class EmployeeService : IEmployeeDetails
    {
        List<Employee> empDetails;
        List<Role> roleDetails;
        List<Location> locationDetails;
        ERAEntities eraDBContext;
        bool disposed = false;

        public EmployeeService()
        {

        }

        public IEnumerable<Employee> GetAllEmployeeDetails()
        {
            try
            {
                using (eraDBContext = new ERAEntities())
                {
                    empDetails = eraDBContext.Employees.Where(e => e.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
               InsertError(ex, String.Format("{0}, {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                throw;
            }
            return empDetails;
        }
        public IEnumerable<Role> GetAllRoles()
        {
            try
            {
                using (eraDBContext = new ERAEntities())
                {
                    roleDetails = eraDBContext.Roles.Where(e => e.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                InsertError(ex, String.Format("{0}, {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                throw;
            }
            return roleDetails;
        }
        public IEnumerable<Location> GetAllLocations()
        {
            try
            {
                using (eraDBContext = new ERAEntities())
                {
                    locationDetails = eraDBContext.Locations.Where(e => e.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                InsertError(ex, String.Format("{0}, {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                throw;
            }
            return locationDetails;
        }



        public string GetRoleByID(int roleID)
        {
            string result = string.Empty;
            try
            {
                using (eraDBContext = new ERAEntities())
                {
                    result = eraDBContext.Roles.Where(e => e.IsActive == true && e.RoleID == roleID)
                                               .Select(s => s.RoleDescription).First();
                }
            }
            catch (Exception ex)
            {
                InsertError(ex, String.Format("{0}, {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                throw;
            }
            return result;
        }
        public string GetLocationByID(int locationID)
        {
            string result = string.Empty;
            try
            {
                using (eraDBContext = new ERAEntities())
                {
                    result = eraDBContext.Locations.Where(e => e.IsActive == true && e.LocationID == locationID)
                                               .Select(s => s.LocationDescription).First();
                }
            }
            catch (Exception ex)
            {
                InsertError(ex, String.Format("{0}, {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                throw;
            }
            return result;
        }

        public int UpdateEmployee(Employee modifiedEmployee)
        {
            int result = 0;
            try
            {
                if (modifiedEmployee != null)
                {
                    using (eraDBContext = new ERAEntities())
                    {
                        Employee existing = eraDBContext.Employees.Where(r => r.EmployeeID == modifiedEmployee.EmployeeID).FirstOrDefault();
                        if (existing == null)
                        {
                            eraDBContext.Employees.Add(modifiedEmployee);
                        }
                        else
                        {
                            eraDBContext.Entry(existing).CurrentValues.SetValues(modifiedEmployee);
                        }
                        result = eraDBContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
               InsertError(ex, String.Format("{0}, {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
                throw;
            }
            return result;
        }

       
        private int InsertError(Exception ex, string methodName)
        {
            int result = 0;
            try
            {
                if (ex != null)
                {
                    using (eraDBContext = new ERAEntities())
                    {
                        var errorData = new ErrorLog()
                        {
                            MethodName = methodName,
                            ErrorDateTime = DateTime.Now,
                            StackTrace = ex.StackTrace,
                            ErrorMessage=ex.Message,
                            Source=ex.Source,
                            InnerException= ex.InnerException == null ? null : ex.InnerException.ToString()                            
                        };

                        eraDBContext.ErrorLogs.Add(errorData);
                        result = eraDBContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                result = -1;
                throw;
            }
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;
        }
    }
}
