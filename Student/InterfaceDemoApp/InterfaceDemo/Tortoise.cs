using System;

namespace InterfaceDemoApp
{
    public class Tortoise : Animal
    {
        public new int Run()
        {
            Console.WriteLine("I am a Tortoise and I can run the 40 yd dash in 1 hour 35 minutes and 2.1 seconds.");
            return 0;
        }
    }
}