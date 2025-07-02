using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace CosmosDBUI
{
    public class Program
    {
        private static CosmosDBDataAccess db;
        private static DataInitializer data = new DataInitializer();
        private static List<ContactModel> contactsData = data.GetContactData();
        static async Task Main(string[] args)
        {
            var c = GetCosmosInfo();
            db = new CosmosDBDataAccess(c.endpointUrl, c.primaryKey, c.databaseName, c.containerName);
            string docId;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // await CreateContactAsync(user);
            // await CreateContactAsync(user2);
            // await GetAllContactsAsync();
            // await GetContactByIdAsync("ee40b270-8b66-4f48-bcd2-13243032cf55");
            // await UpdateContactsFirstNameAsync("Timothy", "ee40b270-8b66-4f48-bcd2-13243032cf55");
            // await GetContactByIdAsync("ee40b270-8b66-4f48-bcd2-13243032cf55");
            // await RemovePhoneNumberFromUserAsync("555-1212", "ee40b270-8b66-4f48-bcd2-13243032cf55");
            // await RemoveUserAsync("ee40b270-8b66-4f48-bcd2-13243032cf55");
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            foreach (ContactModel contact in contactsData)
            {
                await CreateContactAsync(contact);
            }
            Console.WriteLine("New contacts stored in DB.  Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine("Reading back all contacts...");
            await GetAllContactsAsync();
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine($"Getting contact for Hcabmuab Bocaj...");
            docId = await GetIdFromNameAsync("Hcabmuab", "Bocaj");
            if (docId != null)
            {
                await GetContactByIdAsync(docId);
            }
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();


            Console.WriteLine($"Changing first name for Kahsydat Nitsirk...");
            docId = await GetIdFromNameAsync("Kahsydat", "Nitsirk");
            if (docId != null)
            {
                await UpdateContactsFirstNameAsync("Zeloznog", docId);
                await GetContactByIdAsync(docId);
            }
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine($"Removing phone number 514-300-9999 from Kahsydat Acire...");
            docId = await GetIdFromNameAsync("Kahsydat", "Acire");
            if (docId != null)
            {
                await RemovePhoneNumberFromUserAsync("514-300-9999", docId);
                await GetContactByIdAsync(docId);
            }
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine($"Removing user Kahsydat Leahcim...");
            docId = await GetIdFromNameAsync("Kahsydat", "Leahcim");
            if (docId != null)
            {
                await RemoveUserAsync(docId);
            }
            Console.WriteLine("Reading back all contacts...");
            await GetAllContactsAsync();
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();

            Console.WriteLine("Done processing CosmosDB");
            Console.ReadLine();
        }

        public static async Task<string> GetIdFromNameAsync(string firstName, string lastName)
        {
            string id;
            ContactModel model = new();
            try
            {
                model = await db.LoadRecordByNameAsync<ContactModel>(firstName, lastName);
                id = model.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}.  Did not find {firstName} {lastName}");
                id = null;
            }

            return id;
        }

        public static async Task RemoveUserAsync(string id)
        {
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            await db.DeleteRecordAsync<ContactModel>(id, contact.LastName);
        }

        public static async Task RemovePhoneNumberFromUserAsync(string phoneNumber, string id)
        {
            ContactModel contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            //// Keep list of all PhoneNumbers that do not match phoneNumber passed in
            contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

            await db.UpsertRecordAsync(contact);
        }

        private static async Task UpdateContactsFirstNameAsync(string firstName, string id)
        {
            ContactModel contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            contact.FirstName = firstName;
            await db.UpsertRecordAsync<ContactModel>(contact);
        }

        private static async Task GetContactByIdAsync(string id)
        {
            List<ContactModel> contacts = new List<ContactModel>();

            //When you capture the output of an asynchronous method without using await you get the whole return value
            //which is a task not just the return value

            // Cannot implicitly convert type 'System.Threading.Tasks.Task<DataAccessLibrary.Models.ContactModel>' to 'DataAccessLibrary.Models.ContactModel'
            //ContactModel contact = db.LoadRecordByIdAsync<ContactModel>(id);

            // But if you await,  then it finishes and returns a ContactModel
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            contacts.Add(contact);
            DisplayFullContacts(contacts);
        }

        private static async Task GetAllContactsAsync()
        {
            var contacts = await db.LoadRecordsAsync<ContactModel>();
            DisplayFullContacts(contacts);
        }

        private static void DisplayFullContacts(List<ContactModel> contacts)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
                foreach (EmailAddressModel model in contact.EmailAddresses)
                {
                    Console.WriteLine($"{model.EmailAddress}");
                }
                foreach (PhoneNumberModel model in contact.PhoneNumbers)
                {
                    Console.WriteLine($"{model.PhoneNumber}");
                }
            }
        }

        private static async Task CreateContactAsync(ContactModel contact)
        {
            if (db != null)
            {
                await db.UpsertRecordAsync(contact, contact.LastName);
            }
            else
            {
                Console.WriteLine("Error: db is NULL in CreateContact()");
            }
        }

        private static (string endpointUrl, string primaryKey, string databaseName, string containerName) GetCosmosInfo()
        {
            (string endpointUrl, string primaryKey, string databaseName, string containerName) output;

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();

            output.endpointUrl = config["CosmosDB:EndpointUrl"];
            output.primaryKey = config["CosmosDB:PrimaryKey"];
            output.databaseName = config.GetValue<string>("CosmosDB:DatabaseName");
            output.containerName = config.GetValue<string>("CosmosDB:ContainerName");

            if (string.IsNullOrWhiteSpace(output.endpointUrl) ||
                string.IsNullOrWhiteSpace(output.primaryKey)  ||
                string.IsNullOrWhiteSpace(output.databaseName) ||
                string.IsNullOrWhiteSpace(output.containerName))
            {
                Console.WriteLine("Missing CosmosDB configuration.");
            }

            return output;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Using Azure Key Vault to fetch CosmosDB secrets
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //private static (string endpointUrl, string primaryKey, string databaseName, string containerName) GetCosmosInfo()
        //{
        //    var vaultUrl = "https://<YourKeyVaultName>.vault.azure.net/";  // Replace with your actual Key Vault URL
        //    var client = new SecretClient(new Uri(vaultUrl), new DefaultAzureCredential());

        //    // Fetch secrets from Key Vault
        //    string endpointUrl = client.GetSecret("CosmosDB--EndpointUrl").Value.Value;
        //    string primaryKey = client.GetSecret("CosmosDB--PrimaryKey").Value.Value;

        //    // Optionally keep non-sensitive values in appsettings.json or hard-code for now
        //    string databaseName = "MyCosmosDatabase";       // Replace with your actual DB name
        //    string containerName = "MyContainer";           // Replace with your actual container name

        //    return (endpointUrl, primaryKey, databaseName, containerName);
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
