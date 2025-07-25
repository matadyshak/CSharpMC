using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class EFCrud
    {
        public void RemoveUser(int id)
        {
            using (var db = new PersonContext())
            {
                var user = db.PeopleTable
                    .Include(a => a.Addresses)
                    .Where(p => p.Id == id).First();  // If a C# function is called here EF will download all records

                db.PeopleTable.Remove(user);
                db.SaveChanges();
            }
        }
        public void RemoveAddress<T>(int id, T address)
        {
            using (var db = new PersonContext())
            {
                var user = db.PeopleTable
                    .Include(p => p.Addresses)
                    .Where(c => c.Id == id).First();

                user.Addresses.RemoveAll(a => a.Address == address);
                db.SaveChanges();
            }
        }
        public void UpdateFirstName(int id, string firstName)
        {
            using (var db = new PersonContext())
            {
                var user = db.PeopleTable.Where(c => c.Id == id).First();

                user.FirstName = firstName;
                db.SaveChanges();
            }
        }

        public void ReadAll()
        {
            using (var db = new PersonContext())
            {
                var records = db.PeopleTable
                    .Include(e => e.Employers)
                    .Include(a => a.Addresses)
                    .ToList();

                foreach (var p in records)
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                }
            }
        }

        public void ReadById(int id)
        {
            using (var db = new PersonContext())
            {
                var user = db.PeopleTable.Where(p => p.Id == id).First();

                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        public void Create<T>(T entity) where T : class
        {
            using (var db = new PersonContext())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
            }
        }
    }
}
