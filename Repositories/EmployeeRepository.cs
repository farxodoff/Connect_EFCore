using System;
using System.Collections.Generic;
using System.Text;
using Connect_EFCore.Data;
using Connect_EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connect_EFCore.Repositories
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository()
        {
            _context = new AppDbContext();
        }
        // insert into
        public void AddEmployee(string fullName, decimal salary, int departmentId, int roleId)
        {
            var employee = new Employee
            {
                FullName = fullName,
                Salary = salary,
                DepartmentId = departmentId,
                RoleId = roleId
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }


        public List<Employee> GetAllEmployees()
        {
            return _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .ToList();
        }


        public List<Employee> GetByDepartmentId(int departmentId)
        {
            return _context.Employees
                .Where(e => e.DepartmentId == departmentId)
                .ToList();
        }

        public List<Employee> GetByRoleId(int roleId)
        {
            return _context.Employees
                .Where(e => e.RoleId == roleId)
                .ToList();
        }
    }
}
