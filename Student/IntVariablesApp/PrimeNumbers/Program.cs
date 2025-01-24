namespace PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bPrime = true;
            int numerator = 0;
            int denominator = 0;
            int prevPrime = 2;
            int currPrime = 3;
            int maxBetweenPrimes = 1;
            int primeCount = 0;

            Console.WriteLine("This will display all prime numbers from 2 to N.");
            Console.Write("Enter a positive integer for N: ");
            int maxNumerator = int.Parse(Console.ReadLine());
            //Console.WriteLine("2");

            for (numerator = 3; numerator <= maxNumerator; numerator += 2)
            {
                int maxDenominator = (int) Math.Sqrt(numerator) + 1;
                for (denominator = 3; denominator <= maxDenominator; denominator++)
                {
                    bPrime = true;
                    if (numerator % denominator == 0)
                    {
                        bPrime = false;
                        break;
                    }
                }

                if (bPrime == true)
                {
                    primeCount++;
                    prevPrime = currPrime;
                    currPrime = numerator;
                    if(( currPrime - prevPrime - 1) > maxBetweenPrimes)
                    {
                        maxBetweenPrimes  = currPrime - prevPrime - 1; 
                        Console.WriteLine($"Previous Prime# {prevPrime} Current Prime# {currPrime} Stretch of No Prime#'s: {currPrime - prevPrime - 1} Total Prime#'s {primeCount}");
                    }
                    //Console.WriteLine(numerator.ToString());
                }
            }
        }
    }
}

/*
The expression (int) Math.Sqrt(numerator) in C# will result in the whole part of the number, 
not a rounded number. This is because the (int) cast truncates the decimal part of the result,
effectively giving you the integer part of the square root.

If you need the result to be rounded to the nearest integer, you can use 
Math.Round(Math.Sqrt(numerator)) instead.
*/