using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            bool isValid;
            string numberText;
            int number;
            int i;
            int total = 0;

            do
            {
                Console.Write("Enter an integer: ");
                numberText = Console.ReadLine().Trim();
                isValid = int.TryParse(numberText, out number);
            } while (!isValid);

            for (i = 0; i < 10; i++)
            {
                total += (5 * number);
                Console.WriteLine(total);
            }

            return;
        }
    }
}
