using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSqlLite.Context;
using ProjectSqlLite.UtilityClass;

namespace ProjectSqlLite.Functionalities
{
    internal static class ShowMenus
    {
        static ShowMenus()
        {
            Console.Clear();
        }
        public static void AddMenu(CompanyContext context)
        {
            Console.WriteLine("\n--- Add Menu ---");
            Console.WriteLine("1 - Add Department");
            Console.WriteLine("2 - Add Employee");
            Console.WriteLine("3 - Add Project");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddingEntities.AddDepartment(context);
                    break;
                case "2":
                    AddingEntities.AddEmployee(context);
                    break;
                case "3":
                    AddingEntities.AddProject(context);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }



        public static void EditMenu(CompanyContext context)
        {
            Console.WriteLine("\n--- Edit Menu ---");
            Console.WriteLine("1 - Edit Department");
            Console.WriteLine("2 - Edit Employee");
            Console.WriteLine("3 - Edit Project");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EditEntities.EditDepartment(context);
                    break;
                case "2":
                    EditEntities.EditEmployee(context);
                    break;
                case "3":
                    EditEntities.EditProject(context);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }
        public static void DisplayMenu(CompanyContext context)
        {
            Console.WriteLine("\n--- Display Menu ---");
            Console.WriteLine("1 - Display Department");
            Console.WriteLine("2 - Display Employee");
            Console.WriteLine("3 - Display Project");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayingEntities.DisplayDepartments(context);
                    break;
                case "2":
                    DisplayingEntities.DisplayEmployees(context);
                    break;
                case "3":
                    DisplayingEntities.DisplayProjects(context);
                    break;
            }
        }

        public static void DeleteMenu(CompanyContext context)
        {
            Console.WriteLine("\n--- Delete Menu ---");
            Console.WriteLine("1 - Delete Department");
            Console.WriteLine("2 - Delete Employee");
            Console.WriteLine("3 - Delete Project");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DeletingEntities.DeleteDepartment(context);
                    break;
                case "2":
                    DeletingEntities.DeleteEmployee(context);
                    break;
                case "3":
                   DeletingEntities.DeleteProject(context);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }
    }
}
