using System;

namespace InheritanceDemoApp
{
    public class Car : LandVehicle
    {
        public int Speed { get; set; }
        public int LeftOrRight { get; set; }

        public int TurnSignal(int leftOrRight)
        {
            Console.WriteLine("Car turn signal to right");
            return 0;
        }
        public int ChangeLane(int leftOrRight)
        {
            return 0;
        }
        public int SpeedControl(int speed)
        {
            return 0;
        }
    }
}

