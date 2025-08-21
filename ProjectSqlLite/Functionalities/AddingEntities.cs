using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSqlLite.Context;
using ProjectSqlLite.Model;
using SQLitePCL;
 
namespace ProjectSqlLite.UtilityClass
{
    internal static class AddingEntities
    {

        public static void AddDepartment(CompanyContext context)
        {
            Console.Write("Department Name: ");
            string deptName = Console.ReadLine();
            context.Add(new Department { Name = deptName });
            context.SaveChanges();
            Console.WriteLine("Department added successfully.");
        }
        public static void AddEmployee(CompanyContext context)
        {
            Console.Write("Employee Name: ");
            string empName = Console.ReadLine();

            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            context.Employees.Add(new Employee
            {
                Name = empName,
                Salary = salary,
            });
            context.SaveChanges();
            Console.WriteLine("Employee added successfully.");
        }
        public static void AddProject(CompanyContext context)
        {
            Console.Write("Porject Name: ");
            string ProjName = Console.ReadLine();

            context.Add(new Project() { Name = ProjName });
            context.SaveChanges();
        }

    }
}
