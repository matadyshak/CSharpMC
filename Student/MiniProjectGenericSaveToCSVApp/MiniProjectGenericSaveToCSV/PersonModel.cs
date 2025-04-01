using System;

namespace MiniProjectGenericSaveToCSV
{
    class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public void Print()
        {
            Console.WriteLine($"{FirstName} {LastName} {Email}");
        }

    }
}
