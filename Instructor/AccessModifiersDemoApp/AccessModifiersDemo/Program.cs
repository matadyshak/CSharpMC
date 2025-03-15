using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers

namespace AccessModifiersDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            person.SavePerson();

            Console.ReadLine();
        }
    }
}
