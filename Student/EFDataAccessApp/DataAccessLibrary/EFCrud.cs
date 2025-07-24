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
        private void RemovePhoneNumber(int id, string phoneNumber)
        {
            using (var db = new PersonContext())
            {
                var user = db.Contacts
                    .Include(p => p.PhoneNumbers)
                    .Where(c => c.Id == id).First();

                user.PhoneNumbers.RemoveAll(p => p.PhoneNumber == phoneNumber);
                db.SaveChanges();
            }
        }
        private void UpdateFirstName(int id, string firstName)
        {
            using (var db = new PersonContext())
            {
                var user = db.Contacts.Where(c => c.Id == id).First();

                user.FirstName = firstName;
                db.SaveChanges();
            }
        }

        private void ReadAll()
        {
            using (var db = new PersonContext())
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

        private void ReadById(int id)
        {
            using (var db = new PersonContext())
            {
                var user = db.Contacts.Where(c => c.Id == id).First();

                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

    }
}
