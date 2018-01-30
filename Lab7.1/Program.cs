using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wecome to our C# class.");
            PrintInfo();
        }

        public static int GetStudent(int numStudents)
        {
            Console.WriteLine("What student would you like to know about?  Enter a number between 1 and " + numStudents);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int studentNum) && studentNum<=numStudents && studentNum>=1)
            {
                return studentNum;
            }
            else
            {
                Console.WriteLine(input + " is not an option.  Please enter a number between 1 and " + numStudents);
                return GetStudent(numStudents);
            }
        }

        public static string InfoWanted(string name)
        {
            List<string> acceptable = new List<string> { "hometown", "favorite food" };
            Console.WriteLine("What would you like to know about " + name + "?  (enter 'hometown' or 'favorite food')");
            string input = Console.ReadLine().ToLower();
            if (acceptable.Contains(input) && input == "hometown")
            {
                return "hometown";
            }
            else if (acceptable.Contains(input) && input == "favorite food")
            {
                return "favorite food";
            }
            Console.WriteLine("That is not an option.  Please enter 'hometown' or 'favorite food'.");
            return InfoWanted(name);
        }

        public static void PrintInfo()
        {
            List<string> names = new List<string> { "Andrew", "Chamus", "David", "Aaron", "Marshal", "Jonathan",
                "Albert", "Adam", "Tommy", "Ian", "Kevin", "Kelsey"};
            List<string> hometown = new List<string> { "Fremont, MI", "Zeeland, MI", "Fort Wayne, IN", "Hart, MI", "Holland, MI", "Middleville, MI",
                "Grand Rapids, MI", "Grand Rapids, MI", "Raleigh, NC", "Allendale, MI", "Chicago, IL", "Grand Rapids, MI"};
            List<string> favoriteFood = new List<string> { "steak", "sushi", "lasagna", "ribeye", "burgers", "stouts", "pounded potatoes with beans",
                "putine", "chicken curry", "alfredo", "oatmeal", "chicken and potatoes"};
            
            int studentNum = GetStudent(names.Count());
            Console.WriteLine("Student number " + studentNum + " is " + names[studentNum - 1]);
            if (InfoWanted(names[studentNum - 1]) == "hometown")
            {
                Console.WriteLine(names[studentNum - 1] + " is from " + hometown[studentNum - 1] + ".");
            }
            else
            {
                Console.WriteLine(names[studentNum - 1] + "'s favorite food is " + favoriteFood[studentNum - 1] + ".");
            }
            Console.WriteLine("Would you like to find out more? (Y/N)");
            Again();
        }

        public static void Again()
        {
            string input;

            
            input = Console.ReadLine().ToLower();

            if (input == 'y'.ToString())
            {
                PrintInfo();
            }
            else if (input == 'n'.ToString())
            {
                Console.WriteLine("Goodbye");
                return;
            }
            else
            {
                Console.WriteLine("Not a valid input.  Would you like to try again? (Y/N)");
                Again();
            }
        }
    }
}
