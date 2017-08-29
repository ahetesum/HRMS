using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public Department Department { get; set; }
        public List<JobApplicant> Applicants { get; set; }
        public List<Tag> Tags { get; set; }
    }
}