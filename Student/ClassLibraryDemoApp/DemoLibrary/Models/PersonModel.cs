using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DemoLibrary.Models
{
    public class PersonModel
    {
        private string _firstName;
        private string _lastName;
        private static readonly Regex nameRegex = new Regex("[^A-Za-z]+");

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                int status = TryValidateName(value, out string validatedName);
                if (status == 0)
                {
                    _firstName = validatedName;
                }
                else
                {
                    throw new ArgumentException("Invalid entry. Only letters are allowed.");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                int status = TryValidateName(value, out string validatedName);
                if (status == 0)
                {
                    _lastName = validatedName;
                }
                else
                {
                    throw new ArgumentException("Invalid entry. Only letters are allowed.");
                }
            }
        }

        public int TryValidateName(string entry, out string output)
        {
            string name = entry.Trim();
            output = "";

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = nameRegex.Replace(name, "");
                if (name.Length > 0)
                {
                    name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                    output = name;
                    // success
                    return 0;
                }
            }
            //failed 
            return 1;
        }
    }
}



