using System.Collections.Generic;

namespace InheritanceDemoApp
{
    class Program
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            Car car = new Car();
            Motorcycle motorcycle = new Motorcycle();
            Boat boat = new Boat();

            vehicles.Add(car);
            vehicles.Add(motorcycle);
            vehicles.Add(boat);
        }
    }

    public class Vehicle
    {
        public int Start()
        {
            return 0;
        }
        public int Stop()
        {
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

    public class LandVehicle : Vehicle
    {
        public int AscendHill()
        {
            return 0;
        }
        public int DecendHill()
        {
            return 0;
        }
        public int Steer(int direction)
        {
            return 0;
        }
    }

    public class Car : LandVehicle
    {
        public int Speed { get; set; }
        public int LeftOrRight { get; set; }

        public int TurnSignal(int leftOrRight)
        {
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

    public class Motorcycle : LandVehicle
    {
        public int ChangeGear(int UpDown)
        {
            return 0;
        }
    }

    public class WaterVehicle : Vehicle
    {
        public int Steer(int direction)
        {
            return 0;
        }
    }

    public class Boat : WaterVehicle
    {
        public int PullSkiers()
        {
            return 0;
        }
        public int GoFishing()
        {
            return 0;
        }
    }
}

