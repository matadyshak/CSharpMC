using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapUpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Tim", LastName = "Coreydarnit", Email = "tim@iamtimcorey.com"},
                new PersonModel{ FirstName = "Sue", LastName = "Storm", Email = "sue@stormy.net"},
                new PersonModel{ FirstName = "John", LastName = "Smith", Email = "John45376@aol.com"}
            };

            List<CarModel> cars = new List<CarModel>
            {
                new CarModel{ Manufacturer = "Toyota", Model = "DARNCorolla"},
                new CarModel{ Manufacturer = "Toyota", Model = "Highlander"},
                new CarModel{ Manufacturer = "Ford", Model = "heckMustang"}
            };

            DataAccess<PersonModel> peopleData = new DataAccess<PersonModel>();
            peopleData.BadEntryFound += PeopleData_BadEntryFound;

            peopleData.SaveToCSV(people, @"C:\Temp\SavedFiles\people.csv");

            DataAccess<CarModel> carData = new DataAccess<CarModel>();
            carData.BadEntryFound += CarData_BadEntryFound;

            carData.SaveToCSV(cars, @"C:\Temp\SavedFiles\cars.csv");

            Console.ReadLine();
        }

        private static void CarData_BadEntryFound(object sender, CarModel e)
        {
            Console.WriteLine($"Bad Entry found for { e.Manufacturer } { e.Model }");
        }

        private static void PeopleData_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad Entry found for { e.FirstName } { e.LastName }");
        }
    }
}
