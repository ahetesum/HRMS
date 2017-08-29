using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfJoining { get; set; }

        public string SystemId { get; set; }

        public string PhoneNumber { get; set; }
        public string OfficePhone { get; set; }


        //enum
        public string Sex { get; set; }
        //enum
        public string MaterialStatus { get; set; }

        public string HusbandOrSpouse { get; set; }

        public DateTime DateOfBirth { get; set; }
        [Required]
        public string BloodGroup { get; set; }

        public string PlaceOfBirth { get; set; }
        public string AdharNumber { get; set; }
        [Required]
        public string Nationality { get; set; }
        public string MotherTounge { get; set; }
        public string PasspostNumber { get; set; }
        public string ImageURL { get; set; }

        public string Relagion { get; set; }

        public IEnumerable<FamilyPerson> FamilyPersons { get; set; }

        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }

        public Address PermanentAddress { get; set; }
    }
}