using System;

namespace ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            try
            {
                DivideByZeroMethod();
                Console.WriteLine("After call to DivideByZeroMethod().");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("A divide by zero exception has occurred in Main()");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occurred in Main()");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("End of Main program.");
        }

        public static void DivideByZeroMethod()
        {
            int constant = 25;
            int quotient = 0;
            int i;

            for (i=-5; i<5; i++)
            {
                try
                {
                    quotient = constant / i;
                    Console.WriteLine($"quotient: {quotient}, i: {i}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("A divide by zero exception has occurred in DivideByZeroMethod()");
                    Console.WriteLine(ex.Message);
                    throw new DivideByZeroException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception has occurred in DivideByZeroMethod().");
                    Console.WriteLine(ex.Message);
                }
            }
            return;
        }
    }
}
