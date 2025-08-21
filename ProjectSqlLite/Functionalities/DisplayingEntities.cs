using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSqlLite.Context;
using ProjectSqlLite.Model;

namespace ProjectSqlLite.Functionalities
{
    internal class DisplayingEntities
    {
        public static void DisplayDepartments(CompanyContext context)
        {
            var Depts = context.Departments.Include(d => d.Employees);
            foreach (var dept in Depts)
            {
                Console.WriteLine($"Department Name : {dept.Name}");
                foreach (var emp in dept.Employees)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"  ** Employee Name : {emp.Name} , Salary {emp.Salary}");
                    Console.ResetColor();

                }
            }


        }

        public static void DisplayProjects(CompanyContext context)
        {
            Console.WriteLine("Projects List:");

            var projects = context.Projects
                                  .Include(p => p.Employees)
                                  .ToList();

            foreach (var proj in projects)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine($"  ** Project id : {proj.ProjectId}, Project Name : {proj.Name}");
                Console.ResetColor();

                if (proj.Employees != null && proj.Employees.Count > 0)
                {
                    Console.WriteLine("     Assigned Employees:");
                    foreach (var emp in proj.Employees)
                    {
                        Console.WriteLine($"        - {emp.EmployeeId}: {emp.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("     No employees assigned.");
                }
            }

        }


        public static void DisplayEmployees(CompanyContext context)
        {
            Console.WriteLine("Departments List:");

            var departments = context.Departments
                                     .Include(d => d.Employees)
                                     .ToList();

            foreach (var dept in departments)
            {
                Console.WriteLine($"  ** Department id : {dept.DepartmentId}, Department Name : {dept.Name}");

                if (dept.Employees != null && dept.Employees.Count > 0)
                {
                    Console.WriteLine("     Employees:");
                    foreach (var emp in dept.Employees)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine($"        - {emp.EmployeeId}: {emp.Name}");
                            Console.ResetColor();

                    }
                }
                else
                {
                    Console.WriteLine("     No employees in this department.");
                }
            }

        }

    }
}
