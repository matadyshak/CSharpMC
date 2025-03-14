using System;

namespace InheritanceDemoApp
{
    public class Motorcycle : LandVehicle
    {
        public int ChangeGear(int UpDown)
        {
            Console.WriteLine("Motorcycle changing gear");
            return 0;
        }
    }
}

