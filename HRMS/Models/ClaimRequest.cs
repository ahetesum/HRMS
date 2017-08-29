using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class ClaimRequest
    {
        public int Id { get; set; }

        public Claim Claim { get; set; }

        //this will be enum
        public string Satus { get; set; }
        public DateTime ClaimDate { get; set; }

        //this will be enum
        public string Priority { get; set; }
        // employee reference

        public ApplicationUser RequestedBy { get; set; }

        public ApplicationUser AproovalManagaer { get; set; }




    }
}