using System;

namespace MethodOverload
{
    class Program
    {
        static void Main()
        {
            CarBuyerModel michael = new CarBuyerModel("Michael", "Tadyshak", 75002, 50);
            michael.CarSearch("Chevrolet", "Corvette", 25000.00m);

            CarBuyerModel myra = new CarBuyerModel("Myra", "Tadyshak");
            Console.WriteLine("\nPlease provide a ZIP code and search radius in miles.");
            myra.ZipCode = myra.PromptForZipCode();
            myra.SearchRadius = myra.PromptForSearchRadius();
            myra.CarSearch("Chevrolet", "Camero", 50000, 20000.00m);

            CarBuyerModel daniel = new CarBuyerModel();
            Console.WriteLine("\nPlease provide your name, ZIP code and search radius in miles.");
            (daniel.FirstName, daniel.LastName) = daniel.PromptForName();
            daniel.ZipCode = daniel.PromptForZipCode();
            daniel.SearchRadius = daniel.PromptForSearchRadius();
            daniel.CarSearch(1970, 1974, "Dodge", "Challenger");

            Console.ReadLine();
        }
    }

    public class CarBuyerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public int SearchRadius { get; set; }

        public CarBuyerModel(string firstName, string lastName, int zipCode, int searchRadius)
        {
            FirstName = firstName;
            LastName = lastName;
            ZipCode = zipCode;
            SearchRadius = searchRadius;
        }

        public CarBuyerModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public CarBuyerModel()
        {
        }

        public int PromptForZipCode()
        {
            int zipCode = 0;
            string entry = "";
            bool valid = false;

            while (!valid)
            {
                Console.Write("Enter ZIP code: ");
                entry = Console.ReadLine();
                try
                {
                    valid = int.TryParse(entry, out zipCode);
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was invalid.");
                }
            }
            return zipCode;
        }

        public int PromptForSearchRadius()
        {
            int radius = 0;
            string entry = "";
            bool valid = false;

            while (!valid)
            {
                Console.Write("Enter search radius in miles: ");
                entry = Console.ReadLine();
                try
                {
                    valid = int.TryParse(entry, out radius);
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"The entry: {entry} was invalid.");
                }
            }
            return radius;
        }
        public (string firstName, string lastName) PromptForName()
        {
            string first;
            string last;

            Console.Write("Enter First Name: ");
            first = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            last = Console.ReadLine();

            return (first, last);
        }

        public void CarSearch(string make, string model, decimal maxPrice)
        {
            int minYear = 1974;
            int maxYear = 2025;
            int maxMileage = 250000;

            CarSearch(minYear, maxYear, make, model, maxMileage, maxPrice);
        }

        public void CarSearch(string make, string model, int maxMileage, decimal maxPrice)
        {
            int minYear = 1974;
            int maxYear = 2025;

            CarSearch(minYear, maxYear, make, model, maxMileage, maxPrice);
        }

        public void CarSearch(int minYear, int maxYear, string make, string model)
        {
            int maxMileage = 250000;
            decimal maxPrice = 100000.00m;

            CarSearch(minYear, maxYear, make, model, maxMileage, maxPrice);
        }

        public void CarSearch(int minYear, int maxYear, string make, string model, int maxMileage, decimal maxPrice)
        {
            Console.Write($"Car Search for {FirstName} {LastName} within {SearchRadius} miles of ZIP code {ZipCode}.");
            Console.WriteLine($"Search Params: Years {minYear}-{maxYear} Make: {make} Model: {model} MaxMileage: {maxMileage} Max Price: {maxPrice}");
        }
    }
}
