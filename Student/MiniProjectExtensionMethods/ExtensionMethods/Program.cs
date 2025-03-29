using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main()
        {
            PersonModel person = new PersonModel
            {
                FirstName = "Enter your first name: ".RequestString(),
                LastName = "Enter your last name: ".RequestString(),
                Age = "Enter your age in years: ".RequestInt(0, 120)
            };
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");

            person.Age = "Enter your age in years: ".RequestInt();
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");

            person.GradePointAverage = "Enter your Grade Point Average (0.00 - 4.00): ".RequestDouble(0.00, 4.00);
            person.StartingSalary = "Enter your starting annual salary: ".RequestDecimal();

            Console.ReadLine();
        }
    }
}

