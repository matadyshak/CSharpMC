using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            try
            {
                RunsALot();
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"ArithmeticException occurred in RunsALot method.");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static void RunsALot()
        {
            long total = 0;

            for (int i = 1; i <= 100; i++)
            {
                if (i == 73)
                {
                    Console.WriteLine($"i: {i}, total: {total}");
                    throw new ArithmeticException();
                    //Nothing after this point runs
                    Console.WriteLine($"i: {i}, total: {total}");
                }
                total += i;
            }

            Console.WriteLine($"The total is {total}");
        }
    }
}
