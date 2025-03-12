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


/*
Vehicles come in many forms, each designed for specific purposes. Here are some common types:


Land Vehicles

Cars: Personal transportation for individuals or small groups.

Trucks: Used for transporting goods and materials.

Motorcycles: Two-wheeled vehicles for personal transport.

Buses: Public transportation for larger groups of people.

Trains: Rail-based transportation for passengers and cargo.


Water Vehicles

Boats: Small to medium-sized watercraft for personal or commercial use.

Ships: Large watercraft for transporting goods and passengers over long distances.

Submarines: Underwater vehicles used for exploration, research, and military purposes.


Air Vehicles

Airplanes: Fixed-wing aircraft for transporting passengers and cargo.

Helicopters: Rotary-wing aircraft for versatile transportation and rescue operations.

Drones: Unmanned aerial vehicles used for various purposes, including surveillance and delivery.

*/