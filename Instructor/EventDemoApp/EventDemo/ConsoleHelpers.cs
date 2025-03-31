using System;

namespace EventDemo
{
    public static class ConsoleHelpers
    {
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }
    }
}
