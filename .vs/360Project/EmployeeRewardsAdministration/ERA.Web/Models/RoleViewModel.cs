using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERA.Web.Models
{
    public class RoleViewModel
    {
        public int RoleID { get; set; }
        public string RoleDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}