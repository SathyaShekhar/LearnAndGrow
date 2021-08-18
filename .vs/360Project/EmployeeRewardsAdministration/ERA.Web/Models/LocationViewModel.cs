using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERA.Web.Models
{
    public class LocationViewModel
    {
        public int LocationID { get; set; }
        public string LocationDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}