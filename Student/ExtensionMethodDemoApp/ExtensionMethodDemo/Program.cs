using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
	    PersonModel person = new PersonModel();

            person.FirstName = PromptForFirstName();
            person.LastName = PromptForLastName();
            person.Age = PromptForAge();

	    if( person.Age == -1 )
	    {
                person.Age = person.DefaultAge;
	    }

            //Default age changes from 33 to 20
	    person.SetDefaultAge(20).PrintInfo();

	    // Prompt for age again and let user put in 200 or something invalid
            person.Age = PromptForAge();
	    //
	    if( person.Age == -1 )
	    {
                person.Age = person.DefaultAge;
	    }

	    if(person.Age != 20 )
	    {
	        Console.WriteLine($"Age should have changed to the default of 20 but is {person.Age}.");
            }
            else
	    {
	        Console.WriteLine($"Age changed to the new default of 20.");
            }

            person.PrintInfo();
        }

        static string PromptForFirstName()
        {
	    Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
	    return firstName;
        }

        static string PromptForLastName()
        {
	    Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
	    return lastName;
        }

        static int PromptForAge()
        {
	    int age = 0;

            // Using the error status code -1 decouples method from PersonModel

            Console.Write("Enter your age in years: ");
            string entry = Console.ReadLine();
            try
	    {
                int.TryParse(entry, out age);
            }
            catch
	    {
                Console.WriteLine($"The entry {entry} was not a valid integer."):
                return -1; // error status - not a valid int
            }

            if (( age < 0 ) || (age > 150))
            {
                Console.WriteLine($"The entry {entry} was not a valid age in years."):
                return -1; // error status - not a valid age
            }

	    return age;
        }
    }

    public class PersonModel
    {
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	public int DefaultAge { get; set; } = 33;
    }

    public static class ExtensionSamples
    {
	public static PersonModel SetDefaultAge(this PersonModel person, int age)
        {
	    person.DefaultAge = age;
            return person;
        }

	public static PersonModel PrintInfo(this PersonModel person)
        {
	    Console.WriteLine($"{person.FirstName} {person.LastName} is age {person.Age}.");
            return person;
        }
    }
}
