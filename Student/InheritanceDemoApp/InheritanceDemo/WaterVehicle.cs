using System;

namespace InheritanceDemoApp
{
    public class WaterVehicle : Vehicle
    {
        public int Steer(int direction)
        {
            Console.WriteLine("Water vehicle steering right.");
            return 0;
        }
    }
}

