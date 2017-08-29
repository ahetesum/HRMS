using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Brand { get; set; }

        public Vendor Vendor { get; set; }
        
        //Asset manager person reference

    }
}