using System.Globalization;
using System.Text.RegularExpressions;

namespace DemoLibrary
{
    public class PersonModel
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
                    value = "";
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
                    value = "";
                }

                _lastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }
        public string ValidateName(string entry)
        {
            string name = entry.Trim();

            // Matches if anything other than letters is found
            Regex regex = new Regex("[^A-Za-z]+");

            if (!string.IsNullOrWhiteSpace(name))
            {
                // Remove anything other than letters
                name = regex.Replace(name, "");
                if (name.Length > 0)
                {
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                }
            }
            return "";
        }
    }
}