using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERA.Data.Services
{
    public interface IEmployeeDetails : IDisposable
    {
        IEnumerable<Employee> GetAllEmployeeDetails();
        IEnumerable<Role> GetAllRoles();
        IEnumerable<Location> GetAllLocations();
        string GetLocationByID(int locationID);
        string GetRoleByID(int roleID);
    }
}
