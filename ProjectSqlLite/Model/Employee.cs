using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSqlLite.Model
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Project> Projects { get; set; }
    }

}
