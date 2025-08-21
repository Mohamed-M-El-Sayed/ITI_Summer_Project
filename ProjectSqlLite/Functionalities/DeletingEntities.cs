using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSqlLite.Context;
using ProjectSqlLite.Model;

namespace ProjectSqlLite.Functionalities
{
    static class DeletingEntities
    {
        public static void DeleteDepartment(CompanyContext context)
        {
            Console.Clear();
            List<Department> departments = EditEntities.ShowDept(context);

            if (departments.Count == 0)
            {
                Console.WriteLine(" No departments available to delete.");
                return;
            }

            Console.Write("Choose Department number to delete: ");
            int selectedDept = int.Parse(Console.ReadLine()) - 1;

            if (selectedDept < 0 || selectedDept >= departments.Count)
            {
                Console.WriteLine("Invalid department number.");
                return;
            }

            var dept = departments[selectedDept];

           // context.Entry(dept).Collection(d => d.Employees).Load();
            if (dept.Employees != null && dept.Employees.Count > 0)
            {
               // Console.WriteLine($"Department '{dept.Name}' has {dept.Employees.Count} employees.");
                Console.Write("Are you sure you want to delete it? (y/n): ");
                string confirm = Console.ReadLine();

                if (confirm.ToLower() != "y")
                {
                    Console.WriteLine("Deletion cancelled.");
                    return;
                }
            }

            context.Departments.Remove(dept);
            context.SaveChanges();

            Console.WriteLine($"Department '{dept.Name}' deleted successfully.");
        }
        public static void DeleteEmployee(CompanyContext context)
        {
            Console.Clear();
            List<Employee> employees = EditEntities.ShowEmployees(context);

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees available to delete.");
                return;
            }

            Console.Write("Choose Employee number to delete: ");
            int selectedEmp = int.Parse(Console.ReadLine()) - 1;

            if (selectedEmp < 0 || selectedEmp >= employees.Count)
            {
                Console.WriteLine("Invalid employee number.");
                return;
            }

            var emp = employees[selectedEmp];

            Console.Write($"Are you sure you want to delete Employee '{emp.Name}'? (y/n): ");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() != "y")
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }

            context.Employees.Remove(emp);
            context.SaveChanges();

            Console.WriteLine($"Employee '{emp.Name}' deleted successfully.");
        }
        public static void DeleteProject(CompanyContext context)
        {
            Console.Clear();

            var projects = EditEntities.ShowProjects(context);

            if (projects.Count == 0)
            {
                Console.WriteLine(" No projects available to delete.");
                return;
            }

            Console.Write("Choose project number to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int selectedProj) || selectedProj < 1 || selectedProj > projects.Count)
            {
                Console.WriteLine("Invalid project number.");
                return;
            }

            var project = projects[selectedProj - 1];

            Console.Write($"Are you sure you want to delete project '{project.Name}'? (y/n): ");
            string confirm = Console.ReadLine();
            if (confirm?.ToLower() != "y")
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }

            project.Employees.Clear();

            context.Projects.Remove(project);
            context.SaveChanges();

            Console.WriteLine($" Project '{project.Name}' deleted successfully (employees kept).");
        }

    }
}
