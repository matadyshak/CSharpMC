using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace MongoDBUI
{
    internal class Program
    {
        private static MongoDBDataAccess? db;
        private static readonly string tableName = "Contacts";
        static void Main()
        {
            db = new MongoDBDataAccess("MongoContactsDB", GetConnectionString());

            ContactModel user = new ContactModel
            {
                FirstName = "Charity",
                LastName = "Corey"
            };
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@aol.com" });
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });
            //CreateContact(user);

            //GetAllContacts();
            GetContactById("499af365-25eb-437f-8606-217c468334a2"); //Charity

            UpdateContactsFirstName("Timothy", "0a9bbc7d-a050-40e9-a761-b58728e591d8"); // Tim


            Console.WriteLine("Done processing MongoDB");
            Console.ReadLine();
        }

        private static void UpdateContactsFirstName(string firstName, string id)
        {
            Guid guid = new Guid(id);
            var contact = db.LoadRecordById<ContactModel>(tableName, guid);

            contact.FirstName = firstName;
            db.UpsertRecord(tableName, contact.Id, contact);
        }
        private static void GetContactById(string id)
        {
            Guid guid = new Guid(id);
            var contact = db.LoadRecordById<ContactModel>(tableName, guid);
            Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
        }
        private static void GetAllContacts()
        {
            var contacts = db.LoadRecords<ContactModel>(tableName);
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
            }
        }
        private static void CreateContact(ContactModel contact)
        {
            if (db != null)
            {
                db.UpsertRecord(tableName, contact.Id, contact);
            }
            else
            {
                Console.WriteLine("Error: db is NULL in CreateContact()");
            }
        }
        private static string? GetConnectionString(string connectionStringName = "Default")
        {
            string? output;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }

    }
}
