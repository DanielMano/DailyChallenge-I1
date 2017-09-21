using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntChallenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Print_menu();

            string input;
            do
            {
                Console.Write("\n>> ");
                input = Console.ReadLine();
                Console.WriteLine();
                if (String.Equals(input, "help", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    p.Print_help();
                }
                else if (String.Equals(input, "schedule", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    p.Print_schedule();
                }
                else if (String.Equals(input, "add", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    p.Print_add();
                }
                else if (String.Equals(input, "delete", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    p.Print_del();
                }
                else if (String.Equals(input, "menu", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    p.Print_menu();
                }

            } while (!input.Equals("EXIT"));
        }

        void Print_menu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("=====");
            Console.WriteLine("View Schedule");
            Console.WriteLine("Add Event");
            Console.WriteLine("Delete Event");
            Console.WriteLine("Help");
            Console.WriteLine("=====");
            Console.WriteLine("EXIT");
        }

        void Print_help()
        {
            Console.Write("Valid commands (case insensitive):\n" +
                "=====\n" +
                "Help - brings you to help screen\n" +
                "Schedule - brings you to schedule\n" +
                "Add - brings you to add event screen\n" +
                "Delete - delete screen" +
                "Menu - takes you back to the menu\n" +
                "Exit - closes program\n");
        }

        void Print_schedule()
        {

        }

        void Print_add()
        {

        }

        void Print_del()
        {

        }
    }
}