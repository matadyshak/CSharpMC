amespace PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bPrime = true;
            uint numerator = 0;
            uint denominator = 0;

            //First prime numbers: 
            uint[] primeNumbers = [1, 2, 3, 5, 7, 11, 13, 17, 19, 23];

            foreach (uint primeNumber in primeNumbers)
            {
                Console.WriteLine(primeNumber.ToString());
            }

            //     for (uint numerator = 29; numerator < uint.MaxValue; numerator += 2)
            for (numerator = 29; numerator < 1000000u; numerator += 2)
            {
                uint maxDenominator = numerator / 2 + 2;
                for (denominator = 2; denominator <= maxDenominator; denominator++)
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
                    Console.WriteLine(numerator.ToString());
                }
                else
                {
                    Console.WriteLine($"{numerator} / {denominator} = {numerator / denominator}");
                }
            }
        }
    }
}


    static void Main()
{
    Console.Write("Enter a positive integer: ");
    int number = int.Parse(Console.ReadLine());

    bool isPrime = true;

    if (number <= 1)
    {
        isPrime = false;
    }
    else
    {
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }
    }

    if (isPrime)
    {
        Console.WriteLine($"{number} is a prime number.");
    }
    else
    {
        Console.WriteLine($"{number} is not a prime number.");
    }
}
