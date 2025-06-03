namespace DataAccessLibrary.Models
{
    public class InitializationData
    {
        public List<FullContactModel> GetContactData()
        {
            return FullContactData;
        }

        List<FullContactModel> FullContactData = new List<FullContactModel>
        {
            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Michael",
                    LastName = "Tadyshak",
                },
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

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Myra",
                    LastName = "Tadyshak"
                },
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
            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Matthew",
                    LastName = "Tadyshak"
                },
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

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Jennifer",
                    LastName = "Tadyshak"
                },
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

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Joseph",
                    LastName = "Tadyshak"
                },
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

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Erica",
                    LastName = "Tadyshak"
                },
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Erica@pisd.com" },
                    new EmailAddressModel { EmailAddress = "Shaks@gmail.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "514-300-0000" },
                    new PhoneNumberModel { PhoneNumber = "514-300-9999" }
                }
            },

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Kristin",
                    LastName = "Tadyshak"
                },
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

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Cristopher",
                    LastName = "Gonzalez"
                },
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

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Sarah",
                    LastName = "Baumbach"
                },
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Sarah@fema.com" },
                    new EmailAddressModel { EmailAddress = "Baumbachs@xyz.com" }
                },
                PhoneNumbers = new List<PhoneNumberModel>
                {
                    new PhoneNumberModel { PhoneNumber = "714-500-0100" },
                    new PhoneNumberModel { PhoneNumber = "714-500-9199" }
                }
            },

            new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Jacob",
                    LastName = "Baumbach"
                },
                EmailAddresses = new List<EmailAddressModel>
                {
                    new EmailAddressModel { EmailAddress = "Jacob@purple.com" },
                    new EmailAddressModel { EmailAddress = "Baumbachs@xyz.com" }
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
