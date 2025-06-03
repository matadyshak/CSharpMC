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

            //ReadFullContactById(sql, 1035);  //Jacob

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

        private static void ReadFullContactById(SqliteCrud sql, int id)
        {
            FullContactModel? model = sql.GetFullContactById(id);

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
.            {
                sql.CreateContact(fullContact);
                Console.WriteLine($"Added: {fullContact.BasicInfo.FirstName} {fullContact.BasicInfo.LastName}");
            }
        }

        public static void ChangeContactName(SqliteCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 1032,
                FirstName = "Kris",
                LastName = "Kristopherson"
            };

            sql.UpdateContactName(contact);
        }
        public static void DeleteContactPhoneNumber(SqliteCrud sql)
        {
            //Should wipe out 514-300-0000
            sql.DeletePhoneNumberFromContact(1031, 2049);

            Console.ReadLine();

            // 514-300-9999 should remain since shared by joseph
            sql.DeletePhoneNumberFromContact(1031, 2048);

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
