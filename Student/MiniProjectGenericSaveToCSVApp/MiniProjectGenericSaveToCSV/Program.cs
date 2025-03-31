using System;
using System.Collections.Generic;

namespace MiniProjectGenericSaveToCSV
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
                new CarModel{ Manufacturer = "DodgeHeck", YearManufactured = 1974 },
                new CarModel{ Manufacturer = "Ford"     , YearManufactured = 2020 },
                new CarModel{ Manufacturer = "Chevrolet", YearManufactured = 2025 }
            };

            DataAccess<PersonModel> peopleData = new DataAccess<PersonModel>();
            peopleData.BadEntryFound += PeopleData_BadEntryFound;
            peopleData.SaveToCSVFile(people, @"C:\Temp\SavedFiles\people.csv");

            DataAccess<CarModel> carData = new DataAccess<CarModel>();
            carData.BadEntryFound += CarData_BadEntryFound;
            carData.SaveToCSVFile(cars, @"C:\Temp\SavedFiles\cars.csv");

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
    }
}
