using System;

namespace ConsoleUI
{
    public static class CalculateData
    {
        //Would not allow use of operator as a variable (operator is a reserved keyword)
        public static double Operate(double x, string operater, double y)
        {
            double output = 0.0d;

            switch (operater)
            {
                case "+":
                    output = x + y;
                    break;

                case "-":
                    output = x - y;
                    break;

                case "*":
                    output = x * y;
                    break;

                case "/":
                    try
                    {
                        output = x / y;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("An exception has occurred.");
                        Console.WriteLine(ex.Message);

                        if (x < 0.0d)
                        {
                            output = -1.0d * double.MaxValue;
                        }
                        else
                        {
                            output = double.MaxValue;
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Arithmetic operator \'{operater}\' is not valid.  Setting result to 0.");
                    output = 0;
                    break;
            }
            return output;
        }
    }
}
