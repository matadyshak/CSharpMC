using System;

namespace InheritanceDemoApp
{
    public class LandVehicle : Vehicle
    {
        public int AscendHill()
        {
            Console.WriteLine("LandVehicle is ascending hill");
            return 0;
        }
        public int DecendHill()
        {
            Console.WriteLine("LandVehicle is decending hill");
            return 0;
        }
        public int Steer(int direction)
        {
            return 0;
        }
    }
}

