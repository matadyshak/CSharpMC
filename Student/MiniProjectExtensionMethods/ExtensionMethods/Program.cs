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
            person.Age = person.Age.RequestInt("Enter your age in years: ", true, 0, 120);
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");

            person.Age = person.Age.RequestInt("Enter your age in years: ", false);
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");

            person.Age = person.Age.RequestInt("Enter your age in years: ");
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");

            Console.ReadLine();
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
        public static int RequestInt(this int number, string message, bool useMinMax, int minValue = 0, int maxValue = 0)
        {
            int output = 0;
            bool validInt = false;
            bool validRange = false;
            string entry = "";

            while ((validInt == false) || (validRange == false))
            {
                Console.Write(message);
                entry = Console.ReadLine();
                try
                {
                    validInt = int.TryParse(entry, out output);
                    validRange = true;
                    if (useMinMax)
                    {
                        validRange = ((output >= minValue) && (output <= maxValue));
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was not a valid integer value.");
                }
            }
            return output;
        }

        public static int RequestInt(this int number, string message)
        {
            int output = 0;

            output = output.RequestInt(message);
            return output;
        }
    }
}

