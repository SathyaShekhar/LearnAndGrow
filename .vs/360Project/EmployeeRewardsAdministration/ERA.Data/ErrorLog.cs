//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERA.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ErrorLog
    {
        public int ErrorID { get; set; }
        public string MethodName { get; set; }
        public string ErrorMessage { get; set; }
        public string Source { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public Nullable<System.DateTime> ErrorDateTime { get; set; }
    }
}
