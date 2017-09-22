using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntChallenge1
{
    class Program
    {

        Event[] eventSchedule = new Event[24];

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Print_menu();
            p.Init_schedule();

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
                else
                {
                    Console.WriteLine("Unknown Command");
                }

            } while (!String.Equals(input, "exit", StringComparison.OrdinalIgnoreCase));
        }

        void Print_menu()
        {
            Console.WriteLine("     MENU     ");
            Console.WriteLine("==============");
            Console.WriteLine("   Schedule   ");
            Console.WriteLine("  Add Event   ");
            Console.WriteLine(" Delete Event ");
            Console.WriteLine("     Help     ");
            Console.WriteLine("==============");
            Console.WriteLine("     EXIT     ");
        }

        void Print_help()
        {
            Console.Write("      Valid commands (case insensitive)     \n" +
                "============================================\n" +
                "  Help      brings you to help screen\n" +
                "  Schedule  brings you to schedule\n" +
                "  Add       brings you to add event screen\n" +
                "  Delete    delete screen\n" +
                "  Menu      takes you back to the menu\n" +
                "  Exit      closes program\n");
        }

        void Init_schedule()
        {
            for (int i = 0; i < 24; i++)
            {
                Event myEvent = new Event("", i);
                eventSchedule[i] = myEvent;
            }
        }

        void Print_schedule()
        {
            Console.Write("   SCHEDULE   \n" +
                "==============\n");
            string periodAM = "AM";
            string periodPM = "PM";
            for (int i = 0; i < 24; i++)
            {
                if (i <= 11)
                {
                    if (i == 0 || i == 12)
                        Console.WriteLine(12 + " {0}: {1}", periodAM, eventSchedule[i].Task);
                    else
                        Console.WriteLine("{0:D2} {1}: {2}", (i % 12), periodAM, eventSchedule[i].Task);
                }
                else
                {
                    if (i == 0 || i == 12)
                        Console.WriteLine(12 + " {0}: {1}", periodPM, eventSchedule[i].Task);
                    else
                        Console.WriteLine("{0:D2} {1}: {2}", (i % 12), periodPM, eventSchedule[i].Task);
                }
            }
        }

        void Print_add()
        {
            Console.Write("                     ADD EVENT\n" +
                "=================================================\n" +
                "Input Hour and Task description to add a Task\n" +
                "to the schedule.  The valid Hour inputs are 0-23,\n" +
                "and if there is already a scheduled event at\n" +
                "the Hour inputed, you will be propted for another.\n\n");
            int hour = 0;
            bool valid = false;
            bool hourValid = false;
            do
            {
                
                Console.Write("Hour >> ");
                hourValid = Int32.TryParse(Console.ReadLine(), out hour);
                valid = hourValid
                    && String.Equals(eventSchedule[hour].Task, "");
                if (!valid)
                {
                    if (!hourValid)
                        Console.WriteLine("Please enter a valid Hour.");
                    else
                        Console.WriteLine("Hour already has scheduled Task. Choose another Hour.");
                }
            } while (!valid);
            Console.Write("Task >> ");
            string task = Console.ReadLine();
            Event myEvent = new Event(task, hour);
            eventSchedule[hour] = myEvent;
            Console.Clear();
            Console.WriteLine("Event Added at " + hour + ": " + eventSchedule[hour].Task);
        }

        void Print_del()
        {
            Console.Write(" DELETE EVENT \n" +
                "==============\n" +
                "Input Hour of Task to delete where valid inputs are 0-23.\n\n");
            Console.Write("Hour >> ");
            int hour = 0;
            while(!Int32.TryParse(Console.ReadLine(), out hour))
            {
                Console.WriteLine("Please enter valid Hour.");
                Console.Write(">> ");
            }
            Event myEvent = new Event("", hour);
            string task = eventSchedule[hour].Task;
            eventSchedule[hour] = myEvent;
            Console.Clear();
            Console.WriteLine("Event Deleted at " + hour + ": " + task);
        }
    }

    class Event
    {
        public int Time { get; set; }
        public string Task { get; set; }

        public Event(string name, int hour)
        {
            Task = name;
            Time = hour;
        }

        public Event()
        {
            Task = "-";
            Time = 3;
        }
    }
}