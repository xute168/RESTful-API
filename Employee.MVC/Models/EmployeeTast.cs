using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.MVC.Models
{
    public class EmployeeTast
    {
        public int EmployeeTaskId { get; set; }    
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int EmployeeId { get; set; }
    }
}