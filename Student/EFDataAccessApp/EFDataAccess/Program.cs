using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace EFDataAccess
{
    public static class Program
    {
        static void Main(string[] args)
        {
            EFCrud eFCrud = new EFCrud();


            //ReadAllContacts(eFCrud);

            //ReadContact(eFCrud, 3);

            //CreateNewContact(eFCrud);

            //UpdateContact(eFCrud);

            //RemovePhoneNumberFromContact(eFCrud, 1, 1);

            Console.WriteLine("Completed processing");
            Console.ReadLine();
        }

        private static void CreatePhil()
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


            using (var db = new PersonContext())
            {
                db.Contacts.Add(c);
                db.SaveChanges();
            }
        }

        private static void CreateMickey()
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


            using (var db = new PersonContext())
            {
                db.Person.Add(c);
                db.SaveChanges();
            }
        }

    }
}
