using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace TextFileUI
{
    class Program
    {
        private static DataInitializer initialData;
        private static List<ContactModel> initialContacts;
        private static TextFileDataAccess db;
        private static IConfiguration _config;
        private static string textFile;

        static void Main(string[] args)
        {
            // Get file path from appsettings.json
            InitializeConfiguration();
            // Load NUGet package Microsoft.Extensions.Configuration.Binder for GetValue<T> method
            textFile = _config.GetValue<string>("TextFile");
            db = new TextFileDataAccess();
            initialData = new DataInitializer();
            initialContacts = initialData.GetContactData();

            foreach (var contact in initialContacts)
            {
                CreateContact(contact);
            }
            GetAllContacts();
            Console.WriteLine("Contacts loaded.  Press enter key to continue");
            Console.ReadLine();


            UpdateContactsFirstName("Mickey");
            GetAllContacts();
            Console.WriteLine("Updated first name.  Press enter key to continue");
            Console.ReadLine();

            RemovePhoneNumberFromUser("214-100-0000");
            GetAllContacts();
            Console.WriteLine("Removed phone number 214-100-0000.  Press enter key to continue");
            Console.ReadLine();

            RemoveUser();
            GetAllContacts();
            Console.WriteLine("Removed user.  Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine("Done processing text file");
        }

        private static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _config = builder.Build();
        }
        public static void RemoveUser()
        {
            var contacts = db.ReadAllRecords(textFile);
            // Normally the UI selects which contact to update, here we assume the first contact    
            contacts.RemoveAt(0);
            db.WriteAllRecords(contacts, textFile);
        }

        public static void RemovePhoneNumberFromUser(string phoneNumber)
        {
            var contacts = db.ReadAllRecords(textFile);
            // Normally the UI selects which contact to update, here we assume the first contact    
            contacts[0].PhoneNumbers.Remove(phoneNumber);
            db.WriteAllRecords(contacts, textFile);
        }

        private static void UpdateContactsFirstName(string firstName)
        {
            var contacts = db.ReadAllRecords(textFile);
            // Normally the UI selects which contact to update, here we assume the first contact    
            contacts[0].FirstName = firstName;
            db.WriteAllRecords(contacts, textFile);
        }

        private static void GetAllContacts()
        {
            var contacts = db.ReadAllRecords(textFile);

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                DisplayFullContacts(contacts);
            }
        }

        private static void DisplayFullContacts(List<ContactModel> contacts)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                foreach (string email in contact.EmailAddresses)
                {
                    Console.WriteLine($"{email}");
                }
                foreach (string phone in contact.PhoneNumbers)
                {
                    Console.WriteLine($"{phone}");
                }
                Console.WriteLine("\n");
            }
        }
        private static void CreateContact(ContactModel contact)
        {
            var contacts = db.ReadAllRecords(textFile);

            contacts.Add(contact);

            db.WriteAllRecords(contacts, textFile);
        }
    }
}
