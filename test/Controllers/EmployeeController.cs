using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Dtos;
using test.Entities;
using test.IRepositiry;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [ActionName("GetEmployeeList")]
        public List<EmployeeModel> GetEmployeeList()
        {
            return _employeeRepository.GetEmployeesList();

        }
        [HttpGet]
        [ActionName("GetDepartmentList")]
        public List<DepartmentDropdown> GetDepartmentList()
        {
            return _employeeRepository.GetDepartmentName();
        }
        [HttpGet("GetEmployeeById/{id}")]
       // [ActionName("GetEmployeeById")]
        //[ActionName("GetEmployeeById/{id}")]
        public EmployeeModel GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeListById(id);

        }

        [HttpPost]
        [ActionName("addEmployee")]

        public async Task<IActionResult> addEmployee(EmployeeModel employeees)
        {
            var result = await _employeeRepository.AddEmployee(employeees);
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel employees)
        {
            var result = await _employeeRepository.UpdateEmployee(employees);
            return Ok(result);
        }

        [HttpDelete("DeleteEmployee/{id}")]
       // [ActionName("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeRepository.DeleteEmployee(id);
            return Ok(result);
        }

    }
}
