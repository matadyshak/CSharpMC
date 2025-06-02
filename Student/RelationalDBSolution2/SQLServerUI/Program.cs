using DataAccessLibrary;
using Microsoft.Extensions.Configuration;
using SQLServerUI.Models;

namespace SQLServerUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlCrud sql = new SqlCrud(GetConnectionString());

            // WriteFullContacts(sql);

            ChangeContactName(sql);

            DeleteContactPhoneNumber(sql);

            ReadFullContactById(sql, 1035);  //Jacob

            ReadAllContacts(sql);

            Console.WriteLine("Processing complete.");
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

        private static void ReadFullContactById(SqlCrud sql, int id)
        {
            FullContactModel model = sql.GetFullContactById(id);

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
        private static void WriteFullContacts(SqlCrud sql)
        {
            foreach (FullContactModel fullContact in fullContacts)
            {
                sql.CreateContact(fullContact);
                Console.WriteLine($"Added: {fullContact.BasicInfo.FirstName} {fullContact.BasicInfo.LastName}");
            }
        }

        public static void ChangeContactName(SqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 1032,
                FirstName = "Kris",
                LastName = "Kristopherson"
            };

            sql.UpdateContactName(contact);
        }
        public static void DeleteContactPhoneNumber(SqlCrud sql)
        {
            //Should wipe out 514-300-0000
            sql.DeletePhoneNumberFromContact(1031, 2049);

            Console.ReadLine();

            // 514-300-9999 should remain since shared by joseph
            sql.DeletePhoneNumberFromContact(1031, 2048);

            Console.ReadLine();
        }

        static List<FullContactModel> fullContacts = new List<FullContactModel>
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
