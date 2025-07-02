namespace DataAccessLibrary.Models
{
    public class DataInitializer
    {
        public List<ContactModel> GetContactData()
        {
            return ContactData;
        }

        public List<ContactModel> ContactData = new List<ContactModel>
        {
            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Kahsydat",
                LastName = "Leahcim",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Michael@xyz.com" },
                    new EmailAddressModel { EmailAddress = "Michael@nfm.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "214-100-0000" },
                    new PhoneNumberModel { PhoneNumber = "214-100-9999" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Kahsydat",
                LastName = "Arym",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Myra@xyz.com" },
                    new EmailAddressModel { EmailAddress = "Myra@cdc.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "214-100-0001" },
                    new PhoneNumberModel { PhoneNumber = "214-100-9991" }
                }
            },
            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Kahsydat",
                LastName = "Wehttam",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Matt@xyz.com" },
                    new EmailAddressModel { EmailAddress = "Matt@txdot.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "314-200-0010" },
                    new PhoneNumberModel { PhoneNumber = "314-200-9919" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Kahsydat",
                LastName = "Refinnej",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Jenny@xyz.com" },
                    new EmailAddressModel { EmailAddress = "Jenny@gmail.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "314-200-0100" },
                    new PhoneNumberModel { PhoneNumber = "314-200-9199" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Kahsydat",
                LastName = "hpesoj",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Joe@xyz.com" },
                    new EmailAddressModel { EmailAddress = "Shaks@gmail.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "514-300-1000" },
                    new PhoneNumberModel { PhoneNumber = "514-300-9999" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Kahsydat",
                LastName = "Acire",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Erica@pisd.com" },
                    new EmailAddressModel { EmailAddress = "Dats@gmail.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "514-300-0000" },
                    new PhoneNumberModel { PhoneNumber = "514-300-9999" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Kahsydat",
                LastName = "Nitsirk",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "kris@tiff.com" },
                    new EmailAddressModel { EmailAddress = "Gonzo@xyz.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "614-400-0001" },
                    new PhoneNumberModel { PhoneNumber = "614-400-9991" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Zeloznog",
                LastName = "Rehpotsirc",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Cristopher@purple.com" },
                    new EmailAddressModel { EmailAddress = "Gonzo@xyz.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "614-400-0010" },
                    new PhoneNumberModel { PhoneNumber = "614-400-9991" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Hcabmuab",
                LastName = "Haras",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Sarah@fema.com" },
                    new EmailAddressModel { EmailAddress = "BBs@xyz.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "714-500-0100" },
                    new PhoneNumberModel { PhoneNumber = "714-500-9199" }
                }
            },

            new ContactModel
            {
                // Id = Guid.NewGuid(),
                FirstName = "Hcabmuab",
                LastName = "Bocaj",
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Jacob@purple.com" },
                    new EmailAddressModel { EmailAddress = "BBs@xyz.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "714-500-1000" },
                    new PhoneNumberModel { PhoneNumber = "714-500-9199" }
                }
            }
        };
    }
}
