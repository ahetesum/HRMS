using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public IEnumerable<VoteAnswer> VoteAnswers { get; set; }
        public VoteAnswer VoteAnswer { get; set; }

   
    }
}