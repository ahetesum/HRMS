using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfJoining { get; set; }

        public string SystemId { get; set; }
        public string DeskLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficePhone { get; set; }

  
        public ApplicationUser Line1Manager { get; set; }
        public ApplicationUser Line2Manager { get; set; }
        public ApplicationUser HRManager { get; set; }

        public Position Designation { get; set; }

        public Department Department { get; set; }

        public Organization Organization { get; set; }
        public Address CurrentAddress { get; set; }
        public ApplicationUser User { get; set; }


    }
}