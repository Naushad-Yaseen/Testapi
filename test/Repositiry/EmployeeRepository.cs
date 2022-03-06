using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.DBContext;
using test.Dtos;
using test.Entities;
using test.IRepositiry;
using test.Models;

namespace test.Repositiry
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        //private readonly IMapper _mapper;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
           // _mapper = mapper;
        }

        public async Task<int> AddEmployee(EmployeeModel employees)
        {
            int response = 0;
            try
            {
                var employee = new Employee
                {
                    EmployeeId = employees.EmployeeId,

                    DepartmentId = employees.DepartmentId,
                    FullName = employees.FullName,
                    Age = employees.Age,
                    DateOfBirth = employees.DateOfBirth,
                    DateOfJoining=employees.DateOfJoining,
                    // DateOfJoining = DateTime.UtcNow,



                };
                _context.Employees.Add(employee);

                response =await _context.SaveChangesAsync();
              
            }
            catch (Exception ex)
            {

                throw;
            }
            return response;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            bool response = false;
            try
            {
                if (id == 0) throw new ArgumentNullException("entity");

                Employee entity = await _context.Employees.SingleOrDefaultAsync(s => s.EmployeeId == id);
                _context.Remove(entity);
                 await _context.SaveChangesAsync();
             
                response = true;
            }
            catch (Exception ex)
            {
                
            }

            return response;
        }

       

        public  EmployeeModel GetEmployeeListById(int id)
        {
            EmployeeModel EmployeeModel = null;

            try
            {
                 EmployeeModel = (from a in _context.Employees.Where(x => x.EmployeeId==id)
                                  join b in _context.Departments on a.DepartmentId equals b.DepartmentId
                                  select new EmployeeModel()
                {
                    EmployeeId = a.EmployeeId,
                    DepartmentId=b.DepartmentId,
                    DepartmentName = b.DepartmentName,
                    FullName=a.FullName,
                    Age=a.Age,
                    DateOfBirth=a.DateOfBirth,
                    DateOfJoining=a.DateOfJoining,
                    

                }).FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
            return EmployeeModel;
        }

        public   List<EmployeeModel> GetEmployeesList()
        {
            List<EmployeeModel> EmployeeModel = null;

            try
            {
                EmployeeModel = (from a in _context.Employees
                                 join b in _context.Departments on a.DepartmentId equals b.DepartmentId
                                 select new EmployeeModel()
                                 {
                                     EmployeeId = a.EmployeeId,
                                     DepartmentName = b.DepartmentName,
                                     FullName = a.FullName,
                                     Age = a.Age,
                                     DateOfBirth = a.DateOfBirth,
                                     DateOfJoining = a.DateOfJoining,


                                 }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return EmployeeModel;

           // return await _context.Employees.ToListAsync();
        }

        public async Task<int> UpdateEmployee(EmployeeModel employees)
        {
            int response = 0;
            try
            {

                if (employees.EmployeeId != 0)
                {

                    var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employees.EmployeeId);
                    if (employee != null)
                    {
                        employee.EmployeeId = employees.EmployeeId;
                        employee.DepartmentId = employees.DepartmentId;
                        employee.FullName = employees.FullName;
                        employee.Age = employees.Age;
                        employee.DateOfBirth = DateTime.UtcNow;
                       
                        employee.DateOfJoining = DateTime.UtcNow;
                       response= await _context.SaveChangesAsync();
                      
                    }
        
                }
             

            }
            catch (Exception ex)
            {
               
            }
            return response;
        }

        public List<DepartmentDropdown> GetDepartmentName()
        {
            List<DepartmentDropdown> department = null;
            try
            {
                department = _context.Departments
                    .Select(z => new DepartmentDropdown
                    {
                        DepartmentId = z.DepartmentId,
                        DepartmentName = z.DepartmentName

                    }).ToList();
             
            }
            catch (Exception ex)
            {
                throw;
            }
            return department;
        }

        
    }
    }

