using System;

namespace ConsoleUI
{
    public static class DisplayData
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Calculator Application!");
            Console.WriteLine("**************************************\n");
        }
        public static void DisplayResult(double x, string operater, double y, double result)
        {
            Console.WriteLine($"\nThe result of {x} {operater} {y} is {result}.");
            Console.WriteLine("Thank you for using the Calculator Application!");
        }
    }
}