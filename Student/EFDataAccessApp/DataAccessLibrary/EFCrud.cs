using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class EFCrud
    {
        public void CreatePhil()
        {
            var p = new Person
            {
                FirstName = "Phil",
                LastName = "Tady"
            };

            p.Addresses.Add(new Address
            {
                Street = "2154 Fratney St",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53201"
            });

            p.Addresses.Add(new Address
            {
                Street = "5402 Weil Place",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53209"
            });

            p.Employers.Add(new Employer
            {
                CompanyName = "SquareD"
            });

            p.Employers.Add(new Employer
            {
                CompanyName = "Pulp Reproduction"
            });

            CreateRecord<Person>(p);
        }

        public void CreateMickey()
        {
            var p = new Person
            {
                FirstName = "Mickey",
                LastName = "Toddy"
            };

            p.Addresses.Add(new Address
            {
                Street = "2051 W Kneel St",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53234"
            });

            p.Addresses.Add(new Address
            {
                Street = "100 W Wisconsin Ave",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53432"
            });

            p.Employers.Add(new Employer
            {
                CompanyName = "St Michael Hospital"
            });

            p.Employers.Add(new Employer
            {
                CompanyName = "Bobby's Place"
            });

            CreateRecord<Person>(p);
        }

        // where T : class - Insures only reference types can be used for T
        public void CreateRecord<T>(T entity) where T : class
        {
            using (var pc = new PersonContext())
            {
                try
                {
                    pc.Set<T>().Add(entity);
                    pc.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Error creating record: {ex.Message}");
                }
            }
        }

        public void ReadAllRecords()
        {
            using (var pc = new PersonContext())
            {
                var records = pc.PersonTable
                    .Include(e => e.Employers)
                    .Include(a => a.Addresses)
                    .ToList();

                if (records == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                foreach (var p in records)
                {
                    Console.WriteLine($"{p.Id}: {p.FirstName} {p.LastName}");

                    foreach (var a in p.Addresses)
                    {
                        Console.WriteLine($"  Address: {a.Street}, {a.City}, {a.State} {a.ZipCode}");
                    }

                    foreach (var e in p.Employers)
                    {
                        Console.WriteLine($"  Employer: {e.CompanyName}");
                    }
                }
            }
        }

        public void ReadRecordById(int id)
        {
            using (var pc = new PersonContext())
            {
                var user = pc.PersonTable.Where(p => p.Id == id).First();

                if (user == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}");

                foreach (var a in user.Addresses)
                {
                    Console.WriteLine($"  Address: {a.Street}, {a.City}, {a.State} {a.ZipCode}");
                }

                foreach (var e in user.Employers)
                {
                    Console.WriteLine($"  Employer: {e.CompanyName}");
                }
            }
        }

        public int? ReadIdByName(string firstName, string lastName)
        {
            using (var pc = new PersonContext())
            {
                var user = pc.PersonTable.Where(p => p.FirstName == firstName && p.LastName == lastName).First();

                if (user == null)
                {
                    Console.WriteLine("User not found.");
                    return null;
                }

                return user.Id;
            }
        }
        public void UpdateFirstName(int id, string firstName)
        {
            using (var pc = new PersonContext())
            {
                try
                {
                    var user = pc.PersonTable.Where(p => p.Id == id).First();

                    if (user == null)
                    {
                        Console.WriteLine("User not found.");
                        return;
                    }

                    user.FirstName = firstName;
                    pc.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Error updating first name: {ex.Message}");
                }
            }
        }

        public void UpdateLastName(int id, string lastName)
        {
            using (var pc = new PersonContext())
            {
                try
                {
                    var user = pc.PersonTable.Where(p => p.Id == id).First();

                    if (user == null)
                    {
                        Console.WriteLine("User not found.");
                        return;
                    }

                    user.LastName = lastName;
                    pc.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Error updating last name: {ex.Message}");
                }
            }
        }
        public void DeleteAddress(int personId, Address targetAddress)
        {
            using (var pc = new PersonContext())
            {
                try
                {
                    var user = pc.PersonTable
                        .Include(a => a.Addresses)
                        .FirstOrDefault(p => p.Id == personId);

                    if (user == null)
                    {
                        Console.WriteLine("User not found.");
                        return;
                    }

                    // Removes all addresses that match the target address
                    user.Addresses.RemoveAll(a =>
                        a.Street == targetAddress.Street &&
                        a.City == targetAddress.City &&
                        a.State == targetAddress.State &&
                        a.ZipCode == targetAddress.ZipCode);

                    pc.SaveChanges();
                    Console.WriteLine("Matching address removed.");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Error removing address: {ex.Message}");
                }
            }
        }
        public void DeleteEmployer(int personId, Employer targetEmployer)
        {
            using (var pc = new PersonContext())
            {
                try
                {
                    var user = pc.PersonTable
                        .Include(e => e.Employers)
                        .FirstOrDefault(p => p.Id == personId);

                    if (user == null)
                    {
                        Console.WriteLine("User not found.");
                        return;
                    }

                    // Removes all employers that match the target employer
                    user.Employers.RemoveAll(e => e.CompanyName == targetEmployer.CompanyName);
                    pc.SaveChanges();
                    Console.WriteLine("Matching employer removed.");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Error removing employer: {ex.Message}");
                }
            }
        }
        public void DeleteUser(int id)
        {
            using (var pc = new PersonContext())
            {
                try
                {
                    var user = pc.PersonTable
                        .Include(a => a.Addresses)
                        .Include(e => e.Employers)
                        .Where(p => p.Id == id).First();  // If a C# function is called here EF will download all records

                    pc.PersonTable.Remove(user);
                    pc.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Error removing record: {ex.Message}");
                }
            }
        }
    }
}
