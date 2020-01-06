using System;
using System.Collections.Generic;
namespace Employee.RESTful.API.Data
{
    public class EmployeeTask
    {
        public int EmployeeTaskId { get; set; }
        //public Employee Employee { get; set; }       
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int EmployeeId { get; set; }
    }
}