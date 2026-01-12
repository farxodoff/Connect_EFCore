using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Connect_EFCore.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Column("Id")]
        public int Id { get; set; }


        [Column("FullName")]
        public string FullName { get; set; }


        [Column("Salary")]
        public decimal Salary { get; set; }


        [Column("DepartmentId")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


        [Column("RoleId")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
