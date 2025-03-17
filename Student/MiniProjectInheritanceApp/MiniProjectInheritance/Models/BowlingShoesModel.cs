using MiniProjectInheritance.Interfaces;
using System;

namespace MiniProjectInheritance.Models
{
    public class BowlingShoesModel : InventoryItemModel, IRentable, IPurchaseable
    {
        public override decimal Price { get; set; }
        public override int AvailableQuantity { get; set; }
        public override string ProductName { get; set; }
        public int ShoeSize { get; set; }
        public void RentItem()
        {
            Price = 5.00m;
            AvailableQuantity -= 1;
            Console.WriteLine($"Rented bowling shoes \'{ProductName}\' size {ShoeSize} at a cost of ${Price}. Available shoes: {AvailableQuantity}");
        }

        public void ReturnRentalItem()
        {
            AvailableQuantity += 1;
            Console.WriteLine($"Returned rented bowling shoes.  Available shoes: {AvailableQuantity}");
        }
        public void BuyItem()
        {
            Price = 50.00m;
            AvailableQuantity -= 1;
            Console.WriteLine($"Purchased new pair of bowling shoes \'{ProductName}\' at a cost of ${Price}.  Available shoes: {AvailableQuantity}");
        }
    }
}