using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Building a house from the blueprint
            //PersonModel person = new PersonModel();

            //List<PersonModel> people = new List<PersonModel>();

            //// Variable holds the street address
            //PersonModel person = new PersonModel();
            //person.firstName = "Tim";
            //people.Add(person);

            //person = new PersonModel();
            //person.firstName = "Sue";
            //people.Add(person);

            //foreach (PersonModel p in people)
            //{
            //    Console.WriteLine(p.firstName);
            //}

            List<PersonModel> people = new List<PersonModel>();
            string firstName = "";

            do
            {
                Console.Write("What is your first name (or type exit to stop): ");
                firstName = Console.ReadLine();

                Console.Write("What is your last name: ");
                string lastName = Console.ReadLine();

                if (firstName.ToLower() != "exit")
                {
                    PersonModel person = new PersonModel();
                    person.FirstName = firstName;
                    person.LastName = lastName;
                    people.Add(person);
                }
            } while (firstName.ToLower() != "exit");

            foreach (PersonModel p in people)
            {
                ProcessPerson.GreetPerson(p);
            }

            Console.ReadLine();
        }
    }
}
