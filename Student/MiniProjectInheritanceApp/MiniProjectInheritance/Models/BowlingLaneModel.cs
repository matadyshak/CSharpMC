using MiniProjectInheritance.Interfaces;
using System;

namespace MiniProjectInheritance.Models
{
    public class BowlingLaneModel : InventoryItemModel, IRentable
    {
        public override decimal Price { get; set; }
        public override int AvailableQuantity { get; set; }
        public override string ProductName { get; set; }
        public int LaneNumber { get; set; }
        public void RentItem()
        {
            Price = 15.00m;
            AvailableQuantity -= 1;
            Console.WriteLine($"Rented bowling lane #{LaneNumber} for 1 hour at a rate of ${Price} per hour. Available lanes: {AvailableQuantity}");
        }
        public void ReturnRentalItem()
        {
            AvailableQuantity += 1;
            Console.WriteLine($"Finished renting bowling lane. Available lanes: {AvailableQuantity}");
        }
    }
}