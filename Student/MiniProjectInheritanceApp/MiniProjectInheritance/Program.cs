using MiniProjectInheritance.Interfaces;
using System;
using System.Collections.Generic;

namespace MiniProjectInheritance.Models
{
    class Program
    {
        static void Main()
        {
            string reply;

            List<IRentable> rentables = new List<IRentable>();
            List<IPurchaseable> purchaseables = new List<IPurchaseable>();
            List<IUseable> useables = new List<IUseable>();

            BowlingShoesModel shoes = new BowlingShoesModel { ProductName = "Brunswick Sliders", AvailableQuantity = 100, ShoeSize = 12 };
            BowlingBallModel balls = new BowlingBallModel { ProductName = "Fab Hammer", AvailableQuantity = 200, Weight = 16 };
            BowlingLaneModel lanes = new BowlingLaneModel { ProductName = "Bowling Lane", AvailableQuantity = 25, LaneNumber = 13 };

            // This works also
            //IRentable r = new BowlingLaneModel { ProductName = "Bowling Lane", AvailableQuantity = 10, LaneNumber = 20 };
            //r.RentItem();


            rentables.Add(shoes);
            rentables.Add(lanes);
            purchaseables.Add(shoes);
            purchaseables.Add(balls);
            useables.Add(balls);

            foreach (IRentable rentable in rentables)
            {
                if (rentable is BowlingShoesModel shoe)
                {
                    Console.Write("Do you need to rent bowling shoes? (yes/no): ");
                    reply = Console.ReadLine().ToLower();
                    if (reply == "yes")
                    {
                        shoe.RentItem();
                        shoe.ReturnRentalItem();
                    }
                    //Else using your own shoes or buying new shoes
                }
                else if (rentable is BowlingLaneModel lane)
                {
                    Console.Write("Do you want to rent a bowling lane? (yes/no): ");
                    reply = Console.ReadLine().ToLower();
                    if (reply == "yes")
                    {
                        lane.RentItem();
                        lane.ReturnRentalItem();
                    }
                }
            }

            foreach (IPurchaseable purchaseable in purchaseables)
            {
                if (purchaseable is BowlingShoesModel shoe)
                {
                    Console.Write("Do you need to purchase new bowling shoes? (yes/no): ");
                    reply = Console.ReadLine().ToLower();
                    if (reply == "yes")
                    {
                        shoe.BuyItem();
                    }
                }
                else if (purchaseable is BowlingBallModel ball)
                {
                    Console.Write("Do you want to purchase a new bowling ball? (yes/no): ");
                    reply = Console.ReadLine().ToLower();
                    if (reply == "yes")
                    {
                        ball.BuyItem();
                    }
                }
            }

            foreach (IUseable useable in useables)
            {
                if (useable is BowlingBallModel ball)
                {
                    Console.WriteLine("We have house bowling balls of all weights and finger hole sizes in the racks.");
                    Console.Write("Do you want to select a house bowling ball? (yes/no): ");
                    reply = Console.ReadLine().ToLower();
                    if (reply == "yes")
                    {
                        ball.UseItem();
                    }
                }
            }

            Console.WriteLine("Program ended.  Hit Enter key to exit.");
            Console.ReadLine();
        }
    }
}
