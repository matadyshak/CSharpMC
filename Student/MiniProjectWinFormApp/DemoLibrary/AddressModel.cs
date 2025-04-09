using System.Globalization;
using System.Text.RegularExpressions;

namespace DemoLibrary
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
                value = value.Trim();
                // Match letters, numbers and single spaces
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$"))
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
                value = value.Trim();
                // For this property allow empty string
                if (string.IsNullOrEmpty(value))
                {
                    _addressLine2 = "";
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, "^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$"))
                    {
                        value = "";
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
                value = value.Trim().ToUpper();
                // 50 states and Washington, DC
                string regexState = @"^(A[LKZR]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[DLN]|K[SY]|LA|M[ADEINOST]|N[CDEJMSTVY]|O[HKR]|P[A]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, regexState))
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
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\d{5}(-\d{4})?$"))
                {
                    value = "";
                }

                _zipcode = value;
            }
        }

        public string ValidateAddressLine1(string entry)
        {
            string address1 = CleanMultiWordNumericString(entry);

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
            string address2 = CleanMultiWordNumericString(entry);

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

        private string CleanMultiWordNumericString(string input)
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
    }
}
