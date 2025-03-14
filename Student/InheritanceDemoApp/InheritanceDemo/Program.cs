using System;
using System.Collections.Generic;

namespace InheritanceDemoApp
{
    class Program
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            Vehicle veh = new Vehicle();
            LandVehicle landVehicle = new LandVehicle();
            Car car = new Car();
            Motorcycle motorcycle = new Motorcycle();
            WaterVehicle waterVehicle = new WaterVehicle();
            Boat boat = new Boat();

            vehicles.Add(veh);
            vehicles.Add(landVehicle);
            vehicles.Add(car);
            vehicles.Add(motorcycle);
            vehicles.Add(waterVehicle);
            vehicles.Add(boat);

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine();
                if (vehicle is Vehicle v)
                {
                    v.Start();
                    v.Stop();
                }

                if (vehicle is LandVehicle l)
                {
                    l.AscendHill();
                    l.DecendHill();
                }

                if (vehicle is WaterVehicle w)
                {
                    w.Steer(90);
                }

                if (vehicle is Car c)
                {
                    c.TurnSignal(1);
                }

                if (vehicle is Motorcycle m)
                {
                    m.ChangeGear(1);
                }

                if (vehicle is Boat b)
                {
                    b.PullSkiers();
                }
            }
        }
    }
}

