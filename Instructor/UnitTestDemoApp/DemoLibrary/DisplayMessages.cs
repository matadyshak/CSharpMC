using System;
using System.Collections.Generic;
using System.Text;

// Red, Green, Refactor

namespace DemoLibrary
{
    public class DisplayMessages
    {
        public string Greeting(string firstName, int hourOfTheDay)
        {
            string output = "";
            // DataAccess da = new DataAccess();
            // da.WriteToDB("MyData");

            if (hourOfTheDay < 5)
            {
                output = $"Go to bed { firstName }";
            }
            else if (hourOfTheDay < 12)
            {
                output = $"Good morning { firstName }";
            }
            else if (hourOfTheDay < 18)
            {
                output = $"Good afternoon { firstName }";
            }
            else
            {
                output = $"Good evening { firstName }";
            }

            return output;
        }
    }
}
