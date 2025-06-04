using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace SqliteUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqliteCrud sql = new SqliteCrud(GetConnectionString());

            ClearTablesAndAllPrimaryKeys(sql);

            WriteFullContacts(sql);

            ChangeContactName(sql);

            DeleteContactPhoneNumber(sql);

            ReadFullContactById(sql);

            ReadAllContacts(sql);

            Console.WriteLine("Done processing Sqlite");
            Console.ReadLine();
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string? output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

#pragma warning disable CS8603 // Possible null reference return.
            return output;
#pragma warning restore CS8603 // Possible null reference return.
        }
        private static void ReadAllContacts(SqliteCrud sql)
        {
            var rows = sql.GetAllContacts();

            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }

        private static void ReadFullContactById(SqliteCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 0,
                FirstName = "Myra",
                LastName = "Tadyshak"
            };

            int contactId = sql.FindContactId(contact);
            if (contactId <= 0)
            {
                Console.WriteLine("Contact ID was not found.");
                return;
            }

            FullContactModel? model = sql.GetFullContactById(contactId);

            Console.WriteLine($"{model.BasicInfo.FirstName} {model.BasicInfo.LastName}");

            foreach (EmailAddressModel email in model.EmailAddresses)
            {
                Console.WriteLine($"{email.EmailAddress}");
            }

            foreach (PhoneNumberModel phoneNumber in model.PhoneNumbers)
            {
                Console.WriteLine($"{phoneNumber.PhoneNumber}");
            }
        }
        private static void WriteFullContacts(SqliteCrud sql)
        {
            InitializationData initData = new InitializationData();
            List<FullContactModel> FullContactData = initData.GetContactData();

            foreach (FullContactModel fullContact in FullContactData)
            {
                sql.CreateContact(fullContact);
                Console.WriteLine($"Added: {fullContact.BasicInfo.FirstName} {fullContact.BasicInfo.LastName}");
            }
        }
        public static int GetContactId(SqliteCrud sql, BasicContactModel contact)
        {
            return sql.FindContactId(contact);
        }
        public static void ChangeContactName(SqliteCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 0,
                FirstName = "Joseph",
                LastName = "Tadyshak"
            };

            int id = sql.FindContactId(contact);

            if (id <= 0)
            {
                Console.WriteLine("ContactId not found.");
                return;
            }

            contact.Id = id;
            contact.FirstName = "Kris";
            contact.LastName = "Kristoferson";
            sql.UpdateContactName(contact);
        }
        public static void DeleteContactPhoneNumber(SqliteCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 0,
                FirstName = "Erica",
                LastName = "Tadyshak"
            };

            int contactId = sql.FindContactId(contact);

            if (contactId <= 0)
            {
                Console.WriteLine("Contact ID for Erica Tadyshak not found.");
                return;
            }

            contact.Id = contactId;

            // Now search dbo.PhoneNumbers for
            // 514-300-0000 (not shared)
            // and
            // 514-300-9999 (shared)

            int phoneNumberId = sql.FindPhoneNumberId("514-300-0000");
            if (phoneNumberId <= 0)
            {
                Console.WriteLine("Phone Number ID for 514-300-0000 not found.");
                return;
            }

            //Should wipe out 514-300-0000
            sql.DeletePhoneNumberFromContact(contactId, phoneNumberId);

            Console.ReadLine();

            phoneNumberId = sql.FindPhoneNumberId("514-300-9999");
            if (phoneNumberId <= 0)
            {
                Console.WriteLine("Phone Number ID for 514-300-9999 not found.");
                return;
            }

            // 514-300-9999 should remain since shared by joseph
            sql.DeletePhoneNumberFromContact(contactId, phoneNumberId);

            Console.ReadLine();
        }
        public static void ClearTablesAndAllPrimaryKeys(SqliteCrud sql)
        {
            sql.ResetTablesAndAllPrimaryKeys();
            Console.WriteLine("All tables cleared and primary keys reset.");
            Console.ReadLine();
        }
    }
}
