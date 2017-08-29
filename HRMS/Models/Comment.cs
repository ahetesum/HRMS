using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public ApplicationUser CommentedBy { get; set; }
    }
}