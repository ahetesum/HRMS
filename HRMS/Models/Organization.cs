using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string RegistrationNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
    }
}