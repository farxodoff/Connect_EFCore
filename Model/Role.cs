using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Connect_EFCore.Model
{
    [Table("Role")]
    public class Role
    {
        [Column("Id")]
        public int Id { get; set; }


        [Column("Name")]
        public string Name { get; set; }


        ICollection<Employee> Employees { get; set; }
    }
}
