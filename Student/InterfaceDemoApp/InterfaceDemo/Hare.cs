using System;

namespace InterfaceDemoApp
{
    public class Hare : Animal
    {
        public new int Run()
        {
            Console.WriteLine("I am a Hare and I can run the 40 yd dash in 7.0 seconds.");
            return 0;
        }
    }
}