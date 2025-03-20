using System;

namespace OverrideDempApp
{
    class Program
    {
        static void Main()
        {
            Person person = new Person
            {
                FirstName = "Michael",
                LastName = "Tadyshak"
            };
            Console.WriteLine(person.ToString());
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}