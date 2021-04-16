using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Dtos
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public DateTime? DateReleased { get; set; }
        public string PhoneNumber { get; set; }
    }
}
