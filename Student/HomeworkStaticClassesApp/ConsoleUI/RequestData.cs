using System;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    public static class RequestData
    {
        public static double GetDouble(string prompt)
        {
            bool isValid = false;
            string doubleText;
            double output;

            do
            {
                Console.Write(prompt);
                doubleText = Console.ReadLine();
                isValid = double.TryParse(doubleText, out output);
                if (!isValid)
                {
                    Console.WriteLine($"The entry: \'{doubleText}\' is invalid.  Please try again.");
                }
            } while (!isValid);

            return output;
        }

        public static string GetOperator(string prompt)
        {
            bool isValid = false;
            //          Regex regex = new Regex(@"^[+-*/]$"); //Fails
            Regex regex = new Regex(@"^[*/+-]$");
            string output;

            do
            {
                Console.Write(prompt);
                output = Console.ReadLine();
                isValid = regex.IsMatch(output);
                if (!isValid)
                {
                    Console.WriteLine($"The operator: \'{output}\' is invalid.  Please try again.");
                }
            } while (!isValid);

            return output;
        }
    }
}

