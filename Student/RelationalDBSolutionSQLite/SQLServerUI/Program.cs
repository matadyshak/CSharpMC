﻿using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace SQLServerUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlCrud sql = new SqlCrud(GetConnectionString());

            ClearTablesAndAllPrimaryKeys(sql);

            WriteFullContacts(sql);

            UpdateContactName(sql);

            UpdateContactEmail(sql);

            DeleteContactPhoneNumber(sql);

            ReadFullContactById(sql);

            ReadAllContacts(sql);

            Console.WriteLine("Done processing SQL Server");
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

        private static void ReadAllContacts(SqlCrud sql)
        {
            var rows = sql.GetAllContacts();

            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }
        private static void ReadFullContactById(SqlCrud sql)
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

            FullContactModel model = sql.GetFullContactById(contactId);
            Console.WriteLine("Displaying full contact model: ");
            Console.WriteLine($"{model.BasicInfo.FirstName} {model.BasicInfo.LastName}");

            foreach (EmailAddressModel email in model.EmailAddresses)
            {
                Console.WriteLine($"{email.EmailAddress}");
            }

            foreach (PhoneNumberModel phoneNumber in model.PhoneNumbers)
            {
                Console.WriteLine($"{phoneNumber.PhoneNumber}");
            }
            Console.WriteLine("\n");
        }
        private static void WriteFullContacts(SqlCrud sql)
        {
            InitializationData initData = new InitializationData();
            List<FullContactModel> FullContactData = initData.GetContactData();

            foreach (FullContactModel fullContact in FullContactData)
            {
                sql.CreateContact(fullContact);
                Console.WriteLine($"Added: {fullContact.BasicInfo.FirstName} {fullContact.BasicInfo.LastName}");
            }
        }
        public static int GetContactId(SqlCrud sql, BasicContactModel contact)
        {
            return sql.FindContactId(contact);
        }
        public static void UpdateContactName(SqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 0,
                FirstName = "Kristin",
                LastName = "Tadyshak"
            };

            int contactId = sql.FindContactId(contact);
            if (contactId <= 0)
            {
                Console.WriteLine("Contact ID was not found.");
                return;
            }

            BasicContactModel newContact = new BasicContactModel
            {
                Id = contactId,
                FirstName = "Kris",
                LastName = "Kristoferson"
            };

            sql.UpdateContactName(newContact);
            Console.WriteLine("Changed Kristin's name.  Press any key to continue. ");
            Console.ReadLine();
        }
        public static void UpdateContactEmail(SqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 0,
                FirstName = "Sarah",
                LastName = "BaumBach"
            };

            int contactId = sql.FindContactId(contact);
            if (contactId <= 0)
            {
                Console.WriteLine("Contact ID not found.");
                return;
            }

            contact.Id = contactId;

            // Now search dbo.EmailAddresses for
            // EmailAddress = "Sarah@fema.com"

            int emailId = sql.FindEmailId("Sarah@fema.com");
            if (emailId <= 0)
            {
                Console.WriteLine("Email not found.");
                return;
            }

            //Should wipe out
            sql.ChangeEmailFromContact(emailId, "Sarah@Tesla.com");
            Console.WriteLine("Changed Sarah's email to Sarah@Tesla.com.  Press any key to continue. ");

            Console.ReadLine();
        }
        public static void DeleteContactPhoneNumber(SqlCrud sql)
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
            Console.WriteLine("Deleted phone number 514-300-0000. Press any key to continue. ");
            Console.ReadLine();

            phoneNumberId = sql.FindPhoneNumberId("514-300-9999");
            if (phoneNumberId <= 0)
            {
                Console.WriteLine("Phone Number ID for 514-300-9999 not found.");
                return;
            }

            // 514-300-9999 should remain since shared by joseph
            sql.DeletePhoneNumberFromContact(contactId, phoneNumberId);
            Console.WriteLine("Deleted phone number 514-300-9999. Press any key to continue. ");
            Console.ReadLine();
        }
        public static void ClearTablesAndAllPrimaryKeys(SqlCrud sql)
        {
            sql.ResetTablesAndAllPrimaryKeys();
            Console.WriteLine("All tables cleared and primary keys reset. Press any key to continue. ");
            Console.ReadLine();
        }
    }
}
