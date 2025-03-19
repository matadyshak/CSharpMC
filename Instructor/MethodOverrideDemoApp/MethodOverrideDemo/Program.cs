using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverrideDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel
            {
                FirstName = "Tim",
                LastName = "Corey",
                Email = "tim@iamtimcorey.com"
            };

            Console.WriteLine(person);

            Console.ReadLine();
        }
    }
}
