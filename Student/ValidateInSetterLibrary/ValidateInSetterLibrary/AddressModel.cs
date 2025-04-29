using System.Globalization;
using System.Text.RegularExpressions;

namespace ValidateInSetterLibrary
{
    public class AddressModel
    {
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _state;
        private string _zipcode;

        public string AddressLine1
        {
            get { return _addressLine1; }
            set
            {
                value = ValidateAddressLine1(value);
                // Match letters, numbers and single spaces
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "";
                }
                value = value.Trim();

                if (!Regex.IsMatch(value, "^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$"))
                {
                    value = "";
                }

                _addressLine1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        public string AddressLine2
        {
            get { return _addressLine2; }
            set
            {
                value = ValidateAddressLine2(value);
                // For this property allow empty string
                if (string.IsNullOrEmpty(value))
                {
                    value = "";
                }
                value = value.Trim();

                if (!Regex.IsMatch(value, "^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$"))
                {
                    value = "";
                }
                _addressLine2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                value = ValidateCity(value);
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "";
                }
                value = value.Trim();
                if (!Regex.IsMatch(value, "^[A-Za-z ]+$"))
                {
                    value = "";
                }
                _city = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                value = ValidateState(value);
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "";
                }
                value = value.Trim().ToUpper();
                // 50 states and Washington, DC
                string regexState = @"^(A[LKZR]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[DLN]|K[SY]|LA|M[ADEINOST]|N[CDEJMSTVY]|O[HKR]|P[A]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
                if (!Regex.IsMatch(value, regexState))
                {
                    value = "";
                }

                _state = value;
            }
        }
        public string Zipcode
        {
            get { return _zipcode; }
            set
            {
                value = ValidateZipcode(value);
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "";
                }

                value = value.Trim();
                if (!Regex.IsMatch(value, @"^\d{5}(-\d{4})?$"))
                {
                    value = "";
                }
                _zipcode = value;
            }
        }

        public string ValidateAddressLine1(string entry)
        {
            string address1 = CleanMultiWordAlphaNumericString(entry);

            if (!string.IsNullOrWhiteSpace(address1))
            {
                if (address1.Length > 0)
                {
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address1.ToLower());
                }
            }
            return "";
        }
        public string ValidateAddressLine2(string entry)
        {
            string address2 = CleanMultiWordAlphaNumericString(entry);

            if (!string.IsNullOrWhiteSpace(address2))
            {
                if (address2.Length > 0)
                {
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address2.ToLower());
                }
            }
            return "";
        }
        public string ValidateCity(string entry)
        {
            string city = CleanMultiWordAlphaString(entry);

            if (!string.IsNullOrWhiteSpace(city))
            {
                if (city.Length > 0)
                {
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city.ToLower());
                }
            }
            return "";
        }
        public string ValidateState(string entry)
        {
            string regexState = @"^(A[LKZR]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[DLN]|K[SY]|LA|M[ADEINOST]|N[CDEJMSTVY]|O[HKR]|P[A]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
            string state = entry.Trim().ToUpper();
            state = CleanSingleWordAlphaString(state);

            if (!string.IsNullOrWhiteSpace(state) && Regex.IsMatch(state, regexState))
            {
                return state;
            }
            return "";
        }

        public string ValidateZipcode(string entry)
        {
            string regexZipcode = @"^\d{5}(-\d{4})?$";
            string zipcode = entry.Trim();

            if (!string.IsNullOrWhiteSpace(zipcode) && Regex.IsMatch(zipcode, regexZipcode))
            {
                return zipcode;
            }
            return "";
        }

        private string CleanMultiWordAlphaNumericString(string input)
        {
            // Step 1: Remove all non-alphanumeric characters except spaces
            string result = Regex.Replace(input, @"[^a-zA-Z0-9\s]", "");

            // Step 2: Replace multiple consecutive spaces with a single space
            result = Regex.Replace(result, @"\s+", " ");

            // Step 3: Trim leading and trailing spaces
            //string output = result.Trim();

            return result;
        }

        private string CleanMultiWordAlphaString(string input)
        {
            // Step 1: Remove all non-alphanumeric characters except spaces
            string result = Regex.Replace(input, @"[^a-zA-Z\s]", "");

            // Step 2: Replace multiple consecutive spaces with a single space
            result = Regex.Replace(result, @"\s+", " ");

            // Step 3: Trim leading and trailing spaces
            //string output = result.Trim();

            return result;
        }
        private string CleanSingleWordAlphaString(string input)
        {
            // Step 1: Remove all non-alpha characters
            string result = Regex.Replace(input, @"[^a-zA-Z]", "");

            return result;
        }
    }
}
