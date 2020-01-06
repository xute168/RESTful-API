using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee.MVC.Models
{
    public class Employee
    { 
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; } = DateTime.MinValue;
        public ICollection<EmployeeTast> EmployeeTasks { get; set; }
    }
}