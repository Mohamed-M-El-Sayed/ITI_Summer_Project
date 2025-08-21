using System;
using ProjectSqlLite.Context;
using ProjectSqlLite.Functionalities;
using ProjectSqlLite.Model;
using ProjectSqlLite.UtilityClass;
using SQLitePCL;

namespace ProjectSqlLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Batteries.Init();
            using (var context = new CompanyContext())
            {
               
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("=== Main Menu ===");
                    Console.WriteLine("1 - Add");
                    Console.WriteLine("2 - Edit");
                    Console.WriteLine("3 - Delete");
                    Console.WriteLine("4 - Display");
                    Console.WriteLine("5 - Exit");
                    var choice = Console.ReadLine();

                     switch (choice)
                     {
                            case "1":
                                ShowMenus.AddMenu(context);
                                break;
                            case "2":
                               ShowMenus.EditMenu(context);
                                break;
                            case "3":
                            ShowMenus.DeleteMenu(context);
                                break;
                            case "4":
                            ShowMenus.DisplayMenu(context);
                                break;
                            case "5":
                                exit = true;
                                break;
                            default:
                               // Console.WriteLine("Invalid option.");
                                break;
                     }


                }

            }
        }
    }
}