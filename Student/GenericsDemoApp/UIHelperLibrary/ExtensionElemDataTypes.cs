using System;

namespace UIHelperLibrary
{
    public static class ExtensionElemDataTypes
    {
        public static string RequestString(this string message)
        {
            string output = "";
            bool valid = false;

            while (valid == false)
            {
                Console.Write(message);
                output = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(output) == false)
                {
                    valid = true;
                }
            }
            return output;
        }

        private static int RequestInt(this string message, bool useMinMax, int minValue = 0, int maxValue = 0)
        {
            int output = 0;
            bool validInt = false;
            bool validRange = false;
            string entry;

            while ((validInt == false) || (validRange == false))
            {
                Console.Write(message);
                entry = Console.ReadLine();
                try
                {
                    validInt = int.TryParse(entry, out output);
                    validRange = true;
                    if (useMinMax)
                    {
                        validRange = ((output >= minValue) && (output <= maxValue));
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was not a valid integer value.");
                }
            }
            return output;
        }

        public static int RequestInt(this string message)
        {
            return message.RequestInt(false);
        }

        public static int RequestInt(this string message, int minValue, int maxValue)
        {
            return message.RequestInt(true, minValue, maxValue);
        }

        private static double RequestDouble(this string message, bool useMinMax, double minValue = 0.0, double maxValue = 0.0)
        {
            bool validDouble = false;
            bool validRange = false;
            string entry;
            double output = 0.0;

            while ((validDouble == false) || (validRange == false))
            {
                Console.Write(message);
                entry = Console.ReadLine();
                try
                {
                    validDouble = double.TryParse(entry, out output);
                    validRange = true;
                    if (useMinMax)
                    {
                        validRange = ((output >= minValue) && (output <= maxValue));
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was not a valid double-precision floating point value.");
                }
            }
            return output;
        }

        public static double RequestDouble(this string message)
        {
            return message.RequestDouble(false);
        }

        public static double RequestDouble(this string message, double minValue, double maxValue)
        {
            return message.RequestDouble(true, minValue, maxValue);
        }

        private static decimal RequestDecimal(this string message, bool useMinMax, decimal minValue = 0.0m, decimal maxValue = 0.0m)
        {
            bool validDecimal = false;
            bool validRange = false;
            string entry;
            decimal output = 0.0m;

            while ((validDecimal == false) || (validRange == false))
            {
                Console.Write(message);
                entry = Console.ReadLine();
                try
                {
                    validDecimal = decimal.TryParse(entry, out output);
                    validRange = true;
                    if (useMinMax)
                    {
                        validRange = ((output >= minValue) && (output <= maxValue));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was not a valid decimal floating point value.");
                }
            }
            return output;
        }

        public static decimal RequestDecimal(this string message)
        {
            return message.RequestDecimal(false);
        }

        public static decimal RequestDecimal(this string message, decimal minValue, decimal maxValue)
        {
            return message.RequestDecimal(true, minValue, maxValue);
        }
    }
}

