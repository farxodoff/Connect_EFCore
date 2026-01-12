using System;
using System.Collections.Generic;
using System.Text;
using Connect_EFCore.Data;
using Connect_EFCore.Entities;

namespace Connect_EFCore.Repositories
{
    public class RoleRepository
    {
        private readonly AppDbContext _context = new AppDbContext();


        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

    }
}
