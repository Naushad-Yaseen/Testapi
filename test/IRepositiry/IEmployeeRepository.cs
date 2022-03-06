using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Dtos;
using test.Entities;
using test.Models;

namespace test.IRepositiry
{
    public interface IEmployeeRepository
    {
        public List<EmployeeModel> GetEmployeesList();
        public EmployeeModel GetEmployeeListById(int id);
        public Task<int> AddEmployee(EmployeeModel employees);
        public Task<int> UpdateEmployee(EmployeeModel employees);
        public Task<bool> DeleteEmployee(int id);
        public List<DepartmentDropdown> GetDepartmentName();
    }
}

