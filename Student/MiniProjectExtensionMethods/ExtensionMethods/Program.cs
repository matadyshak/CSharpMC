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
            person.Age = "Enter your age in years: ".RequestInt(0, 120);
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");

            person.Age = "Enter your age in years: ".RequestInt();
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");

	    person.GradePointAverage = "Enter your Grade Point Average (0.00 - 4.00): ".RequestDouble(0.00, 4.00);
	    person.StartingSalary = "Enter your starting annual salary: ".RequestDecimal();


            Console.ReadLine();
        }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double GradePointAverage { get; set; }
        public decimal StartingSalary { get; set; }
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

        private static int RequestInt(this string message, bool useMinMax, int minValue = 0, int maxValue = 0)
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

        public static int RequestInt(this string message)
        {
            return message.RequestInt(false);
        }

        public static int RequestInt(this string message, int minvalue, int maxValue)
        {
            return message.RequestInt(true, minValue, maxValue);
        }

        private static double RequestDouble(this string message, bool useMinMax, double minValue = 0.0, double maxValue = 0.0)
        {
            bool validDouble = false;
            bool validRange = false;
            string entry = "";
            double output = 0.0;

            while ((validDouble == false) || (validRange == false))
            {
                Console.Write(message);
                entry = Console.ReadLine();
                try
                {
                    validDouble = double.TryParse(entry, out output);
                    validRange = true;
                    if (useMinMax)
                    {
                        validRange = ((output >= minValue) && (output <= maxValue));
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was not a valid double-precision floating point value.");
                }
            }
            return output;
        }

        public static double RequestDouble(this string message)
        {
            return message.RequestDouble(false);
        }

        public static double RequestDouble(this string message, double minValue, double maxValue)
        {
            return message.RequestDouble(true, minValue, maxValue);
        }

        private static double RequestDouble(this string message, bool useMinMax, double minValue = 0.0, double maxValue = 0.0)
        {
            bool validDouble = false;
            bool validRange = false;
            string entry = "";
            double output = 0.0;

            while ((validDouble == false) || (validRange == false))
            {
                Console.Write(message);
                entry = Console.ReadLine();
                try
                {
                    validDouble = double.TryParse(entry, out output);
                    validRange = true;
                    if (useMinMax)
                    {
                        validRange = ((output >= minValue) && (output <= maxValue));
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was not a valid double-precision floating point value.");
                }
            }
            return output;
        }

        public static decimal RequestDecimal(this string message)
        {
            return message.RequestDecimal(false);
        }

        public static decimal RequestDecimal(this string message, decimalouble minValue, double maxValue)
        {
            return message.RequestDouble(true, minValue, maxValue);
        }

    }
}

