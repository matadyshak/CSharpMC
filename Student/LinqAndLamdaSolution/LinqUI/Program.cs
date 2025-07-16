using LinqUI.Models;

namespace LinqUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            LambdaTests();
            LinqTests();
            Console.WriteLine("Done processing");
            Console.ReadLine();
        }
        private static void LambdaTests()
        {
            var data = SampleData.GetContactData();

            Console.WriteLine("Where x => x.Addresses.Count > 1");
            var results1 = data.Where(x => x.Addresses.Count > 1);
            foreach (var item in results1)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("IEnumerable<string> results2 = data.Select(x => x.FirstName)");
            //Selects the FirstName of every contact and returns a IEnumerable<string>  //****************
            IEnumerable<string> results2 = data.Select(x => x.FirstName);
            foreach (string item in results2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("var results3 = data.Select(x => x.FirstName)");
            var results3 = data.Select(x => x.FirstName);
            foreach (var item in results3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("var results4 = data.Take(2)");
            var results4 = data.Take(2);
            foreach (var item in results4)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("data.Skip(2).Take(2)");
            var results5 = data.Skip(2).Take(2);
            foreach (var item in results5)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("var results6 = data.OrderBy(x => x.LastName)");
            var results6 = data.OrderBy(x => x.LastName);
            foreach (var item in results6)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("var results7 = data.OrderByDescending(x => x.LastName)");
            var results7 = data.OrderByDescending(x => x.LastName);
            foreach (var item in results7)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        // Equivalent to the lambda expression x => x.Addresses.Count > 1 for a single item
        private static bool RunMe(ContactModel x)
        {
            if (x.Addresses.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void LinqTests()
        {
            var contacts = SampleData.GetContactData();
            var addresses = SampleData.GetAddressData();


            Console.WriteLine("Test #1: (from c in contacts where c.Addresses.Count > 1 select c)");
            var results1 = (from c in contacts
                            where c.Addresses.Count > 1
                            select c);

            foreach (var item in results1)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();



            Console.WriteLine("Test #2");
            var results2 = (from c in contacts
                            join a in addresses
                            on c.Id equals a.ContactId
                            select c);

            foreach (var item in results2)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();



            Console.WriteLine("Test #3");
            var results3 = (from c in contacts
                            join a in addresses
                            on c.Id equals a.ContactId
                            select new { c.FirstName, c.LastName, a.City, a.State });  // Anonymous type

            foreach (var item in results3)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} from {item.City}, {item.State}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();



            Console.WriteLine("Test #4");
            var results4 = (from c in contacts
                            select new { c.FirstName, c.LastName, Addresses = addresses.Where(x => x.ContactId == c.Id) });

            foreach (var item in results4)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Addresses.Count()}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();


            Console.WriteLine("Test #5 - Many to many relationship");
            var results5 = (from c in contacts
                            select new { c.FirstName, c.LastName, Addresses = addresses.Where(a => c.Addresses.Contains(a.Id)) });

            foreach (var item in results5)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Addresses.Count()}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
