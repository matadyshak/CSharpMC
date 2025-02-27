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

            PersonModel cannedPerson = new PersonModel("Michael",
                                                 "Tadyshak");

            AddressModel cannedAddress = new AddressModel("123 Wooly Bucket",
                                                 "Apt 124",
                                                 "Woodlands",
                                                 "TX",
                                                 "77243");
            employees.Add((cannedPerson, cannedAddress));

            do
            {
                PersonModel person = new PersonModel();
                person.GetValidFirstName("Enter first name: ");
                person.GetValidLastName("Enter last name: ");

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
                Console.WriteLine($"Full Address:\n{a.FullAddress}");
            }

            Console.ReadLine();
        }
    }
}

/*

Things demonstrated in the instructor's code:

X 1. auto property
  2. Explicit auto property
  3. private get
x 4. private set
x 5. Constructor call
x 6. Overloaded constructors
x 7. get method FullName which returns two properties
  8. set only
X 9. Validation code in set with exception
  10. Get only displays last 4 of SSN

At this point all setters and getters are public.
Keep validation code in GetValid... methods.
Remove validation code in get/set methods
Make use of constructors
Use auto property
Use explicit auto property
Try validation in GetValid method only & setter only with public setter and private setter
GetValid calling private setter before return vs. calling setter from main which required public setter

FirstName - Validate in GetValue method only - Public property with private set so not allowed to set in main.
          - There is no longer a return value that main stores in FirstName but the GetValue function sets FirstName
          - Regex replace and Title case do their jobs then set FirstName from within the class
          - Setting FirstName in the PersonModel class would bypass validation
          - If just numbers or white space there would be the opportunity to re-enter

LastName - No validation in the GetValue method
         - Setter generated an exception
         - Input was Tady33Shak 33 ?
         - Setter only checks for a regex match which if not matching generates an exception

*/
