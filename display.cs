using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    internal class display
    { 
        operations p = new operations();

        public void Menu()
        {      

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. VIEW FRAME");
                Console.WriteLine("2. ADD FRAME");
                Console.WriteLine("3. SEARCH FRAME");
                Console.WriteLine("4. UPDATE FRAME");
                Console.WriteLine("5. DELETE FRAME");
                Console.WriteLine("6. EXIT SYSTEM");
                Console.Write("Enter your choice: ");
                Console.Beep();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        p.view();
                        break;

                    case "2":
                        p.add();
                        break;

                    case "3":
                        p.search();
                        break;

                    case "4":
                        p.update();
                        break;

                    case "5":
                        p.delete();
                        break;

                    case "6":
                        Console.WriteLine("Exiting the progress...");
                        running = false;
                        break;

                    default:
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }
            Console.ReadLine();
        }

       







    }
}
