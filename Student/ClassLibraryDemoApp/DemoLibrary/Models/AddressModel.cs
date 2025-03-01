using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DemoLibrary.Models
{
    public class AddressModel
    {
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _state;
        private string _zipCode;

        // These are static and readonly and are initialized only once and cannot be changed
        // They can be used to call methods for instantiated object
        // All instances share the same static object

        // private static readonly Regex multiWordAlphaNumericMatchRegex = new Regex(@"^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$");
        private static readonly Regex multiWordAlphaRegex = new Regex(@"[^a-zA-Z\s]");
        private static readonly Regex multiWordAlphaNumericRegex = new Regex(@"[^a-zA-Z0-9\s]");
        private static readonly Regex multiSpacesRegex = new Regex(@"\s+");
        private static readonly Regex zipCodeMatchRegex = new Regex(@"^\d{5}(-\d{4})?$");
        private static readonly Regex stateCodeReplaceRegex = new Regex(@"[^a-zA-Z]");
        private static readonly Regex stateCodeMatchRegex =
          new Regex(@"^(A[LKZR]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[DLN]|K[SY]|LA|M[ADEINOST]|N[CDEJMSTVY]|O[HKR]|P[A]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$");

        public int TryValidateMultiWordAlphaNumeric(string entry, out string output)
        {
            // Use this for addressLine1, addressLine2
            string result = entry.Trim();

            if (!string.IsNullOrWhiteSpace(result))
            {
                //What about an empty string? Returns true
                // Step 1: Remove all non-alphanumeric characters except spaces
                result = multiWordAlphaNumericRegex.Replace(result, "");

                // Step 2: Replace multiple consecutive spaces with a single space
                result = multiSpacesRegex.Replace(result, " ");

                if (result.Length > 0)
                {
                    output = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.ToLower());
                    // success
                    return 0;
                }
            }
            //failure 
            output = "";
            return 1;
        }

        public int TryValidateMultiWordAlpha(string entry, out string output)
        {
            // Use this for city
            string result = entry.Trim();

            if (!string.IsNullOrWhiteSpace(result))
            {
                // Step 1: Remove all non-alpha characters except spaces
                result = multiWordAlphaRegex.Replace(result, "");

                // Step 2: Replace multiple consecutive spaces with a single space
                result = multiSpacesRegex.Replace(result, " ");

                if (result.Length > 0)
                {
                    output = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.ToLower());
                    // success
                    return 0;
                }
            }
            //failed 
            output = "";
            return 1;
        }

        public int TryValidateStateCode(string entry, out string output)
        {
            // Use this for state
            string result = entry.Trim().ToUpper();

            if (!string.IsNullOrWhiteSpace(result))
            {
                // Step 1: Remove all non-alpha characters
                result = stateCodeReplaceRegex.Replace(result, "");

                if (result.Length > 0)
                {
                    if (stateCodeMatchRegex.IsMatch(result))
                    {
                        output = result;
                        // Success
                        return 0;
                    }
                }
            }
            //failed 
            output = "";
            return 1;
        }

        public int TryValidateZipCode(string entry, out string output)
        {
            // Use this for Zip code
            string result = entry.Trim();

            if (!string.IsNullOrWhiteSpace(result))
            {
                if (zipCodeMatchRegex.IsMatch(result))
                {
                    output = result;
                    // Success
                    return 0;
                }
            }
            //failed 
            output = "";
            return 1;
        }

        public string AddressLine1
        {
            get { return _addressLine1; }
            set
            {
                int status = TryValidateMultiWordAlphaNumeric(value, out string validatedAddressLine1);
                if (status == 0)
                {
                    _addressLine1 = validatedAddressLine1;
                }
                else
                {
                    throw new ArgumentException("Invalid entry. Only numbers and letters are allowed.");
                }
            }
        }

        public string AddressLine2
        {
            get { return _addressLine2; }
            set
            {
                TryValidateMultiWordAlphaNumeric(value, out string validatedAddressLine2);
                //Address Line 2 is optional and may be omitted
                _addressLine2 = validatedAddressLine2;
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                int status = TryValidateMultiWordAlpha(value, out string validatedCity);
                if (status == 0)
                {
                    _city = validatedCity;
                }
                else
                {
                    throw new ArgumentException("Invalid entry. Only letters and can have multiple words.");
                }
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                int status = TryValidateStateCode(value, out string validatedStateCode);
                if (status != 0)
                {
                    throw new ArgumentException("Invalid entry. Only valid U.S. state abbreviations (or DC) are allowed.");
                }

                _state = validatedStateCode;
            }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                int status = TryValidateZipCode(value, out string validatedZipCode);
                if (status != 0)
                {
                    throw new ArgumentException("Invalid entry. Only 5-digit ZIP codes or 9-digit ZIP+4 codes are allowed.");
                }

                _zipCode = validatedZipCode;
            }
        }
    }
}
