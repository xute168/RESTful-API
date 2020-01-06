using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.RESTful.API.Models
{
    public class CreateOrEditEmployeeTaskModel
    {
        public int EmployeeTaskId { get; set; }
        [Required]
        [StringLength(4000, MinimumLength = 10)]
        public string TaskName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }

        public int EmployeeId { get; set; }
        //public Employee.RESTful.API.Data.Employee Employee { get; set; }
    }
}
