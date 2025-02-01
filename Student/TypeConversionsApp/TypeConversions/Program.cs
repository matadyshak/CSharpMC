using System;
using System.Globalization;

namespace TypeConversions
{
    internal class Program
    {
        static void Main()
        {
            bool isValid = false;
            string? ageText = string.Empty;
            string? herAgeText = string.Empty;
            string? hisAgeText = string.Empty;
            int age = 0;
            int herAge = 0;
            int hisAgeHex = 0;

            //Using int.Parse() with try-catch
            isValid = false;
            while (!isValid)
            {
                Console.Write("What is her age? ");
                herAgeText = Console.ReadLine();
                try
                {
                    // Throws an exception if the conversion fails
                    herAge = int.Parse(herAgeText);
                    // On exception the next line does not execute
                    isValid = true;
                }
                catch (Exception ex)
                {
                    // Example: "The input string 'eight' was not in a correct format."
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Her age is {herAge}.");

            //Using TryParse() without try-catch
            isValid = false;
            while (!isValid)
            {
                Console.Write("What is your age? ");
                ageText = Console.ReadLine();
                //Does not throw an exception but returns bool for valid or !valid
                isValid = int.TryParse(ageText, out age);
                if (!isValid)
                {
                    Console.WriteLine($"The input string \'{ageText}\' was not in a correct format.");
                }
            }
            //age is out of scope here if declared in the tryParse statement
            Console.WriteLine($"Your age is {age}.");

            //Using TryParse() without try-catch to read a hex value
            isValid = false;
            while (!isValid)
            {
                Console.Write("What is his age in hex? ");
                try
                {
                    hisAgeText = Console.ReadLine();
                    isValid = int.TryParse(hisAgeText, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hisAgeHex);
                    if (!isValid)
                    {
                        Console.WriteLine($"The input string \'{hisAgeText}\' was not in a correct format.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }   
            Console.WriteLine($"His age in hex is {hisAgeHex.ToString("x")}");





            //double testDouble = age;
            //Casting
            //decimal testDecimal = (decimal)testDouble;
        }
    }
}
