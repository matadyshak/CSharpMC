using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace EFDataAccess
{
    public static class Program
    {
        static void Main(string[] args)
        {
            DataInitializer data = new DataInitializer();
            List<Person> personData = data.GetPersonData();

            EFCrud eFCrud = new EFCrud();

            //eFCrud.CreateRecords<Person>(personData);
            eFCrud.ReadAllRecords();

            int? idPhilip = eFCrud.ReadIdByName("Philip", "TaddyGreatGrandDaddy");
            int? idArlene = eFCrud.ReadIdByName("Arlene", "TaddyGreatGrandMommy");
            int? idMichael = eFCrud.ReadIdByName("Michael", "TaddyGrandDaddy");
            int? idThomas = eFCrud.ReadIdByName("Thomas", "TaddyGrandUncle");
            int? idGregory = eFCrud.ReadIdByName("Gregory", "TaddyGrandUncle");

            if (idGregory != null) eFCrud.ReadRecordById(idGregory);
            if (idThomas != null) eFCrud.ReadRecordById(idThomas);
            if (idMichael != null) eFCrud.ReadRecordById(idMichael);
            if (idArlene != null) eFCrud.ReadRecordById(idArlene);
            if (idPhilip != null) eFCrud.ReadRecordById(idPhilip);

            eFCrud.UpdateFirstName(idPhilip, "Phillip");
            eFCrud.ReadRecordById(idPhilip);

            eFCrud.UpdateLastName(idPhilip, "Tadyszak");
            eFCrud.ReadRecordById(idPhilip);


            Address address = new Address
            {
                Street = "702 Wooly Bucket",
                City = "The Woodlands",
                State = "TX",
                ZipCode = "77385-1234"
            };
            eFCrud.UpdateAddress(idGregory, address);
            eFCrud.ReadRecordById(idGregory);


            Employer employer = new Employer
            {
                CompanyName = "McDonald's"
            };
            eFCrud.UpdateEmployer(idThomas, employer);
            eFCrud.ReadRecordById(idThomas);


            address = new Address
            {
                Street = "2005 High Summit",
                City = "Garland",
                State = "TX",
                ZipCode = "75041"
            };
            eFCrud.DeleteAddress(idMichael, address);
            eFCrud.ReadRecordById(idMichael);


            employer = new Employer
            {
                CompanyName = "St Nicholas Catholic Church"
            };
            eFCrud.DeleteEmployer(idThomas, employer);
            eFCrud.ReadRecordById(idThomas);


            eFCrud.DeleteUser(idMichael);
            eFCrud.ReadAllRecords();

            Console.WriteLine("Completed processing");
            Console.ReadLine();
        }
    }
}
