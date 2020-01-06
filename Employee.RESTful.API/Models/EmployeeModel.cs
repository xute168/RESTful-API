using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Employee.RESTful.API.Data;

namespace Employee.RESTful.API.Models
{
    public class EmployeeModel
    {
        
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime HireDate { get; set; } = DateTime.MinValue;
        public ICollection<EmployeeTaskModel> EmployeeTasks { get; set; }
    }
}
