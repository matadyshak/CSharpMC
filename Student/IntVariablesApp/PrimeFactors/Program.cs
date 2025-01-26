namespace PrimeFactors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numerator = 0;
            int denominator = 0;
            bool bPrime = true;
            List<int> primeNumbers = new List<int>();
            List<int> primeFactors = new List<int>();
            primeNumbers.Add(2);
            primeNumbers.Add(3);
            primeNumbers.Add(5);
            primeNumbers.Add(7);
            
            Console.WriteLine("This will display all the prime factors of a number N.");
            Console.Write("Enter a positive integer for N: ");
            int number = int.Parse(Console.ReadLine());
            int maxNumerator = number;

            for (numerator = 11; numerator <= maxNumerator; numerator += 2)
            {
                int maxDenominator = (int)Math.Sqrt(numerator) + 1;
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
                    primeNumbers.Add(numerator);
                }
            }

            // Now test the number against the prime factor array
            // If number is divisible by the prime factor then store the prime factor in primeFactor array
            // Divide number by the prime factor
            // If the quotient is 1 then break
            // Else start the prime number array over again

            while (number > 1)
            {
                foreach (int prime in primeNumbers)
                {
                    if (number % prime == 0)
                    {
                        primeFactors.Add(prime);
                        number /= prime;
                        break;
                    }
                }
            }
            
            
            foreach (int factor in primeFactors)
            {
                Console.Write($"{factor} ");
            }
        }
    }
}
