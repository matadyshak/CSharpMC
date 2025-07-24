using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class EFCrud
    {
        private void RemoveUser(int id)
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
        private void RemoveAddress<T>(int id, T address)
        {
            using (var db = new PersonContext())
            {
                var user = db.People
                    .Include(p => p.Addresses)
                    .Where(c => c.Id == id).First();

                user.Addresses.RemoveAll(a => a.Address == address);
                db.SaveChanges();
            }
        }
        private void UpdateFirstName(int id, string firstName)
        {
            using (var db = new PersonContext())
            {
                var user = db.People.Where(c => c.Id == id).First();

                user.FirstName = firstName;
                db.SaveChanges();
            }
        }

        private void ReadAll()
        {
            using (var db = new PersonContext())
            {
                var records = db.People
                    .Include(e => e.Employers)
                    .Include(a => a.Addresses)
                    .ToList();

                foreach (var p in records)
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                }
            }
        }

        private void ReadById(int id)
        {
            using (var db = new PersonContext())
            {
                var user = db.People.Where(p => p.Id == id).First();

                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

    }
}
