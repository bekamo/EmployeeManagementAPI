using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PersonalId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime? DateReleased { get; set; }
        public string PhoneNumber { get; set; }
    }
}
