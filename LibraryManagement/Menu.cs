using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LibraryManagement.Services;

namespace LibraryManagement
{
    public class Menu
    {
        public static Service Service { get; set; }
        public static void TheMenu()
        {

            Service = new Service();
            Console.WriteLine("Welcome to Library Management");

            var stop = "";
            while(stop != "y")
            {
                try
                {
                    Console.WriteLine("1. Rent");
                    Console.WriteLine("2. Close Rent");
                    Console.WriteLine("3. Manage Members");
                    Console.WriteLine("4. Manage Books");
                    var userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            Service.RentBook();
                            break;
                        case "2":
                            Service.CloseRent();
                            break;
                        case "3":
                            ManageMembers();
                            break;
                        case "4":
                            ManageBooks();
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }
                    Console.WriteLine("Would you like to exit from Library Managment Application?");
                    Console.WriteLine("Type y for yes");
                    stop = Console.ReadLine();
                }
                catch (Exception e)
                {
                    var ErrorLog = $"{DateTime.Now} - {e.StackTrace} - {e.Message}";
                    File.AppendAllLines("Logs.txt", new List<string> { ErrorLog });
                }
            }
        }

        public static void ManageMembers()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Show All Members");
            Console.WriteLine("2. Create New member");
            Console.WriteLine("3. Delete Member");
            Console.WriteLine("");
            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Service.ShowAllMembers();
                    break;
                case "2":
                    Service.CreateMember();
                    break;
                case "3":
                    Service.DeleteMember();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        public static void ManageBooks()
        {
            Console.WriteLine("1. Show All books");
            Console.WriteLine("2. Add new book");
            Console.WriteLine("3. Delete book");
            Console.WriteLine("4. Print all rented books");
            Console.WriteLine("5. Print all closed rents");
            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Service.ShowAllBooks();
                    break;
                case "2":
                    Service.CreateBook();
                    break;
                case "3":
                    Service.DeleteBook();
                    break;
                case "4":
                    Service.RentedBooks();
                    break;
                case "5":
                    Service.ClosedRentsBooks();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
        }
    }
}
