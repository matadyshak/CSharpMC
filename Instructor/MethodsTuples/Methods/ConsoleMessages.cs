using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public static class ConsoleMessages
    {
        public static void SayHi(string firstName)
        {
            Console.WriteLine($"Hello {firstName}!");
            Console.WriteLine("I hope you are having a good day.");
        }

        public static string GetUsersName()
        {
            Console.Write("What is your name: ");
            string name = Console.ReadLine();

            return name;
        }

        // Tuple
        public static (string firstName, string lastName) GetFullName()
        {
            Console.Write("What is your first name: ");
            string firstName = Console.ReadLine();

            Console.Write("What is your last name: ");
            string lastName = Console.ReadLine();

            return (firstName, lastName);
        }

        public static void SayGoodbye()
        {
            Console.WriteLine("Goodbye, my user.");
            Console.WriteLine("Thank you for visiting.");
            Console.WriteLine("I cannot wait to see you again.");
        }
    }
}
