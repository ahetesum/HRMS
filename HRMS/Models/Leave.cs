using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Leave
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Comment> Comments { get; set; }
        //employee reference
        public ApplicationUser RequestedBy { get; set; }

        public ApplicationUser AproovalManagaer { get; set; }

        public ApplicationUser AproovalHR { get; set; }


    }
}