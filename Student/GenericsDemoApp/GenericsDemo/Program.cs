using System;
using UIHelperLibrary;

namespace GenericsDemo
{
    class Program
    {
        static void Main()
        {
            PersonModel person = new PersonModel();
            person.FirstName = person.RequestName("Enter your first name: ");
            person.LastName = person.RequestName("Enter your last name: ");

            AddressModel address = new AddressModel();
            address.AddressLine1 = address.RequestAddressLine1("Enter Address Line 1: ");
            address.AddressLine2 = address.RequestAddressLine2("Enter Address Line 2 (or Enter key to skip): ");
            address.City         = address.RequestCity("Enter City: ");
            address.State        = address.RequestState("Enter State (Abbreviation Code): ");
            address.ZipCode      = address.RequestZipCode("Enter ZIP Code: ");

            Console.WriteLine($"{person.FirstName} {person.LastName}");
            Console.WriteLine($"{address.AddressLine1}");
            Console.WriteLine($"{address.City}, {address.State} {address.ZipCode}");

            string word = "Enter a string: ".RequestString();
            int integer1 = "Enter an integer value from 0 to 100: ".RequestInt(0, 100);
            int integer2 = "Enter an integer value: ".RequestInt();
            double double1 = "Enter a double-precision floating-point value from 0.0 to 4.0: ".RequestDouble(0.0, 4.0);
            decimal decimal1 = "Enter a decimal value from 0.00 to 1_000_000m: ".RequestDecimal(0.0m, 1_000_000.00m);

            Console.WriteLine($"String: {word}");
            Console.WriteLine($"Integer 1: {integer1}");
            Console.WriteLine($"Integer 2: {integer2}");
            Console.WriteLine($"Double 1: {double1}");
            Console.WriteLine($"Decimal 1: {decimal1}");
        }
    }
}
