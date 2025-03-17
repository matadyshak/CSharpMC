using MiniProjectInheritance.Interfaces;
using System;

namespace MiniProjectInheritance.Models
{
    public class BowlingBallModel : InventoryItemModel, IPurchaseable, IUseable
    {
        public override decimal Price { get; set; }
        public override int AvailableQuantity { get; set; }
        public override string ProductName { get; set; }
        public int Weight { get; set; }
        public void BuyItem()
        {
            Price = 200.00m;
            AvailableQuantity -= 1;
            Console.WriteLine($"Purchased \'{ProductName}\' {Weight}-lb bowling ball at a cost of ${Price}.  Available quantity: {AvailableQuantity}");
        }

        public void UseItem()
        {
            Price = 0.00m;
            Console.WriteLine("Chose free house bowling ball");
        }
    }
}