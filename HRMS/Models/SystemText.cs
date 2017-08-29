using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class SystemText
    {
        public int SystemTextId { get; set; }
        public string Identifier { get; set; }
        public string TextEng { get; set; }
        public string TextOther { get; set; }
    }
}