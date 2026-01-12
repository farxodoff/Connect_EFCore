using System;
using Connect_EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connect_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
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

            /*var random = new Random();

            var employees = Enumerable.Range(1, 20)
                .Select(i => new Employee
                {
                    FullName = $"Employee {i}",
                    Salary = random.Next(2000, 8000),
                    DepartmentId = Departments[random.Next(departments.Count)].Id,
                    RoleId = Roles[random.Next(roles.Count)].Id
                })
                .ToList();

            context.Employees.AddRange(employees);
            context.SaveChanges();*/



        }
    }
}