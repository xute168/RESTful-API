
using System;
using System.Collections.Generic;

namespace Employee.RESTful.API.Data
{
  public class Employee
  {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; } = DateTime.MinValue;
        public ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}