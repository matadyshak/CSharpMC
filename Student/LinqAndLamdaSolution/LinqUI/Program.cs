using LinqUI.Models;

namespace LinqUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //LambdaTests();
            LinqTests();
            Console.WriteLine("Done processing");
            Console.ReadLine();
        }
        private static void LambdaTests()
        {
            var data = SampleData.GetContactData();

            //var results = data.Where(x => x.Addresses.Count > 1);
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}");
            //}

            //Selects the FirstName of every contact and returns a IEnumerable<string>  //****************
            //IEnumerable<string> results = data.Select(x => x.FirstName);
            //foreach (string item in results)
            //{
            //    Console.WriteLine(item);
            //}

            //var results = data.Select(x => x.FirstName);
            //foreach (var item in results)
            //{
            //    Console.WriteLine(item);
            //}

            //var results = data.Take(2);
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}");
            //}

            //var results = data.Skip(2).Take(2);
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}");
            //}

            //var results = data.OrderBy(x => x.LastName);
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}");
            //}

            //var results = data.OrderByDescending(x => x.LastName);
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}");
            //}
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

            var results = (from c in contacts
                           join a in addresses
                           on c.Id equals a.ContactId
                           select c);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
