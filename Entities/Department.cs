using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Connect_EFCore.Entities
{
    [Table("Department")]
    public class Department
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}
