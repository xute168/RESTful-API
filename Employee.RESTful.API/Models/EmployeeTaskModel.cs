using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.RESTful.API.Models
{
    public class EmployeeTaskModel
    {
        public int EmployeeTaskId { get; set; }  
        [Required]
        [StringLength(4000, MinimumLength = 10)]
        public string TaskName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
