
using ConsoleUI.Models;
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
                person.FirstName = person.GetValidName("Enter first name: ");
                person.LastName = person.GetValidName("Enter last name: ");

                AddressModel address = new AddressModel();
                address.AddressLine1 = address.GetValidAddressLine1("Enter address line 1: "); ;
                address.AddressLine2 = address.GetValidAddressLine2("Enter address line 2 (or <enter> to skip): ");
                address.City = address.GetValidCity("Enter city: ");
                address.State = address.GetValidState("Enter two-letter state abbreviation: ");
                address.ZipCode = address.GetValidZipCode("Enter 5-digit Zip code or Zip+4 code: ");

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
    }
}
