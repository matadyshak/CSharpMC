using System;

namespace MiniProjectGenericSaveToCSV
{
    class CarModel
    {
        public string Manufacturer { get; set; }
        public int YearManufactured { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Manufacturer} {YearManufactured}");
        }
    }
}
