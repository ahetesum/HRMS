using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Asset> Assets { get; set; }

        public ApplicationUser Owner { get; set; }
    }
}