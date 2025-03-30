using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UIHelperLibrary
{
    public class AddressModel
    {
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _state;
        private string _zipCode;

        public string AddressLine1
        {
            get { return _addressLine1; }
            set
            {
                value = value.Trim();
                //              if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z0-9 ]+$"))

                // Match letters, numbers and single spaces
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$"))
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
                    //                    if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z0-9 ]+$"))
                    if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$"))
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
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[A-Za-z ]+$"))
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
        public string RequestAddressLine1(string prompt)
        {
            string address1;
            string entry;

            do
            {
                Console.Write($"{prompt}");
                entry = Console.ReadLine();
                address1 = CleanMultiWordNumericString(entry);

                if (!string.IsNullOrWhiteSpace(address1))
                {
                    if (address1.Length > 0)
                    {
                        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address1.ToLower());
                    }
                }

                Console.WriteLine($"Entry: \'{entry}\' is invalid.  Please try again."); ;
            } while (true);
        }
        public string RequestAddressLine2(string prompt)
        {
            string address2;
            string entry;

            Console.Write($"{prompt}");
            entry = Console.ReadLine();
            address2 = CleanMultiWordNumericString(entry);

            if (!string.IsNullOrWhiteSpace(address2))
            {
                if (address2.Length > 0)
                {
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address2.ToLower());
                }
            }
            return "";
        }
        public string RequestCity(string prompt)
        {
            string city;
            string entry;

            do
            {
                Console.Write($"{prompt}");
                entry = Console.ReadLine();
                city = CleanMultiWordAlphaString(entry);

                if (!string.IsNullOrWhiteSpace(city))
                {
                    if (city.Length > 0)
                    {
                        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city.ToLower());
                    }
                }

                Console.WriteLine($"Entry: \'{entry}\' is invalid.  Please try again."); ;
            } while (true);
        }
        public string RequestState(string prompt)
        {
            string state;
            string entry;
            string regexState = @"^(A[LKZR]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[DLN]|K[SY]|LA|M[ADEINOST]|N[CDEJMSTVY]|O[HKR]|P[A]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";

            do
            {
                Console.Write($"{prompt}");
                entry = Console.ReadLine();
                state = entry.Trim().ToUpper();

                if (!string.IsNullOrWhiteSpace(state) && Regex.IsMatch(state, regexState))
                {
                    return state;
                }

                Console.WriteLine($"Entry: \'{entry}\' is invalid.  Entry must be a valid two-letter state abbreviation."); ;
            } while (true);
        }

        public string RequestZipCode(string prompt)
        {
            string zipCode;
            string entry;
            string regexZipCode = @"^\d{5}(-\d{4})?$";

            do
            {
                Console.Write($"{prompt}");
                entry = Console.ReadLine();
                zipCode = entry.Trim();

                if (!string.IsNullOrWhiteSpace(zipCode) && Regex.IsMatch(zipCode, regexZipCode))
                {
                    return zipCode;
                }

                Console.WriteLine($"Entry: \'{entry}\' is invalid.  Entry must be a 5-digit ZIP code or ZIP+4 code."); ;
            } while (true);
        }

        private string CleanMultiWordNumericString(string input)
        {
            // Step 1: Remove all non-alphanumeric characters except spaces
            string result = Regex.Replace(input, @"[^a-zA-Z0-9\s]", "");

            // Step 2: Replace multiple consecutive spaces with a single space
            result = Regex.Replace(result, @"\s+", " ");

            // Step 3: Trim leading and trailing spaces
            string output = result.Trim();

            return output;
        }

        private string CleanMultiWordAlphaString(string input)
        {
            // Step 1: Remove all non-alphanumeric characters except spaces
            string result = Regex.Replace(input, @"[^a-zA-Z\s]", "");

            // Step 2: Replace multiple consecutive spaces with a single space
            result = Regex.Replace(result, @"\s+", " ");

            // Step 3: Trim leading and trailing spaces
            string output = result.Trim();

            return output;
        }
    }
}
