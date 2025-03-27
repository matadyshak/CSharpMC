using System;

namespace MethodOverload
{
    class Program
    {
        static void Main()
        {
            CarBuyerModel michael = new CarBuyerModel("Michael", "Tadyshak", "Honda", "Civic");
            michael.CarSearch(michael.Make, michael.Model, michael.MaxPrice);

            CarBuyerModel myra = new CarBuyerModel("Myra", "Tadyshak");
            myra.Make = myra.PromptForMake();
            myra.Model = myra.PromptForModel();
            myra.CarSearch("Toyota", "Corolla", 50000, 15000.00m);


            CarBuyerModel daniel = new CarBuyerModel();
            daniel.Make = daniel.PromptForMake();
            daniel.Model = daniel.PromptForModel();
            (daniel.FirstName, daniel.LastName) = daniel.PromptForName();
            daniel.CarSearch(1968, 1975, "Dodge", "Challenger");

            Console.ReadLine();
        }
    }

    public class CarBuyerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int MaxMileage { get; set; }
        public decimal MaxPrice { get; set; }

        public CarBuyerModel(string firstName, string lastName, string make, string model)
        {
            FirstName = firstName;
            LastName = lastName;
            Make = make;
            Model = model;
        }

        public CarBuyerModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public CarBuyerModel()
        {
        }

        public string PromptForMake()
        {
            string make;

            Console.Write("Enter Make: ");
            make = Console.ReadLine();

            return make;
        }

        public string PromptForModel()
        {
            string model;

            Console.Write("Enter Model: ");
            model = Console.ReadLine();

            return model;
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
            Console.WriteLine($"Search Parameters: Years {minYear}-{maxYear} Make: {make} Model: {model} MaxMileage: {maxMileage} Max Price: {maxPrice}");
        }
    }
}
