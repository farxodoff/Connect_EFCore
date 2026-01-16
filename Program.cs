using System;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
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
            // Select and Where
            var result = context.Employees
                .Select(e => new
                {
                    e.Id,
                    e.FullName,
                    e.Salary,
                    DepartmentName = e.Department.Name,
                    RoleName = e.Role.Name
                })
                //.Where(w => w.Salary > 3500)
                .ToList();
            
            /*foreach ( var e in result )
            {
                Console.WriteLine( $"{e.Id}.{e.FullName}\t{e.Salary}\t{e.DepartmentName}\t{e.RoleName}" );
            }*/
            

            // OrderBy
            /*var orderBySalary = result.OrderBy(e => e.Salary);
            foreach (var e in orderBySalary)
            {
                Console.WriteLine($"{e.Id}.{e.FullName}\t{e.Salary}\t{e.DepartmentName}\t{e.RoleName}");
            }
            Console.WriteLine(Environment.NewLine);*/


            // OrderByDescending
            /*var orderByDescSalary = result.OrderByDescending(e => e.Salary);
            foreach (var e in orderByDescSalary)
            {
                Console.WriteLine($"{e.Id}.{e.FullName}\t{e.Salary}\t{e.DepartmentName}\t{e.RoleName}");
            }
            Console.WriteLine(Environment.NewLine);*/


            // Average
            var avg = result.Average(e => e.Salary);
            Console.WriteLine($"Average = {((int)avg)}.");
            Console.WriteLine(Environment.NewLine);


            // Sum
            var sum = result.Sum(e => e.Salary);
            Console.WriteLine($"Jami Summa = {((int)sum)}.");
            Console.WriteLine(Environment.NewLine);


            // Max
            var maxSalary = result.Max(e => e.Salary);
            Console.WriteLine($"Eng ko'p oylik = {((int)maxSalary)}.");
            Console.WriteLine(Environment.NewLine);


            // Min
            var minSalary = result.Min(e => e.Salary);
            Console.WriteLine($"Eng kam oylik = {((int)minSalary)}.");
            Console.WriteLine(Environment.NewLine);

            
            // Count
            var count = result.Count(e => e.Salary >= 4000);
            Console.WriteLine($"$4000 dan ko'p oladiganlar soni = {count}");
            Console.WriteLine(Environment.NewLine);


            // SelectMany
            var selectMany = context.Departments
                .Where(d => d.Name == "HR")
                .SelectMany(d => d.Employees)
                .ToList();
            foreach (var e in selectMany)
            {
                Console.WriteLine(e.FullName);
            }
            Console.WriteLine(Environment.NewLine);


            // GroupBy
            var gruopDepartment = context.Employees
                .GroupBy(e => e.DepartmentId)
                .Select(g => new {
                    DepartmentId = g.Key,
                    Count = g.Count()
                });
            foreach (var e in gruopDepartment)
            {
                Console.WriteLine($"{e}");
            }
            Console.WriteLine(Environment.NewLine);


            // Any
            var employee = context.Employees
                .Select(e => e.Id)
                .Any(id => id == 12);

            if (employee)
            {
                Console.WriteLine("Bor");
            }
            else
            {
                Console.WriteLine("Yo'q");
            }
            Console.WriteLine(Environment.NewLine);


            // Distinct
            /*var distinct = result.Distinct();
            foreach (var e in distinct)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(Environment.NewLine);*/

            // ElementAt
            var elementAt = context.Employees
                .OrderBy(e => e.Id)
                .ElementAt(10);
            Console.WriteLine($"{elementAt.Id}. {elementAt.FullName} = {elementAt.Salary}");
            Console.WriteLine(Environment.NewLine);


            // Add
            /*var addEmployee = new Employee
            {
                FullName = "Alibek",
                Salary = 2800,
                DepartmentId = 6,
                RoleId = 9
            };
            context.Employees.Add(addEmployee);*/


            // Cast
           /* var casting = context.Employees
                .Select(e => e.Id)
                .Cast<Role>();
            Console.WriteLine(casting);*/


            // Join
            /*var innerJoin = context.Employees
                .Join(
                    context.Roles,
                    employee => employee.RoleId,
                    role => role.Id,
                    (employee, role) => new
                        {
                            EmployeeId = employee.Id,
                            EmployeeFullName = employee.FullName,
                            RoleName = role.Name
                        }
                    )
                .ToList();
            foreach( var e in innerJoin )
            {
                Console.WriteLine($"{e.EmployeeId}. {e.EmployeeFullName}  =  {e.RoleName}");
            }
            Console.WriteLine(Environment.NewLine);*/


            // Group Join
            var groupJoin = context.Departments
                .GroupJoin( 
                    context.Employees,
                    department => department.Id,
                    employee => employee.DepartmentId,
                    (department, employee) => new
                    {
                        DepartmentName = department.Name,
                        Employees = employee.Select(e => e.FullName)
                    }
                )
                .ToList();
            foreach ( var d in groupJoin )
            {
                Console.WriteLine($"// = {d.DepartmentName} = \\  ishchilari =>");
                foreach (var e in d.Employees)
                {
                    Console.Write(e + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(Environment.NewLine);


            // Skip
            var skipedEmployee = context.Employees
                .OrderBy(e => e.Id)
                .Skip(15)
                .ToList();
            foreach( var d in skipedEmployee )
                Console.WriteLine($"{d.Id}. {d.FullName}");
            Console.WriteLine(Environment.NewLine);


            // Take
            var takedEmployee = context.Employees
                .OrderBy(e => e.Id)
                .Take(5)
                .ToList();
            foreach (var item in takedEmployee)
                Console.WriteLine($"{item.Id}. {item.FullName}");
            Console.WriteLine(Environment.NewLine);


            // Distinct
            var emp11 = context.Employees
                .Select(e => e.FullName)
                .Distinct()
                .ToList();
            foreach (var e in emp11)
            {
                Console.WriteLine($"{e}");
            }
            Console.WriteLine(Environment.NewLine);


            // Union
            var itRole = context.Departments
                .Where(e => e.Name == "IT")
                .Select(e => e.Id);

            var hrRole = context.Departments
                .Where(e => e.Name == "HR")
                .Select(e => e.Id);
                
            var unionRole = itRole.Union(hrRole).ToList();
            Console.WriteLine($"Union = {unionRole.Count} ta");
            Console.WriteLine(Environment.NewLine);


            // Except
            var allEmployee = context.Employees
                .Select (e => e.Id)
                .ToList();
            var topEmployee = context.Employees
                .Where(e => e.Salary > 6000)
                .Select (e => e.Id)
                .ToList();
            var otherEmployee = allEmployee.Except(topEmployee).ToList();
            Console.WriteLine($"Except = {otherEmployee.Count} ta");
            Console.WriteLine(Environment.NewLine);


            // Intersect
            var emp0 = context.Employees
                .Where(e => e.DepartmentId == 1)
                .Select (e => e.Id)
                .ToList ();

            var intersection = topEmployee.Intersect(emp0).ToList();
            Console.WriteLine($"Oylik 6000dan baland va Dp=IT bo'lgan ishchilar = {intersection.Count} ta");
            Console.WriteLine(Environment.NewLine);


            // Include
            var emp01 = context.Employees
                .Include(e => e.Role)
                .ToList();
            foreach (var e in emp01.Take(5))
            {
                Console.WriteLine($"{e.FullName}");
                if (e.Role != null)
                {
                    Console.WriteLine($"RoleName: {e.Role.Name}");
                }
            }
            Console.WriteLine(Environment.NewLine);


            // Find
            var finder = context.Employees.Find(25);

            if (finder != null)
            {
                Console.WriteLine($"Topildi: {finder.FullName}");
            }


        }
    }
}