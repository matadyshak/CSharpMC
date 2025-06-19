using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDBUI
{
    internal class Program
    {
        private static MongoDBDataAccess? db;
        private static readonly string tableName = "Contacts";
        static void Main()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            db = new MongoDBDataAccess("MongoContactsDB", GetConnectionString());

            ContactModel user = new ContactModel
            {
                FirstName = "Tim",
                LastName = "Corey"
            };
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tim@iamtimcorey.com" });
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1234" });
            //CreateContact(user);

            // Tim: 55f35b91-3ad0-4cd6-91ba-74e125337855
            //      b7878cf2-fea3-46d0-a168-865a3a1f53b4
            // Charity: 29cf5f3f-3919-427a-99c2-989fa8ee0c4b

            //GetAllContacts();

            //GetContactById("29cf5f3f-3919-427a-99c2-989fa8ee0c4b"); //Charity

            UpdateContactsFirstName("Michael", "b7878cf2-fea3-46d0-a168-865a3a1f53b4"); // Tim

            //RemovePhoneNumberFromUser("555-1212", "b7878cf2-fea3-46d0-a168-865a3a1f53b4");

            //RemoveUser("b7878cf2-fea3-46d0-a168-865a3a1f53b4"); // Tim

            Console.WriteLine("Done processing MongoDB");
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

            // Keep list of all PhoneNumbers that do not match phoneNumber passed in
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
