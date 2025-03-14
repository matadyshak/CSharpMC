// See https://aka.ms/new-console-template for more information

void GeneratePrimeNumbers()
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

GeneratePrimeNumbers();