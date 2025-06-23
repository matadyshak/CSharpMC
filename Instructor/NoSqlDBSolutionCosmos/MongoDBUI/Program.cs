using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace MongoDBUI
{
    class Program
    {
        private static MongoDBDataAccess db;
        private static readonly string tableName = "Contacts";

        static void Main(string[] args)
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

            //GetContactById("5eb4dfb2-6e63-41c7-aacd-e66fa5943985");

            //UpdateContactsFirstName("Timothy", "fb3ddc6d-a4cc-49fa-95d9-c3674cd387bb");
            //GetAllContacts();

            //RemovePhoneNumberFromUser("555-1212", "fb3ddc6d-a4cc-49fa-95d9-c3674cd387bb");

            //RemoveUser("fb3ddc6d-a4cc-49fa-95d9-c3674cd387bb");

            Console.WriteLine("Done Processing MongoDB");
            Console.ReadLine();
        }

        public static void RemoveUser(string id)
        {
            Guid guid = new Guid(id);
            db.DeleteRecord<ContactModel>(tableName, guid);
        }

        public static void RemovePhoneNumberFromUser(string phoneNumber, string id)
        {
            Guid guid = new Guid(id);
            var contact = db.LoadRecordById<ContactModel>(tableName, guid);

            contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

            db.UpsertRecord(tableName, contact.Id, contact);
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

            Console.WriteLine($"{ contact.Id}: { contact.FirstName } { contact.LastName }");
        }

        private static void GetAllContacts()
        {
            var contacts = db.LoadRecords<ContactModel>(tableName);

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{ contact.Id}: { contact.FirstName } { contact.LastName }");
            }
        }

        private static void CreateContact(ContactModel contact)
        {
            db.UpsertRecord(tableName, contact.Id, contact);
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}
