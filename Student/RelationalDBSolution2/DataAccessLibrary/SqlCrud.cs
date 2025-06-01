using SQLServerUI.Models;

namespace DataAccessLibrary
{
    public class SqlCrud
    {
        private readonly string _connectionString;

        private SqlDataAccess db = new SqlDataAccess();

        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BasicContactModel> GetAllContacts()
        {
            string sql = "select Id, FirstName, LastName from dbo.Contacts;";
            return db.LoadData<BasicContactModel, dynamic>(sql, new { }, _connectionString);
        }

        public FullContactModel GetFullContactById(int id)
        {
            //Construct FullContactModel
            FullContactModel output = new FullContactModel();

            // sql for id, firstName, LastName matching the id passed in
            string sql = @"select Id, FirstName, LastName from dbo.Contacts where Id = @Id;";
            // Load basicContactModel & pick first match
            output.BasicInfo = db.LoadData<BasicContactModel, dynamic>(sql, new { Id = id }, _connectionString).FirstOrDefault();

            // null check
            if (output.BasicInfo == null)
            {
                Console.WriteLine("Loading BasicContactModel was null.");
                throw new System.Exception("User not found");
            }

            // Load email addresses
            sql = @"select e.* 
                    from dbo.EmailAddresses e 
                    inner join 
                    dbo.ContactEmail ce 
                    on ce.EmailId = e.Id
                    where ce.ContactId = @Id;";

            output.EmailAddresses = db.LoadData<EmailAddressModel, dynamic>(sql, new { Id = id }, _connectionString);

            // Load Phone numbers
            sql = @"select p.*
                    from dbo.PhoneNumbers p
                    inner join 
                    dbo.ContactPhoneNumbers cp
                    on cp.PhoneNumberId = p.Id
                    where cp.ContactId = @Id;";

            output.PhoneNumbers = db.LoadData<PhoneNumberModel, dynamic>(sql, new { Id = id }, _connectionString);

            return output;
        }

        public void CreateContact(FullContactModel contact)
        {
            // (FirstName, LastName) are the column names in the Contacts table
            // (@FirstName, @LastName) are place holders for the data that will be passed into columns FirstName and LastName
            // FirstName = contact.BasicInfo.FirstName, LastName = contact.BasicInfo.LastName => Assigns the C# data to the placeholders

            // Save the basic contact in Contacts table
            string sql = @"insert into dbo.Contacts (FirstName, LastName) values (@FirstName, @LastName);";

            db.SaveData(sql, new { FirstName = contact.BasicInfo.FirstName, LastName = contact.BasicInfo.LastName }, _connectionString);

            // Get the ID of the new contact
            sql = @"select Id from dbo.Contacts 
                    where FirstName = @FirstName and LastName = @LastName;";

            contact.BasicInfo.Id = db.LoadData<IdLookupModel, dynamic>(
                sql,
                new { contact.BasicInfo.FirstName, contact.BasicInfo.LastName },
                _connectionString).First().Id;

            // foreach phone number in the passed in new contact
            foreach (PhoneNumberModel phoneNumber in contact.PhoneNumbers)
            {
                sql = @"select Id from dbo.PhoneNumbers where PhoneNumber = @PhoneNumber;";
                var existingPhoneNumber = db.LoadData<IdLookupModel, dynamic>(sql, new { phoneNumber.PhoneNumber },
                    _connectionString).FirstOrDefault();

                if (existingPhoneNumber == null)  // If no existing PhoneNumber found, insert new one
                {
                    sql = @"insert into dbo.PhoneNumbers (PhoneNumber) values (@PhoneNumber);";
                    db.SaveData(sql, new { PhoneNumber = phoneNumber.PhoneNumber }, _connectionString);

                    sql = @"select Id from dbo.PhoneNumbers where PhoneNumber = @PhoneNumber;";
                    phoneNumber.Id = db.LoadData<IdLookupModel, dynamic>(sql, new { phoneNumber.PhoneNumber },
                        _connectionString).First().Id;
                }
                else
                {
                    phoneNumber.Id = existingPhoneNumber.Id;  // Use existing ID
                }

                // Insert phone number into ContactPhoneNumbers table
                sql = @"insert into dbo.ContactPhoneNumbers (ContactId, PhoneNumberId) values (@ContactId, @PhoneNumberId);";

                db.SaveData(
                    sql,
                    new { ContactId = contact.BasicInfo.Id, PhoneNumberId = phoneNumber.Id },
                    _connectionString);
            }

            // foreach email in the passed in new contact
            foreach (EmailAddressModel email in contact.EmailAddresses)
            {
                sql = @"select Id from dbo.EmailAddresses where EmailAddress = @EmailAddress;";
                var existingEmail = db.LoadData<IdLookupModel, dynamic>(sql, new { email.EmailAddress },
                    _connectionString).FirstOrDefault();

                if (existingEmail == null)  // If no existing email found, insert new one
                {
                    sql = @"insert into dbo.EmailAddresses (EmailAddress) values (@EmailAddress);";
                    db.SaveData(sql, new { EmailAddress = email.EmailAddress }, _connectionString);

                    sql = @"select Id from dbo.EmailAddresses where EmailAddress = @EmailAddress;";
                    email.Id = db.LoadData<IdLookupModel, dynamic>(sql, new { email.EmailAddress },
                        _connectionString).First().Id;
                }
                else
                {
                    email.Id = existingEmail.Id;  // Use existing ID
                }

                // Insert email into ContactEmail table
                sql = @"insert into dbo.ContactEmail (ContactId, EmailId) values (@ContactId, @EmailId);";

                db.SaveData(sql, new { ContactId = contact.BasicInfo.Id, EmailId = email.Id }, _connectionString);
            }
        }

        public void UpdateContactName(BasicContactModel contact)
        {

        }

        public void RemovePhoneNumberFromContact(int contactId, int phoneNumberId)
        {
        }


    }
}
