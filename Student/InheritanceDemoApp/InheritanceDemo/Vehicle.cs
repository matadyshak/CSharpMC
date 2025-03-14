using System;

namespace InheritanceDemoApp
{
    public class Vehicle
    {
        public int Start()
        {
            Console.WriteLine("Vehicle has started.");
            return 0;
        }
        public int Stop()
        {
            Console.WriteLine("Vehicle has stopped.");
            return 0;
        }
        public int Decellerate()
        {
            return 0;
        }
        public int Accelerate()
        {
            return 0;
        }
        public int ChangeGear()
        {
            return 0;
        }
    }
}

