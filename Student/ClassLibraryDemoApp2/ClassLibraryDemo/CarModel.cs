namespace ClassLibraryDemo
{
    public class CarModel
    {
        public string Manufacturer { get; set; }
        public int YearManufactured { get; set; }
        public string Print()
        {
            return $"{Manufacturer} {YearManufactured}";
        }
    }
}
