using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ProjectSqlLite.Context;
using ProjectSqlLite.Model;

namespace ProjectSqlLite.Functionalities
{
    internal class EditEntities
    {
        public static void EditDepartment(CompanyContext context)
        {
            Console.Clear();
            bool back = true;
            List<Department> departments = ShowDept(context);
            Console.Write("Choose Department number to edit: ");
            int SelectedDept = int.Parse(Console.ReadLine()) -1;
            while(back)
            {
                Console.WriteLine("\n--- Editing Menu ---");
                Console.WriteLine("1 - Edit Department Data");
                Console.WriteLine("2 - Assign Employee to Department");
                Console.WriteLine("3 - Back");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write($"Old Department Name {departments[SelectedDept].Name} ");
                        Console.Write($"Enter new Department Name : ");
                        string NewDeptName = Console.ReadLine();
                        departments[SelectedDept].Name = NewDeptName;
                        context.SaveChanges();
                        break;
                     case "2": 
                        List <Employee> employees = ShowEmployees (context);
                        Console.Write("Choose Employee number to Assing: ");
                        int AssingedNumber = int.Parse(Console.ReadLine()) - 1;
                        employees[AssingedNumber].DepartmentId = departments[SelectedDept].DepartmentId;
                        context.SaveChanges();
                        Console.WriteLine($"Employee Number {AssingedNumber + 1} assinged to Department {SelectedDept + 1} Successfully");
                        break;
                     case "3":
                        back = false;
                        break;
                }
            }
            


        }

        public static void EditEmployee(CompanyContext context)
        {
            Console.Clear();
            bool back = true;

            // جلب كل الموظفين
            List<Employee> employees = ShowEmployees(context);

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees available to edit.");
                return;
            }

            Console.Write("Choose Employee number to edit: ");
            int selectedEmp = int.Parse(Console.ReadLine()) - 1;

            while (back)
            {
                Console.WriteLine("\n--- Editing Employee Menu ---");
                Console.WriteLine("1 - Edit Employee Data");
                Console.WriteLine("2 - Change Employee Department");
                Console.WriteLine("3 - Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write($"Old Employee Name: {employees[selectedEmp].Name} ");
                        Console.Write("Enter new Employee Name: ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newName))
                            employees[selectedEmp].Name = newName;

                        Console.Write($"Old Salary: {employees[selectedEmp].Salary} ");
                        Console.Write("Enter new Salary: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal newSalary))
                            employees[selectedEmp].Salary = newSalary;

                        context.SaveChanges();
                        Console.WriteLine("Employee data updated successfully.");
                        break;

                    case "2":
                        List<Department> departments = ShowDept(context);
                        for (int i = 0; i < departments.Count; i++)
                            Console.WriteLine($"{i + 1} - {departments[i].Name}");
                        Console.Write("Select new Department number: ");
                        int newDeptIndex = int.Parse(Console.ReadLine()) - 1;

                        employees[selectedEmp].DepartmentId = departments[newDeptIndex].DepartmentId;
                        context.SaveChanges();
                        Console.WriteLine($"Employee assigned to Department {departments[newDeptIndex].Name} successfully.");
                        break;

                    case "3":
                        back = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public static void EditProject(CompanyContext context)
        {
            Console.Clear();
            bool back = true;

            List<Project> projects = ShowProjects(context);

            if (projects.Count == 0)
            {
                Console.WriteLine("No projects available to edit.");
                return;
            }

            Console.Write("Choose Project number to edit: ");
            int selectedProj = int.Parse(Console.ReadLine()) - 1;

            while (back)
            {
                Console.WriteLine("\n--- Editing Project Menu ---");
                Console.WriteLine("1 - Edit Project Data");
                Console.WriteLine("2 - Assign Employee to Project");
                Console.WriteLine("3 - Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write($"Old Project Name: {projects[selectedProj].Name} ");
                        Console.Write("Enter new Project Name: ");
                        string newProjName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newProjName))
                            projects[selectedProj].Name = newProjName;

                     

                        context.SaveChanges();
                        Console.WriteLine("Project data updated successfully.");
                        break;

                    case "2":
                        List<Employee> employees = ShowEmployees(context);
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("No employees available to assign.");
                            break;
                        }

                        

                        Console.Write("Select Employee number to assign: ");
                        int empIndex = int.Parse(Console.ReadLine()) - 1;

                        projects[selectedProj].Employees.Add(employees[empIndex]);

                        context.SaveChanges();
                        Console.WriteLine($"Employee {employees[empIndex].Name} assigned to Project {projects[selectedProj].Name} successfully.");
                        break;

                    case "3":
                        back = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }


        public static List<Department> ShowDept(CompanyContext context)
        {
            Console.WriteLine("Departments List:");
            Console.ForegroundColor = ConsoleColor.Blue;
            var departments = context.Departments.ToList();
            foreach (var department in departments)
            {
                Console.WriteLine($"  ** Dept id :{department.DepartmentId} , Dept Name : {department.Name} ");
            }
            Console.ResetColor();
            return departments;
        }
        public static List<Employee> ShowEmployees(CompanyContext context)
        {
            Console.WriteLine("Employees List:");
            Console.ForegroundColor = ConsoleColor.Blue;
            var employees = context.Employees.ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"  ** Employee id :{emp.EmployeeId} , Employee Name : {emp.Name} ");
                
            }
            Console.ResetColor();
            return employees;
        }
        public static List<Project> ShowProjects(CompanyContext context)
        {
            Console.WriteLine("Projects List:");
            Console.ForegroundColor = ConsoleColor.Blue;
            var projects = context.Projects.ToList();
            foreach (var proj in projects)
            {
                Console.WriteLine($"  ** Project id :{proj.ProjectId} , Project Name : {proj.Name} ");

            }
            Console.ResetColor();
            return projects;
        }
    }
}
