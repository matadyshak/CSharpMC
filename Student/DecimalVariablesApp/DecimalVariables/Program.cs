using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Net.NetworkInformation;

namespace DecimalVariables
{
    /*
    In C#, the decimal data type uses 128 bits, which are allocated as follows: 
    Sign bit: 1 bit
    Exponent: 7 bits
    Mantissa(significand): 112 bits
    Unused: 8 bits(These are reserved bits, set to zero)
    Here’s how it all fits together:
    The sign bit determines the positive or negative value of the number.
    The exponent is biased by 96, which means that the actual exponent value is the stored exponent minus 96.
    The mantissa holds the significant digits of the number and is a 96-bit integer.
    This structure allows the decimal type to represent numbers with a high degree of precision and a moderate range, 
    making it especially useful for financial and monetary calculations where exact decimal representation is crucial.
    */

    /* Output using decimal variables:
    Future Value: $1,628.89
    Present Value: $1,000.00
    Future Value of Annuity: $1,257.79
    Present Value of Annuity: $772.17
    Interest Rate: 5.00%
    Interest Rate of Annuity: 5.00%
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            decimal principal = 1000m; // Principal amount
            decimal rate = 0.05m; // Interest rate (5%)
            int years = 10; // Number of years

            // Future Value
            decimal futureValue = FutureValue(principal, rate, years);
            Console.WriteLine($"Future Value: {futureValue:C}");

            // Present Value
            decimal presentValue = PresentValue(futureValue, rate, years);
            Console.WriteLine($"Present Value: {presentValue:C}");

            // Future Value of Annuity
            decimal annuityPayment = 100m; // Annual payment
            decimal futureValueAnnuity = FutureValueAnnuity(annuityPayment, rate, years);
            Console.WriteLine($"Future Value of Annuity: {futureValueAnnuity:C}");

            // Present Value of Annuity
            decimal presentValueAnnuity = PresentValueAnnuity(futureValueAnnuity, rate, years);
            Console.WriteLine($"Present Value of Annuity: {presentValueAnnuity:C}");

            // Interest Rate
            decimal calculatedRate = InterestRate(futureValue, principal, years);
            Console.WriteLine($"Interest Rate: {calculatedRate:P}");

            // Interest Rate of Annuity
            decimal calculatedRateAnnuity = InterestRateAnnuityIncremental(futureValueAnnuity, annuityPayment, years);
            Console.WriteLine($"Interest Rate of Annuity: {calculatedRateAnnuity:P}");
        }

        static decimal FutureValue(decimal presentValue, decimal rate, int years)
        {
            decimal futureValue = presentValue * (decimal)Math.Pow((double)(1 + rate), years);
            return futureValue;
        }

        static decimal PresentValue(decimal futureValue, decimal rate, int years)
        {
            decimal presentValue = futureValue / (decimal)Math.Pow((double)(1 + rate), years);
            return presentValue;
        }

        static decimal FutureValueAnnuity(decimal payment, decimal rate, int years)
        {
            decimal futureValue = payment * ((decimal)Math.Pow((double)(1 + rate), years) - 1) / rate;
            return futureValue;
        }

        static decimal PresentValueAnnuity(decimal futureValue, decimal rate, int years)
        {
            decimal presentValue = futureValue / (decimal)Math.Pow((double)(1 + rate), years);
            return presentValue;
        }

        static decimal InterestRate(decimal futureValue, decimal presentValue, int years)
        {
            decimal rate = (decimal)Math.Pow((double)(futureValue / presentValue), 1.0 / years) - 1;
            return rate;
        }
        static decimal InterestRateAnnuityIncremental(decimal futureValue, decimal payment, int years)
        {
            {
                decimal tolerance = 0.0001M;  // Tolerance level for convergence
                decimal increment = 0.0001M;  // Increment for adjusting guess
                decimal guess = 0.05M;       // Initial guess for the interest rate
                decimal rate = guess;
                decimal calculatedFutureValue;

                while (true)
                {
                    calculatedFutureValue = payment * ((decimal)(Math.Pow(1.0D + (double)rate, (double)years)) - 1.0M) / rate;

                    // Abs has overload for decimal type
                    if (Math.Abs(calculatedFutureValue - futureValue) < tolerance)
                    {
                        break;
                    }

                    // Adjust the guess based on whether we need a higher or lower rate
                    if (calculatedFutureValue < futureValue)
                    {
                        rate += increment;
                    }
                    else
                    {
                        rate -= increment;
                    }
                }

                return rate;
            }
        }
    }
}