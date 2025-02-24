using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    public class PersonModel
    {
        private string _firstName;
        private string _lastName;
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _state;
        private string _zipCode;


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

        public string AddressLine1
        {
            get { return _addressLine1; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z0-9 ]+$"))
                {
                    throw new ArgumentException("Invalid entry.  Only numbers, letters and spaces are allowed.");
                }

                _addressLine1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        public string AddressLine2
        {
            get { return _addressLine2; }
            set
            {
                value = value.Trim();
                // For this property allow empty string
                if (string.IsNullOrEmpty(value))
                {
                    _addressLine2 = "";
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z0-9 ]+$"))
                    {
                        throw new ArgumentException("Invalid entry.  Only numbers, letters and spaces are allowed.");
                    }
                    _addressLine2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                }
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z0-9 ]+$"))
                {
                    throw new ArgumentException("Invalid entry.  Only numbers, letters and spaces are allowed.");
                }

                _city = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                value = value.Trim().ToUpper();
                // 50 states and Washington, DC
                string regexState = @"^(A[LKZR]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[DLN]|K[SY]|LA|M[ADEINOST]|N[CDEJMSTVY]|O[HKR]|P[A]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, regexState))
                {
                    throw new ArgumentException("Invalid entry.  Only valid U.S. state abbreviations (or DC) are allowed.");
                }

                _state = value;
            }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\d{5}(-\d{4})?$"))
                {
                    throw new ArgumentException("Invalid entry.  Only 5-digit ZIP codes or 9-digit ZIP+4 codes are allowed.");
                }

                _zipCode = value;
            }
        }

        public string GetValidName(string prompt)
        {
            string name;
            // Matches if anything other than letters is found
            Regex regex = new Regex("[^A-Za-z]+");

            do
            {
                Console.Write($"{prompt}");
                // ? prevents a run-time exception if null is read
                // If ReadLine returns null the whole expression evaluates to null and .Trim is not called
                name = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = regex.Replace(name, "");
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                }

                Console.WriteLine($"Entry: \'{name}\' is invalid.  Please try again."); ;
            } while (true);
        }
        public string GetValidAddressLine1(string prompt)
        {
            string address1;
            // Matches if anything other than letters, numbers or spaces are found
            Regex regex = new Regex("[^A-Za-z0-9 ]+$");

            do
            {
                Console.Write($"{prompt}");
                address1 = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(address1))
                {
                    address1 = regex.Replace(address1, "");
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address1.ToLower());
                }

                Console.WriteLine($"Entry: \'{address1}\' is invalid.  Please try again."); ;
            } while (true);
        }
        public string GetValidAddressLine2(string prompt)
        {
            string address2;
            // Matches if anything other than letters, numbers or spaces are found
            Regex regex = new Regex("[^A-Za-z0-9 ]+$");

            Console.Write($"{prompt}");
            address2 = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(address2) && address2.Length > 0)
            {
                address2 = regex.Replace(address2, "");
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address2.ToLower());
            }
            return "";
        }
        public string GetValidCity(string prompt)
        {
            string city;
            // Matches if anything other than letters or spaces are found
            Regex regex = new Regex("[^A-Za-z ]+$");

            do
            {
                Console.Write($"{prompt}");
                city = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(city))
                {
                    city = regex.Replace(city, "");
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city.ToLower());
                }

                Console.WriteLine($"Entry: \'{city}\' is invalid.  Please try again."); ;
            } while (true);
        }
        public string GetValidState(string prompt)
        {
            string state;
            string regexState = @"^(A[LKZR]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[DLN]|K[SY]|LA|M[ADEINOST]|N[CDEJMSTVY]|O[HKR]|P[A]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";

            do
            {
                Console.Write($"{prompt}");
                state = Console.ReadLine()?.Trim().ToUpper();

                if (!string.IsNullOrWhiteSpace(state) && Regex.IsMatch(state, regexState))
                {
                    return state;
                }

                Console.WriteLine($"Entry: \'{state}\' is invalid.  Entry must be a valid two-letter state abbreviation."); ;
            } while (true);
        }

        public string GetValidZipCode(string prompt)
        {
            string zipCode;
            // Matches if anything other than letters or spaces are found
            string regexZipCode = @"^\d{5}(-\d{4})?$";

            do
            {
                Console.Write($"{prompt}");
                zipCode = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(zipCode) && Regex.IsMatch(zipCode, regexZipCode))
                {
                    return zipCode;
                }

                Console.WriteLine($"Entry: \'{zipCode}\' is invalid.  Entry must be a 5-digit ZIP code or ZIP+4 code."); ;
            } while (true);
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
