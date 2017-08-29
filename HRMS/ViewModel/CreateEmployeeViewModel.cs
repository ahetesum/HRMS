using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.ViewModel
{
    public class CreateEmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string SystemId { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficePhone { get; set; }
        public int DesignationId { get; set; }
        public IEnumerable<Position> AvailableDesignation { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<Department> AvailableDepartment { get; set; }
        public int Line1ManagerId { get; set; }
        public int Line2ManagerId { get; set; }
        public IEnumerable<Employee> AvailableManagers { get; set; }
        public int HRManagerId { get; set; }

        public IEnumerable<Employee> AvailableHRs { get; set; }
        public int OrganizationId { get; set; }

    }
}