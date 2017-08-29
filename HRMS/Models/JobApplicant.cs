using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class JobApplicant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Degree { get; set; }

        public string ResumeURL { get; set; }
        public ApplicationUser Contact { get; set; }
        public JobApplication JobApplication { get; set; }
        //Contract
        public string ExpectedSalary { get; set; }
        public string ProposedSalary { get; set; }
        public string Availability { get; set; }

        //Candidate Status
        public bool isRejected { get; set; }
        public string Summery { get; set; }
        //Enum
        public string Status { get; set; }

        //
        public ApplicationUser Responsible { get; set; }
        public int Appreciation { get; set; }
        public string Source { get; set; }
        public ApplicationUser ReferredBy { get; set; }
    }
}