using System;
using System.Threading.Channels;
using Connect_EFCore.Data;
using Connect_EFCore.Entities;
using Connect_EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Connect_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<int> numbers = new List<int> { 1,2,3,7,4,5,6,8,9};

            var evenNumber = numbers.Where(n => n%2==0);
            foreach(int n in evenNumber)
            {
                Console.Write(n);
            }
            Console.WriteLine();
            var max = numbers.Max();
            Console.WriteLine("Max = " + max);

            Console.WriteLine("--------");

            var doubled = numbers.Select(n => n*2);

            foreach (int n in doubled)
            {
                Console.Write(n); 
            }
            Console.WriteLine();
            Console.WriteLine("--------");

            var check = numbers.Any(n => n>5);
            Console.WriteLine(check);
            Console.WriteLine();
            Console.WriteLine();

            //var departments = context.Departments.ToList();
            //var roles = context.Roles.ToList();

            
            var employee = new EmployeeRepository();


            employee.GetAllEmployees()
                .ToList()
                .ForEach(e =>
                Console.WriteLine($"{e.Id}. {e.FullName} | {e.Salary}")
            );


            Console.WriteLine("-----------");

            employee.GetByDepartmentId(2)
                .Select(e => $"{e.Id}. {e.FullName} - {e.Salary}  - {e.DepartmentId}")
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("-----------");

            employee.GetByRoleId(4)
                .Select(e => $"{e.Id}. {e.FullName} - {e.Salary}  - {e.RoleId}")
                .ToList()
                .ForEach(Console.WriteLine);
            */

            using var context = new AppDbContext();
            var result = context.Employees
                .Select(e => new
                {
                    e.Id,
                    e.FullName,
                    e.Salary,
                    DepartmentName = e.Department.Name,
                    RoleName = e.Role.Name
                })
                .ToList();
            foreach ( var e in result )
            {
                Console.WriteLine( $"{e.Id}.{e.FullName}\t{e.Salary}\t{e.DepartmentName}\t{e.RoleName}" );
            }


        }
    }
}