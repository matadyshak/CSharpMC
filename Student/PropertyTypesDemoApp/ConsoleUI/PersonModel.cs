using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    public class PersonModel
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            private set
            {
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z]+$"))
                {
                    throw new ArgumentException("Invalid entry.  Only letters are allowed.");
                }

                _lastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        // Constructors do not specify a return value because they never have one
        public PersonModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public PersonModel()
        {
        }

        //validate the FirstName here but not in the setter
        public void GetValidFirstName(string prompt)
        {
            string entry;
            string name;
            // Matches if anything other than letters is found
            Regex regex = new Regex("[^A-Za-z]+");

            do
            {
                Console.Write($"{prompt}");
                entry = Console.ReadLine();
                name = entry.Trim();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = regex.Replace(name, "");
                    if (name.Length > 0)
                    {
                        FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                        return;
                    }
                }

                Console.WriteLine($"Entry: \'{entry}\' is invalid.  Please try again."); ;
            } while (true);
        }

        //validate the LastName not here but in the setter

        public void GetValidLastName(string prompt)
        {
            Console.Write($"{prompt}");
            LastName = Console.ReadLine();
        }
    }
}


//Issues:
//1. User Input Inside a Property Setter: Property setters should not handle user interaction (Console.ReadLine()).
//    This should be managed outside the property.
//
//2. Loop Inside a Setter: Setters should only assign values, not perform complex logic like loops.
//
//3. isValid Flag is Unnecessary: The do-while loop will ensure valid input, making isValid redundant.
//
//4. Potential Infinite Loop in Some Contexts: If Console.ReadLine() is null (e.g., in non-interactive environments), this will break.
//
//
//public string FirstName
//{
//    get { return _firstName; }
//    set
//    {
//        bool isValid = false;
//        string name;
//        Regex regex = new Regex("[^A-Za-z]+");
//
//        do
//        {
//            Console.Write("Enter first name: ");
//            name = Console.ReadLine();
//            if (!string.IsNullOrWhiteSpace(name))
//            {
//                name = regex.Replace(name, "");
//                name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.Trim().ToLower());
//                isValid = true;
//            }
//            else
//            {
//                Console.WriteLine($"Entry: {name} is invalid.  Please try again.");
//            }
//        } while (!isValid);
//        _firstName = name;
//    }
//}
