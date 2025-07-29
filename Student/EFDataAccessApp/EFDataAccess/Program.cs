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

            ////////////////////////////////////////////////////////////
            // Create 5 records from DataInitializer.cs
            // Program can start with an empty DB
            // and complete with an empty DB
            ////////////////////////////////////////////////////////////

            Console.WriteLine("Creating 5 records...");
            eFCrud.CreateRecords<Person>(personData);
            eFCrud.ReadAllRecords();
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            int? idPhilip = eFCrud.ReadIdByName("Philip", "TaddyGreatGrandDaddy");
            int? idArlene = eFCrud.ReadIdByName("Arlene", "TaddyGreatGrandMommy");
            int? idMichael = eFCrud.ReadIdByName("Michael", "TaddyGrandDaddy");
            int? idThomas = eFCrud.ReadIdByName("Thomas", "TaddyGrandUncle");
            int? idGregory = eFCrud.ReadIdByName("Gregory", "TaddyGrandUncle");

            Console.WriteLine("Reading records by Id:");
            if (idGregory != null) eFCrud.ReadRecordById(idGregory);
            if (idThomas != null) eFCrud.ReadRecordById(idThomas);
            if (idMichael != null) eFCrud.ReadRecordById(idMichael);
            if (idArlene != null) eFCrud.ReadRecordById(idArlene);
            if (idPhilip != null) eFCrud.ReadRecordById(idPhilip);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////
            // Make changes to the DB contents
            ////////////////////////////////////////////////////////////

            Console.WriteLine("Changing first name from 'Philip' to 'Phillip':");
            eFCrud.UpdateFirstName(idPhilip, "Phillip");
            eFCrud.ReadRecordById(idPhilip);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Changing last name from 'TaddyGreatGrandDaddy' to 'Tadyszak':");
            eFCrud.UpdateLastName(idPhilip, "Tadyszak");
            eFCrud.ReadRecordById(idPhilip);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Adding address 702 Wooly Bucket':");
            Address address = new Address
            {
                Street = "702 Wooly Bucket",
                City = "The Woodlands",
                State = "TX",
                ZipCode = "77385-1234"
            };
            eFCrud.UpdateAddress(idGregory, address);
            eFCrud.ReadRecordById(idGregory);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Adding employer McDonald's:");
            Employer employer = new Employer
            {
                CompanyName = "McDonald's"
            };
            eFCrud.UpdateEmployer(idThomas, employer);
            eFCrud.ReadRecordById(idThomas);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Deleting 2005 High Summit address:");
            address = new Address
            {
                Street = "2005 High Summit",
                City = "Garland",
                State = "TX",
                ZipCode = "75041"
            };
            eFCrud.DeleteAddress(idMichael, address);
            eFCrud.ReadRecordById(idMichael);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Deleting employer St Nicholas Catholic Church:");
            employer = new Employer
            {
                CompanyName = "St Nicholas Catholic Church"
            };
            eFCrud.DeleteEmployer(idThomas, employer);
            eFCrud.ReadRecordById(idThomas);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////
            // Reverse all the changes back top the original state
            ////////////////////////////////////////////////////////////

            Console.WriteLine("Changing first name from 'Phillip' to 'Philip':");
            eFCrud.UpdateFirstName(idPhilip, "Philip");
            eFCrud.ReadRecordById(idPhilip);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Changing last name from 'Tadyszak' to 'TaddyGreatGrandDaddy':");
            eFCrud.UpdateLastName(idPhilip, "TaddyGreatGrandDaddy");
            eFCrud.ReadRecordById(idPhilip);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Deleting address 702 Wooly Bucket':");
            address = new Address
            {
                Street = "702 Wooly Bucket",
                City = "The Woodlands",
                State = "TX",
                ZipCode = "77385-1234"
            };
            eFCrud.DeleteAddress(idGregory, address);
            eFCrud.ReadRecordById(idGregory);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Deleting employer McDonald's:");
            employer = new Employer
            {
                CompanyName = "McDonald's"
            };
            eFCrud.DeleteEmployer(idThomas, employer);
            eFCrud.ReadRecordById(idThomas);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();


            Console.WriteLine("Adding 2005 High Summit address:");
            address = new Address
            {
                Street = "2005 High Summit",
                City = "Garland",
                State = "TX",
                ZipCode = "75041"
            };
            eFCrud.UpdateAddress(idMichael, address);
            eFCrud.ReadRecordById(idMichael);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            Console.WriteLine("Adding employer St Nicholas Catholic Church:");
            employer = new Employer
            {
                CompanyName = "St Nicholas Catholic Church"
            };
            eFCrud.UpdateEmployer(idThomas, employer);
            eFCrud.ReadRecordById(idThomas);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////
            // Delete all users and their records
            ////////////////////////////////////////////////////////////

            Console.WriteLine("Deleting user Philip...");
            eFCrud.DeleteUser(idPhilip);
            eFCrud.ReadAllRecords();
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            Console.WriteLine("Deleting user Arlene...");
            eFCrud.DeleteUser(idArlene);
            eFCrud.ReadAllRecords();
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            Console.WriteLine("Deleting user Michael...");
            eFCrud.DeleteUser(idMichael);
            eFCrud.ReadAllRecords();
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            Console.WriteLine("Deleting user Thomas...");
            eFCrud.DeleteUser(idThomas);
            eFCrud.ReadAllRecords();
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            Console.WriteLine("Deleting user Gregory...");
            eFCrud.DeleteUser(idGregory);
            eFCrud.ReadAllRecords();
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            ////////////////////////////////////////////////////////////
            // Test callling CRUD methods on an empty DB
            ////////////////////////////////////////////////////////////


            eFCrud.UpdateFirstName(idPhilip, "Philip");
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            eFCrud.UpdateLastName(idPhilip, "TaddyGreatGrandDaddy");
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            eFCrud.DeleteAddress(idGregory, address);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            eFCrud.DeleteEmployer(idThomas, employer);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            eFCrud.UpdateAddress(idMichael, address);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            eFCrud.UpdateEmployer(idThomas, employer);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            eFCrud.DeleteUser(idPhilip);
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            Console.WriteLine("Completed processing");
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();
        }
    }
}
