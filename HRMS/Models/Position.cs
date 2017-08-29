using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
     }
}