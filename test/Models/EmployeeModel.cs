using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Entities;

namespace test.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }

    }
}
