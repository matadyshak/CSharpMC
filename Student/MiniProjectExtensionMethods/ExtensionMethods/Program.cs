using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel();

            person.FirstName = "Enter your first name: ".RequestString();
            person.LastName = "Enter your last name: ".RequestString();
            //            person.Age = "Enter your age in years: ".RequestInt();

            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public static class ConsoleHelper
    {
        public static string RequestString(this string message)
        {
            string output = "";
            bool valid = false;

            while (valid == false)
            {
                Console.Write(message);
                output = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(output) == false)
                {
                    valid = true;
                }
            }
            return output;
        }
    }
}

