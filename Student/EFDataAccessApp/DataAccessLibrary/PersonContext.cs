using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Employer> Employers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            options.UseSqlServer(config.GetConnectionString("Default"));
        }
        private static void RemoveUser(int id)
        {
            using (var db = new PersonContext())
            {
                var user = db.People
                    .Include(a => a.Addresses)
                    .Where(p => p.Id == id).First();  // If a C# function is called here EF will download all records

                db.People.Remove(user);
                db.SaveChanges();
            }
        }
        private static void RemovePhoneNumber(int id, string phoneNumber)
        {
            using (var db = new ContactContext())
            {
                var user = db.Contacts
                    .Include(p => p.PhoneNumbers)
                    .Where(c => c.Id == id).First();

                user.PhoneNumbers.RemoveAll(p => p.PhoneNumber == phoneNumber);
                db.SaveChanges();
            }
        }
        private static void UpdateFirstName(int id, string firstName)
        {
            using (var db = new ContactContext())
            {
                var user = db.Contacts.Where(c => c.Id == id).First();

                user.FirstName = firstName;
                db.SaveChanges();
            }
        }
        private static void CreateTim()
        {
            var c = new Contact
            {
                FirstName = "Tim",
                LastName = "Corey"
            };

            c.EmailAddresses.Add(new Email { EmailAddress = "tim@iamtimcorey.com" });
            c.EmailAddresses.Add(new Email { EmailAddress = "me@timothycorey.com" });
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1212" });
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1234" });

            using (var db = new ContactContext())
            {
                db.Contacts.Add(c);
                db.SaveChanges();
            }
        }

        private static void CreateCharity()
        {
            var c = new Contact
            {
                FirstName = "Charity",
                LastName = "Corey"
            };

            c.EmailAddresses.Add(new Email { EmailAddress = "nope@aol.com" });
            c.EmailAddresses.Add(new Email { EmailAddress = "me@timothycorey.com" });
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1212" });
            c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-9876" });

            using (var db = new ContactContext())
            {
                db.Contacts.Add(c);
                db.SaveChanges();
            }
        }

        private static void ReadAll()
        {
            using (var db = new ContactContext())
            {
                var records = db.Contacts
                    .Include(e => e.EmailAddresses)
                    .Include(p => p.PhoneNumbers)
                    .ToList();

                foreach (var c in records)
                {
                    Console.WriteLine($"{c.FirstName} {c.LastName}");
                }
            }
        }

        private static void ReadById(int id)
        {
            using (var db = new ContactContext())
            {
                var user = db.Contacts.Where(c => c.Id == id).First();

                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }
    }
}
