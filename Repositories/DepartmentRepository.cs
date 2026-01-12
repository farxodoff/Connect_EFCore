using System;
using System.Collections.Generic;
using System.Text;
using Connect_EFCore.Data;
using Connect_EFCore.Entities;

namespace Connect_EFCore.Repositories
{
    public class DepartmentRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

    }
}
