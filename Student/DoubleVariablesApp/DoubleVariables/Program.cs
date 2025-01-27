using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;

namespace DoubleVariables
{

    /*

    The double data type in C# is a 64-bit IEEE 754 double-precision floating-point number. The bits are allocated as follows:
    Sign bit: 1 bit
    Exponent: 11 bits
    Mantissa (significand): 52 bits

    Here’s a breakdown of how these bits are used:
    Sign bit (1 bit):
    0: Positive number
    1: Negative number

    Exponent (11 bits):
    The exponent is stored in a biased form, with a bias of 1023. This means:
    Actual exponent = Stored exponent − 1023
    
    Mantissa(52 bits) :
    The mantissa represents the significant digits of the number.

    Example Bit Representation
    Let’s take an example bit pattern to illustrate:
    Sign bit: 0 (positive)
    Exponent: 10000000101 (binary for 1029)
    Mantissa: 1011001100110011001100110011001100110011001100110011
    Converting to a Double Value
    Extract the sign:
    Sign bit = 0, so the number is positive.
    Calculate the actual exponent:
    Stored exponent = 1029
    Actual exponent = 1029 - 1023 = 6
    Convert the mantissa to decimal:
    Assuming the implicit leading 1, the mantissa in binary is 1.1011001100110011001100110011001100110011001100110011
    In decimal, this is approximately 1.6999998
    Combine the components:
    The double value is 
    1.6999998 × 2 ** 6 ≈ 108.7999876.

    */

    /*
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
            double principal = 1000d; // Principal amount
            double rate = 0.05d; // Interest rate (5%)
            int years = 10; // Number of years

            // Future Value
            double futureValue = FutureValue(principal, rate, years);
            Console.WriteLine($"Future Value: {futureValue:C}");

            // Present Value
            double presentValue = PresentValue(futureValue, rate, years);
            Console.WriteLine($"Present Value: {presentValue:C}");

            // Future Value of Annuity
            double annuityPayment = 100d; // Annual payment
            double futureValueAnnuity = FutureValueAnnuity(annuityPayment, rate, years);
            Console.WriteLine($"Future Value of Annuity: {futureValueAnnuity:C}");

            // Present Value of Annuity
            double presentValueAnnuity = PresentValueAnnuity(futureValueAnnuity, rate, years);
            Console.WriteLine($"Present Value of Annuity: {presentValueAnnuity:C}");

            // Interest Rate
            double calculatedRate = InterestRate(futureValue, principal, years);
            Console.WriteLine($"Interest Rate: {calculatedRate:P}");

            // Interest Rate of Annuity Incremental
            double calculatedRateAnnuity = InterestRateAnnuityIncremental(futureValueAnnuity, annuityPayment, years);
            Console.WriteLine($"Interest Rate of Annuity: {calculatedRateAnnuity:P}");
        }
        static double FutureValue(double presentValue, double rate, int years)
        {
            double futureValue = presentValue * (double)Math.Pow((double)(1 + rate), years);
            return futureValue;
        }

        static double PresentValue(double futureValue, double rate, int years)
        {
            double presentValue = futureValue / (double)Math.Pow((double)(1 + rate), years);
            return presentValue;
        }

        static double FutureValueAnnuity(double payment, double rate, int years)
        {
            double futureValue = payment * ((double)Math.Pow((double)(1 + rate), years) - 1) / rate;
            return futureValue;
        }

        static double PresentValueAnnuity(double futureValue, double rate, int years)
        {
            double presentValue = futureValue / (double)Math.Pow((double)(1 + rate), years);
            return presentValue;
        }

        static double InterestRate(double futureValue, double presentValue, int years)
        {
            double rate = (double)Math.Pow((double)(futureValue / presentValue), 1.0 / years) - 1;
            return rate;
        }
        static double InterestRateAnnuityIncremental(double futureValue, double payment, int years)
        {
            {
                double tolerance = 0.0001;  // Tolerance level for convergence
                double guess = 0.08;        // Initial guess for interest rate
                double increment = 0.0001;  // Increment for adjusting guess
                double rate = guess;
                double calculatedFutureValue;

                while (true)
                {
                    calculatedFutureValue = payment * (Math.Pow(1 + rate, years) - 1) / rate;

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
