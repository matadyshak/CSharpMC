using System;

namespace InterfaceDemoApp
{
    public class Animal : IRun
    {
        public int Run()
        {
            Console.WriteLine("Depends on which kind of animal.");
            return 0;
        }
    }
}