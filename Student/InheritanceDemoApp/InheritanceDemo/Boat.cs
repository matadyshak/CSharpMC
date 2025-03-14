using System;

namespace InheritanceDemoApp
{
    public class Boat : WaterVehicle
    {
        public int PullSkiers()
        {
            Console.WriteLine("Boat pulling water skiers.");
            return 0;
        }
        public int GoFishing()
        {
            return 0;
        }
    }
}

