using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>();
            List<AddressModel> addresses = new List<AddressModel>();
            string entry;

            do
            {
                PersonModel person = new PersonModel();
                person.FirstName = person.GetValidName("Enter first name: ");
                person.LastName = person.GetValidName("Enter last name: ");
                people.Add(person);

                AddressModel address = new AddressModel();
                address.AddressLine1 = address.GetValidAddressLine1("Enter address line 1: "); ;
                address.AddressLine2 = address.GetValidAddressLine2("Enter address line 2 (or <enter> to skip): ");
                address.City = address.GetValidCity("Enter city: ");
                address.State = address.GetValidState("Enter two-letter state abbreviation: ");
                address.ZipCode = address.GetValidZipCode("Enter 5-digit Zip code or Zip+4 code: ");
                addresses.Add(address);

                Console.Write("Continue entering data? (y/n): ");
                entry = Console.ReadLine();
                Console.WriteLine();
            } while (entry.ToLower() == "y");

            int i = 0;
            foreach (PersonModel p in people)
            {
                Console.WriteLine();
                Console.WriteLine($"First name: {p.FirstName}");
                Console.WriteLine($"Last name: {p.LastName}");
                Console.WriteLine($"Address Line 1: {addresses[i].AddressLine1}");
                Console.WriteLine($"Address Line 2: {addresses[i].AddressLine2}");
                Console.WriteLine($"City: {addresses[i].City}");
                Console.WriteLine($"State: {addresses[i].State}");
                Console.WriteLine($"Zip: {addresses[i].ZipCode}");
                i++;
            }

            Console.ReadLine();
        }
    }
}
