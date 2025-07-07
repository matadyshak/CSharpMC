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
                FirstName = "Kahsydat",
                LastName = "Leahcim",
                EmailAddresses = new List<string>
                {
                    "Michael@xyz.com",
                    "Michael@nfm.com"
                },
                PhoneNumbers = new List<string>
                {
                    "214-100-0000",
                    "214-100-9999"
                }
            },

            new ContactModel
            {
                FirstName = "Kahsydat",
                LastName = "Arym",
                EmailAddresses = new List<string>
                {
                    "Myra@xyz.com",
                    "Myra@cdc.com"
                },
                PhoneNumbers = new List<string>
                {
                    "214-100-0001",
                    "214-100-9991"
                }
            },
            new ContactModel
            {
                FirstName = "Kahsydat",
                LastName = "Wehttam",
                EmailAddresses = new List<string>
                {
                    "Matt@xyz.com",
                    "Matt@txdot.com"
                },
                PhoneNumbers = new List<string>
                {
                    "314-200-0010",
                    "314-200-9919"
                }
            },

            new ContactModel
            {
                FirstName = "Kahsydat",
                LastName = "Refinnej",
                EmailAddresses = new List<string>
                {
                    "Jenny@xyz.com",
                    "Jenny@gmail.com"
                },
                PhoneNumbers = new List<string>
                {
                    "314-200-0100",
                    "314-200-9199"
                }
            },

            new ContactModel
            {
                FirstName = "Kahsydat",
                LastName = "hpesoj",
                EmailAddresses = new List<string>
                {
                    "Joe@xyz.com",
                    "Shaks@gmail.com"
                },
                PhoneNumbers = new List<string>
                {
                    "514-300-1000",
                    "514-300-9999"
                }
            },

            new ContactModel
            {
                FirstName = "Kahsydat",
                LastName = "Acire",
                EmailAddresses = new List<string>
                {
                    "Erica@pisd.com",
                    "Dats@gmail.com"
                },
                PhoneNumbers = new List<string>
                {
                    "514-300-0000",
                    "514-300-9999"
                }
            },

            new ContactModel
            {
                FirstName = "Kahsydat",
                LastName = "Nitsirk",
                EmailAddresses = new List<string>
                {
                    "kris@tiff.com",
                    "Gonzo@xyz.com"
                },
                PhoneNumbers = new List<string>
                {
                    "614-400-0001",
                    "614-400-9991"
                }
            },

            new ContactModel
            {
                FirstName = "Zeloznog",
                LastName = "Rehpotsirc",
                EmailAddresses = new List<string>
                {
                    "Cristopher@purple.com",
                    "Gonzo@xyz.com"
                },
                PhoneNumbers = new List<string>
                {
                    "614-400-0010",
                    "614-400-9991"
                }
            },

            new ContactModel
            {
                FirstName = "Hcabmuab",
                LastName = "Haras",
                EmailAddresses = new List<string>
                {
                    "Sarah@fema.com",
                    "BBs@xyz.com"
                },
                PhoneNumbers = new List<string>
                {
                    "714-500-0100",
                    "714-500-9199"
                }
            },

            new ContactModel
            {
                FirstName = "Hcabmuab",
                LastName = "Bocaj",
                EmailAddresses = new List<string>
                {
                    "Jacob@purple.com",
                    "BBs@xyz.com"
                },
                PhoneNumbers = new List<string>
                {
                    "714-500-1000",
                    "714-500-9199"
                }
            }
        };
    }
}
