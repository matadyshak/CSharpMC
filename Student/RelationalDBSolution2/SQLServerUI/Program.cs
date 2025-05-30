using DataAccessLibrary;
using Microsoft.Extensions.Configuration;

namespace SQLServerUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlCrud sql = new SqlCrud(GetConnectionString());

            ReadAllContacts(sql);


            Console.WriteLine("Processing complete.");
            Console.ReadLine();
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }

        private static void ReadAllContacts(SqlCrud sql)
        {
            var rows = sql.GetAllContacts();

            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }
    }
}
