using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace CosmosDBUI
{
    public class Program
    {
        static void Main()
        {
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            //db = new MongoDBDataAccess("MongoContactsDB", GetConnectionString());

            Guid? guid = new();


            foreach (ContactModel contact in contactsData)
            {
                CreateContact(contact);
            }
            Console.WriteLine("New contacts stored in DB.  Press enter key to continue");
            Console.ReadLine();


            Console.WriteLine("Reading back all contacts...");
            GetAllContacts();
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine($"Getting contact for Hcabmuab Bocaj...");
            guid = GetIdFromName("Hcabmuab", "Bocaj");
            if (guid != null)
            {
                GetContactById(guid);
            }
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();


            Console.WriteLine($"Changing first name for Kahsydat Nitsirk...");
            guid = GetIdFromName("Kahsydat", "Nitsirk");
            if (guid != null)
            {
                UpdateContactsFirstName("Zeloznog", guid);
                GetContactById(guid);
            }
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine($"Removing phone number 514-300-9999 from Kahsydat Acire...");
            guid = GetIdFromName("Kahsydat", "Acire");
            if (guid != null)
            {
                RemovePhoneNumberFromUser("514-300-9999", guid);
                GetContactById(guid);
            }
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine($"Removing user Kahsydat Leahcim...");
            guid = GetIdFromName("Kahsydat", "Leahcim");
            if (guid != null)
            {
                RemoveUser(guid);
            }
            Console.WriteLine("Reading back all contacts...");
            GetAllContacts();
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine("Done processing CosmosDB");
            Console.ReadLine();
        }

        public static Guid? GetIdFromName(string firstName, string lastName)
        {
            Guid? guid;
            //ContactModel model = new();
            //try
            //{
            //    model = db.LoadRecordByName<ContactModel>(tableName, firstName, lastName);
            //    guid = model.Id;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Exception: {e}.  Did not find {firstName} {lastName}");
            //    guid = null;
            //}
            return guid;
        }

        public static void RemoveUser(Guid? guid)
        {
            //        db.DeleteRecord<ContactModel>(tableName, guid);
        }

        public static void RemovePhoneNumberFromUser(string phoneNumber, Guid? guid)
        {
            //var contact = db.LoadRecordById<ContactModel>(tableName, guid);

            //// Keep list of all PhoneNumbers that do not match phoneNumber passed in
            //contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

            //db.UpsertRecord(tableName, contact.Id, contact);
        }

        private static void UpdateContactsFirstName(string firstName, Guid? guid)
        {
            //var contact = db.LoadRecordById<ContactModel>(tableName, guid);

            //contact.FirstName = firstName;
            //db.UpsertRecord(tableName, contact.Id, contact);
        }

        private static void GetContactById(Guid? guid)
        {
            //List<ContactModel> contacts = new();
            //var contact = db.LoadRecordById<ContactModel>(tableName, guid);
            //contacts.Add(contact);
            //DisplayFullContacts(contacts);
        }

        private static void GetAllContacts()
        {
            //List<ContactModel> contacts = db.LoadRecords<ContactModel>(tableName);
            //DisplayFullContacts(contacts);
        }

        private static void DisplayFullContacts(List<ContactModel> contacts)
        {
            //foreach (var contact in contacts)
            //{
            //    Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
            //    foreach (EmailAddressModel model in contact.EmailAddresses)
            //    {
            //        Console.WriteLine($"{model.EmailAddress}");
            //    }
            //    foreach (PhoneNumberModel model in contact.PhoneNumbers)
            //    {
            //        Console.WriteLine($"{model.PhoneNumber}");
            //    }
            //}
        }

        private static void CreateContact(ContactModel contact)
        {
            //if (db != null)
            //{
            //    db.UpsertRecord(tableName, contact.Id, contact);
            //}
            //else
            //{
            //    Console.WriteLine("Error: db is NULL in CreateContact()");
            //}
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
