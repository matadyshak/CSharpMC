using DemoLibrary.Models;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>();
            string entry;

            do
            {
                PersonModel person = new PersonModel();
                person.FirstName = GetValidName(person, "Enter first name: ");
                person.LastName = GetValidName(person, "Enter last name: ");

                people.Add(person);

                Console.Write("Continue entering data? (y/n): ");
                entry = Console.ReadLine();
                Console.WriteLine();
            } while (entry.ToLower() == "y");

            foreach (PersonModel p in people)
            {
                Console.WriteLine();
                Console.WriteLine($"First name: {p.FirstName}");
                Console.WriteLine($"Last name: {p.LastName}");
            }

            Console.ReadLine();
        }

        public static string GetValidName(PersonModel person, string prompt)
        {
            string entry;
            string output;
            int status;

            do
            {
                Console.Write($"{prompt}");
                entry = Console.ReadLine();

                status = person.TryValidateName(entry, out output);

                if (status != 0)
                {
                    Console.WriteLine($"Entry: \'{entry}\' is invalid.  Please try again.");
                }
            } while (status != 0);

            return output;
        }
    }
}
