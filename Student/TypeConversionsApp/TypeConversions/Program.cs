using System;
using System.Drawing;
using System.Globalization;

namespace TypeConversions
{
    internal class Program
    {
        static void Main()
        {
            bool isValid = false;
            string? ageText = string.Empty;
            string? herAgeText = string.Empty;
            string? hisAgeText = string.Empty;
            int age = 0;
            int herAge = 0;
            int hisAgeHex = 0;

            /*
            byte: Min = 0, Max = 255, Size = 1 
            ushort: Min = 0, Max = 65535, Size = 2
            uint: Min = 0, Max = 4294967295, Size = 4
            ulong: Min = 0, Max = 18446744073709551615, Size = 8

            sbyte: Min = -128, Max = 127, Size = 1
            short: Min = -32768, Max = 32767, Size = 2
            int: Min = -2147483648, Max = 2147483647, Size = 4
            long: Min = -9223372036854775808, Max = 9223372036854775807, Size = 8

            float: Min = -3.4028235E+38, Max = 3.4028235E+38, Size = 4
            double: Min = -1.7976931348623157E+308, Max = 1.7976931348623157E+308, Size = 8
            decimal: Min = -79228162514264337593543950335, Max = 79228162514264337593543950335, Size = 16
            */

            // 0xDEAD FACE BEEF F00D
            byte myByte     = (byte)0x0d;
            ushort myUShort = (ushort)((0xF0 << 8) + myByte);              // < 0x7fffffff so does not sign extend when promoted to int
            uint myUInt     = (uint)((0xBEEF << 16) + myUShort);           // < 0x7fffffff so does not sign extend when promoted to int

//          ulong myULong   = (ulong)((0xDEADFACE << 32) + myUInt);        // > 0x7fffffff sign extends! Error!  0x19d9deadb

            ulong myULong   = (ulong)((0xDEADFACEul << 32) + myUInt);      // 0xDEADFACEBEEFF00D

            Console.WriteLine("Converting from byte to ushort to uint to ulong: ");
            Console.WriteLine($"myByte  : 0x{myByte.ToString("X2")}");     // 0x0D
            Console.WriteLine($"myUShort: 0x{myUShort.ToString("X4")}");   // 0xF00D
            Console.WriteLine($"myUInt  : 0x{myUInt.ToString("X8")}");     // 0xBEEFF00D
            Console.WriteLine($"myULong : 0x{myULong.ToString("X16")}");   // 0xDEADFACEBEEFF00D

            Console.WriteLine("Smallest values for float, double, decimal: ");
            float mySmallestFloat = 1.4E-45f;  // Exp 2**  +/- 127 , 32 bits, Mantissa 23 bits, 7 decimal digits
            double mySmallestDouble = 4.9E-324d; // Exp 2**  +/- 1023, 64 bits, Mantissa 52 bits, 15-16 decimal digits
            decimal mySmallestDecimal = 1.0E-28M;  // Exp 10** +/- 28,  128 bits, Mantissa 96 bits, 28-29 decimal digits
            Console.WriteLine($"mySmallestFloat: {mySmallestFloat:E7} mySmallestDouble: {mySmallestDouble:E15} mySmallestDecimal: {mySmallestDecimal:E28}");

            Console.WriteLine("Largest values for float, double, decimal: ");
            float myLargestFloat   = 3.4028235E+38f;
            double  myLargestDouble  = 1.7976931348623157E+308d;
            decimal myLargestDecimal  = 7.9228162514264337593543950335E+28M;
            Console.WriteLine($"myLargestFloat: {myLargestFloat:E7} myLargestDouble: {myLargestDouble:E15} myLargestDecimal: {myLargestDecimal:E28}");

            string octalString = "75";
            int decimalNumber = Convert.ToInt32(octalString, 8);
            Console.WriteLine($"Octal string 75 is {decimalNumber} decimal."); // Outputs 61

            // Test exponent of 10 ** 6 for float, double, decimal
            float testFloat = 1.123456E+06f;
            double testDouble = (double)testFloat;
            decimal testDecimal = (decimal)testFloat;
            Console.WriteLine($"testFloat: {testFloat:E7} testDouble: {testDouble:E15} testDecimal: {testDecimal:E28}");

            // Test exponent of 10 ** 30 for float, double, decimal
            testDouble = 1.7976931348623157E+30d;
            testFloat = (float)testDouble;
            //            testDecimal = (decimal)testDouble; // Error: 1.7976931348623157E+30d is too large for a decimal
            Console.WriteLine($"testDouble: {testDouble:E15} testFloat: {testFloat:E7}");

            // Test exponent of 10 ** 40 for float, double, decimal
            testDouble = 1.7976931348623157E+40d;
            //            testFloat = (float)testDouble; // Error: 1.7976931348623157E+40d is too large for a float
            //            testDecimal = (decimal)testDouble; // Error: 1.7976931348623157E+40d is too large for a decimal
            Console.WriteLine($"testDouble: {testDouble:E15}");


            // Test precision of 7.9228162514264337593543950335 for float, double, decimal
            // These will not crash but truncate least significant digits as needed to fit
            testDecimal = 7.9228162514264337593543950335E+28M;
            testDouble = (double)testDecimal; // Error: too precise for a double
            testFloat = (float)testDecimal; // Error: too precise for a float
            Console.WriteLine($"testDecimal: {testDecimal:E28} testDouble: {testDouble:E15} testFloat: {testFloat:E7}");

            Console.WriteLine("\nParsing decimal and hexidecimal int values: ");
            //Using int.Parse() with try-catch
            isValid = false;
            while (!isValid)
            {
                Console.Write("What is her age? ");
                herAgeText = Console.ReadLine();
                try
                {
                    // Throws an exception if the conversion fails
                    herAge = int.Parse(herAgeText);
                    // On exception the next line does not execute
                    isValid = true;
                }
                catch (Exception ex)
                {
                    // Example: "The input string 'eight' was not in a correct format."
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Her age is {herAge}.");

            //Using TryParse() without try-catch
            isValid = false;
            while (!isValid)
            {
                Console.Write("What is your age? ");
                ageText = Console.ReadLine();
                //Does not throw an exception but returns bool for valid or !valid
                isValid = int.TryParse(ageText, out age);
                if (!isValid)
                {
                    Console.WriteLine($"The input string \'{ageText}\' was not in a correct format.");
                }
            }
            //age is out of scope here if declared in the tryParse statement
            Console.WriteLine($"Your age is {age}.");

            //Using TryParse() without try-catch to read a hex value
            isValid = false;
            while (!isValid)
            {
                Console.Write("What is his age in hex? ");
                //Strip away 0x
                hisAgeText = Console.ReadLine().ToLower().Replace("0x", "");
                isValid = int.TryParse(hisAgeText, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hisAgeHex);
                if (!isValid)
                {
                    Console.WriteLine($"The input string \'{hisAgeText}\' was not in a correct format.");
                }
            }
            Console.WriteLine($"His age in hex is {hisAgeHex.ToString("x")}");
        }
    }
}
