using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel();

            person.FirstName = person.GetValidName("Enter first name: ");
            person.LastName = person.GetValidName("Enter last name: ");
            person.AddressLine1 = person.GetValidAddressLine1("Enter address line 1: "); ;
            person.AddressLine2 = person.GetValidAddressLine2("Enter address line 2 (or <enter> to skip): ");
            person.City = person.GetValidCity("Enter city: ");
            person.State = person.GetValidState("Enter two-letter state abbreviation: ");
            person.ZipCode = person.GetValidZipCode("Enter 5-digit Zip code or Zip+4 code: ");

            Console.WriteLine();
            Console.WriteLine($"First name: {person.FirstName}");
            Console.WriteLine($"Last name: {person.LastName}");
            Console.WriteLine($"Address Line 1: {person.AddressLine1}");
            Console.WriteLine($"Address Line 2: {person.AddressLine2}");
            Console.WriteLine($"City: {person.City}");
            Console.WriteLine($"State: {person.State}");
            Console.WriteLine($"Zip: {person.ZipCode}");
        }
    }
}
