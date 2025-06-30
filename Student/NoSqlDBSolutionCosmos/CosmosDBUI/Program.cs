using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Dependencyinjection

namespace CosmosDBUI
{
    class Program
    {
        private static CosmosDBDataAccess db;
        static async Task Main(string[] args)
        {
            var c = GetCosmosInfo();

            db = new CosmosDBDataAccess(c.endpointUrl, c.primaryKey, c.databaseName, c.containerName);

            ContactModel user = new ContactModel
            {
                FirstName = "Tim",
                LastName = "Corey"
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tim@iamtimcorey.com" });
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1234" });

            ContactModel user2 = new ContactModel
            {
                FirstName = "Charity",
                LastName = "Corey"
            };

            user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@aol.com" });
            user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
            user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
            user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });

            // await CreateContact(user);
            // await CreateContact(user2);

            // await GetAllContacts();

            //await GetContactById("ee40b270-8b66-4f48-bcd2-13243032cf55");

            // await UpdateContactsFirstNameAsync("Timothy", "ee40b270-8b66-4f48-bcd2-13243032cf55");
            // await GetContactById("ee40b270-8b66-4f48-bcd2-13243032cf55");

            //await RemovePhoneNumberFromUserAsync("555-1212", "ee40b270-8b66-4f48-bcd2-13243032cf55");

            // await RemoveUser("ee40b270-8b66-4f48-bcd2-13243032cf55");

            //foreach (ContactModel contact in contactsData)
            //{
            //    CreateContact(contact);
            //}
            //Console.WriteLine("New contacts stored in DB.  Press enter key to continue");
            //Console.ReadLine();


            //Console.WriteLine("Reading back all contacts...");
            //GetAllContacts();
            //Console.WriteLine("Press enter key to continue");
            //Console.ReadLine();

            //Console.WriteLine($"Getting contact for Hcabmuab Bocaj...");
            //guid = GetIdFromName("Hcabmuab", "Bocaj");
            //if (guid != null)
            //{
            //    GetContactById(guid);
            //}
            //Console.WriteLine("Press enter key to continue");
            //Console.ReadLine();


            //Console.WriteLine($"Changing first name for Kahsydat Nitsirk...");
            //guid = GetIdFromName("Kahsydat", "Nitsirk");
            //if (guid != null)
            //{
            //    UpdateContactsFirstName("Zeloznog", guid);
            //    GetContactById(guid);
            //}
            //Console.WriteLine("Press enter key to continue");
            //Console.ReadLine();

            //Console.WriteLine($"Removing phone number 514-300-9999 from Kahsydat Acire...");
            //guid = GetIdFromName("Kahsydat", "Acire");
            //if (guid != null)
            //{
            //    RemovePhoneNumberFromUser("514-300-9999", guid);
            //    GetContactById(guid);
            //}
            //Console.WriteLine("Press enter key to continue");
            //Console.ReadLine();

            //Console.WriteLine($"Removing user Kahsydat Leahcim...");
            //guid = GetIdFromName("Kahsydat", "Leahcim");
            //if (guid != null)
            //{
            //    RemoveUser(guid);
            //}
            //Console.WriteLine("Reading back all contacts...");
            //GetAllContacts();
            //Console.WriteLine("Press enter key to continue");
            //Console.ReadLine();

            Console.WriteLine("Done processing CosmosDB");
            Console.ReadLine();
        }

        public static int GetIdFromName(string firstName, string lastName)
        {
            int i = 0;
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
            return i;
        }

        public static async Task RemoveUser(string id)
        {
            await db.DeleteRecordAsync<ContactModel>(id, "Corey");
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

        private static async Task GetContactById(string id)
        {
            //When you capture the output of an asynchronous method without using await you get the whole return value
            //which is a task not just the return value

            // Cannot implicitly convert type 'System.Threading.Tasks.Task<DataAccessLibrary.Models.ContactModel>' to 'DataAccessLibrary.Models.ContactModel'
            //ContactModel contact = db.LoadRecordByIdAsync<ContactModel>(id);

            // But if you await,  then it finishes and returns a ContactModel

            ContactModel contact = await db.LoadRecordByIdAsync<ContactModel>(id);
            Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");

            //List<ContactModel> contacts = new();
            //var contact = db.LoadRecordByIdAsync<ContactModel>();
            //contacts.Add(contact);
            //DisplayFullContacts(contacts);
        }

        private static async Task GetAllContacts()
        {
            //List<ContactModel> contacts = db.LoadRecords<ContactModel>(tableName);
            //DisplayFullContacts(contacts);
            var contacts = await db.LoadRecordsAsync<ContactModel>();

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
            }
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

        private static async Task CreateContact(ContactModel contact)
        {
            if (db != null)
            {
                await db.UpsertRecordAsync(contact);
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

    }
}
