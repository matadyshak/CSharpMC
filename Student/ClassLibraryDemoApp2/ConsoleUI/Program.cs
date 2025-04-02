namespace ClassLibraryDemo
{
    class Program
    {
        static void Main()
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Michael", LastName="Tadyshak", Email="mikeshak@kmail.com"},
                new PersonModel{ FirstName = "Myra"   , LastName="Tadyshak", Email="tadymyra@jmail.com"},
                new PersonModel{ FirstName = "DarnGreg"   , LastName="Tadyshak", Email="greg@pmail.com"}
            };

            List<CarModel> cars = new List<CarModel>
            {
                new CarModel{ Manufacturer = "Dodge", YearManufactured = 1974 },
                new CarModel{ Manufacturer = "FordHeck"     , YearManufactured = 2020 },
                new CarModel{ Manufacturer = "Chevrolet", YearManufactured = 2025 }
            };

            DataAccess<PersonModel> peopleData = new DataAccess<PersonModel>();
            peopleData.BadEntryFound += PeopleData_BadEntryFound;
            peopleData.FileNotFoundOrEmpty += PeopleData_FileNotFoundOrEmpty;
            peopleData.SaveToCSVFile(people, @"C:\Temp\SavedFiles\people.csv");
            people.Clear();
            people = peopleData.LoadFromCSVFile(@"C:\Temp\SavedFiles\people.csv");
            Console.WriteLine("Cleared people array and reloaded from CSV file.");
            foreach (PersonModel person in people)
            {
                Console.WriteLine(person.Print());
            }

            DataAccess<CarModel> carData = new DataAccess<CarModel>();
            carData.BadEntryFound += CarData_BadEntryFound;
            carData.FileNotFoundOrEmpty += CarData_FileNotFoundOrEmpty;
            carData.SaveToCSVFile(cars, @"C:\Temp\SavedFiles\cars.csv");
            cars.Clear();
            cars = carData.LoadFromCSVFile(@"C:\Temp\SavedFiles\cars.csv");
            Console.WriteLine("Cleared cars array and reloaded from CSV file.");
            foreach (CarModel car in cars)
            {
                Console.WriteLine(car.Print());
            }

            Console.ReadLine();
        }
        private static void CarData_BadEntryFound(object sender, CarModel e)
        {
            Console.WriteLine($"Bad entry found for {e.Manufacturer} {e.YearManufactured}");
        }

        private static void PeopleData_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad entry found for {e.FirstName} {e.LastName} {e.Email}");
        }
        private static void PeopleData_FileNotFoundOrEmpty(object sender, PersonModel e)
        {
            Console.WriteLine("File not found or empty.");
        }
        private static void CarData_FileNotFoundOrEmpty(object sender, CarModel e)
        {
            Console.WriteLine("File not found or empty.");
        }
    }
}