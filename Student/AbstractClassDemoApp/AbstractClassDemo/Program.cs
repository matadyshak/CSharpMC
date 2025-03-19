using System;
using System.Collections.Generic;

namespace AbstractClassDemo
{
    class Program
    {
        static void Main()
        {
            decimal deliveryFee;
            decimal salePrice;
            decimal refundAmount;

            // Cannnot instantiate Product since it is a abstract class
            // Product product = new Product();

            List<ISellable> sellables = new List<ISellable>();

            // Made quantityInStock a private set 
            // Added a protected constructor for setting quantityInStock from child classes of Product
            FurnitureItem sofa = new FurnitureItem(50) { SKU = 56785678, Manufacturer = "Ashley", Model = "Sofa-B400-207-Rust" };
            FurnitureItem love = new FurnitureItem(48) { SKU = 56788765, Manufacturer = "Ashley", Model = "Love-B400-208-Rust" };
            ApplianceItem dryer = new ApplianceItem(20) { SKU = 12345500, Manufacturer = "Maytag", Model = "Dryer-D2000-157-WH" };
            ApplianceItem washer = new ApplianceItem(18) { SKU = 12345600, Manufacturer = "Maytag", Model = "Washer-D2000-157-WH" };

            sellables.Add(sofa);
            sellables.Add(love);
            sellables.Add(dryer);
            sellables.Add(washer);

            foreach (ISellable sellable in sellables)
            {
                // For run-time polymorphism
#pragma warning disable IDE0019
                Product product = sellable as Product;
#pragma warning restore IDE0019

                if (product != null)
                {
                    deliveryFee = product.CalculateDeliveryFee();
                    salePrice = product.Sale();
                    refundAmount = product.Refund();
                    Console.WriteLine($"SKU: {product.SKU}, Manufacturer: {product.Manufacturer}, Model: {product.Model}, Sale price: {salePrice}, Refund amount: {refundAmount}, Delivery fee: {deliveryFee}");
                }
            }
            Console.ReadLine();
        }
    }
}