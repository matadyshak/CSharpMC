using System;

namespace InterfaceDemoApp
{
    public class Person : IRun
    {
        public int Run()
        {
            Console.WriteLine("I am a person and I can run the 40 yd dash in 4.3 seconds.");
            return 0;
        }
    }
}