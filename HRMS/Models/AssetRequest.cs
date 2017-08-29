using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class AssetRequest
    {
        public int Id { get; set; }
        public Asset Asset { get; set; }
        //this will be enum
        public string Satus { get; set; }
        public DateTime ReqDate { get; set; }

        //this will be enum
        public string Priority { get; set; }
        // employee reference

        public ApplicationUser RequestedBy { get; set; }

        public ApplicationUser AproovalManagaer { get; set; }
    }
}