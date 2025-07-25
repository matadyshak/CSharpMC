using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
    // What Is DbContext?
    // Think of DbContext as your bridge between C# objects and the database. It:
    // Manages connections to the database
    // Tracks changes to objects(like adding or deleting)
    // Handles querying and saving with SaveChanges()
    // Configures database behavior through methods like OnConfiguring
    // In your case, PersonContext inherits from DbContext, which tells EF:
    // "This class represents my session with the database."
    // Anytime you interact with the database, you do it through an instance of this context.

    public class PersonContext : DbContext
    {
        public DbSet<Person> PersonTable { get; set; }

        public DbSet<Address> AddressTable { get; set; }

        public DbSet<Employer> EmployerTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            options.UseSqlServer(config.GetConnectionString("Default"));
        }
    }
}
