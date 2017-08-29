using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class SalaryStack
    {
        public int Id { get; set; }
        public string BasicPay { get; set; }
        public string HomeAllowence { get; set; }
        public string TravelAllowence { get; set; }
        public string VariablePay { get; set; }
        public string BenifitPlan { get; set; }
        public string ProvidentFund { get; set; }
        public string Gratuty { get; set; }
        public string HealthBenifit { get; set; }
    }
}