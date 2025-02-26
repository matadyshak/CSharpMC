using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

Things demonstrated in this code:

X 1. auto property
  2. Explicit auto property
  3. private get
  4. private set
  5. Constructor call
  6. Overloaded constructors
  7. get method FullName which returns two properties
  8. set only
X 9. Validation code in set with exception
  10. Get only displays last 4 of SSN

*/

namespace ConsoleUI
{
    public class PersonModel
    {
        public string FirstName { private get; set; }
        public string LastName { get; private set; }

        private string _password;

        public string Password
        {
            set { _password = value; }
        }

        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }


        //public int Age { get; set; }
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value >= 0 && value < 126)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "Age needs to be in a valid range.");
                }
            }
        }

        //public string SSN { get; set; } // Social Security Number 123-45-6789
        private string _ssn;
        public string SSN
        {
            get
            {
                // 123-45-6789 - 11 - 4 = 7
                string output = "***-**-" + _ssn.Substring(_ssn.Length - 4);

                return output;
            }
            set { _ssn = value; }
        }

        public PersonModel()
        {

        }

        public PersonModel(string lastName)
        {
            LastName = lastName;
        }
    }
}
