using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSqlLite.Model
{
    internal class Department
    {

            public int DepartmentId { get; set; }
            public string Name { get; set; }

        // One-to-Many
        public ICollection<Employee> Employees { get; set; }
        
    }
}
