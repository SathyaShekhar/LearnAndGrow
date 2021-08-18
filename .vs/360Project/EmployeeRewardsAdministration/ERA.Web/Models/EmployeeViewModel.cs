using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERA.Web.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public int LocationID { get; set; }
        public string Location { get; set; }
        public int RoleID { get; set; }
        public string EmployeeRole { get; set; }
        public int RewardPoints { get; set; }
        public bool IsActive { get; set; }
    }
}