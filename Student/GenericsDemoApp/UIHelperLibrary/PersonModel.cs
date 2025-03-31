using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UIHelperLibrary
{
    public class PersonModel : IErrorCheck, IPrintable
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z]+$"))
                {
                    throw new ArgumentException("Invalid entry.  Only letters are allowed.");
                }

                _firstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z]+$"))
                {
                    throw new ArgumentException("Invalid entry.  Only letters are allowed.");
                }

                _lastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }
        public bool HasError { get; set; } = false;
        public string RequestName(string prompt)
        {
            string entry;
            string name;
            // Matches if anything other than letters is found
            Regex regex = new Regex("[^A-Za-z]+");

            do
            {
                Console.Write($"{prompt}");
                // ? prevents a run-time exception if null is read
                // If ReadLine returns null the whole expression evaluates to null and .Trim is not called
                entry = Console.ReadLine();
                name = entry.Trim();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = regex.Replace(name, "");
                    if (name.Length > 0)
                    {
                        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                    }
                }

                Console.WriteLine($"Entry: \'{entry}\' is invalid.  Please try again."); ;
            } while (true);
        }

        public void Print()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }
}