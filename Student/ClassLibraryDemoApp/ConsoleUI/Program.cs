using DemoLibrary.Models;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(PersonModel, AddressModel)> employees = new List<(PersonModel, AddressModel)>();
            string entry;

            do
            {
                PersonModel person = new PersonModel();
                person.FirstName = GetValidName(person, "Enter first name: ");
                person.LastName = GetValidName(person, "Enter last name: ");

                AddressModel address = new AddressModel();
                address.AddressLine1 = address.GetValidAddressLine1(address, "Enter address line 1: "); ;
                address.AddressLine2 = address.GetValidAddressLine2(address, "Enter address line 2 (or <enter> to skip): ");
                address.City = address.GetValidCity(address, "Enter city: ");
                address.State = address.GetValidState(address, "Enter two-letter state abbreviation: ");
                address.ZipCode = address.GetValidZipCode(address, "Enter 5-digit Zip code or Zip+4 code: ");

                employees.Add((person, address));

                Console.Write("Continue entering data? (y/n): ");
                entry = Console.ReadLine();
                Console.WriteLine();
            } while (entry.ToLower() == "y");

            foreach ((PersonModel p, AddressModel a) in employees)
            {
                Console.WriteLine();
                Console.WriteLine($"First name: {p.FirstName}");
                Console.WriteLine($"Last name: {p.LastName}");
                Console.WriteLine($"Address Line 1: {a.AddressLine1}");
                Console.WriteLine($"Address Line 2: {a.AddressLine2}");
                Console.WriteLine($"City: {a.City}");
                Console.WriteLine($"State: {a.State}");
                Console.WriteLine($"Zip: {a.ZipCode}");
            }

            Console.ReadLine();
        }

        public static string GetValidName(PersonModel person, string prompt)
        {
            string entry;
            string output;
            int status;

            do
            {
                Console.Write($"{prompt}");
                entry = Console.ReadLine();

                status = person.TryValidateName(entry, out output);

                if (status != 0)
                {
                    Console.WriteLine($"Entry: \'{entry}\' is invalid.  Please try again.");
                }
            } while (status != 0);

            return output;
        }
    }
}
