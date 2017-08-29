using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //ceo cto manager finace
        public string Designation { get; set; }



        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }

        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }


    }
}