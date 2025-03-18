using DemoLibrary;
using System;

namespace AccessModifiersDemo
{
    class Program
    {
        static void Main()
        {
            // Test #1 - Using a public class in a separate assembly
            // Both are required or Person will not be found
            // Public properties and methods
            // Requires UI class to have a reference to DemoLibrary
            // And using DemoLibrary
            Console.WriteLine("Test the Person class in DemoLibrary from Main assembly.");
            Person person = new Person();
            person.FirstName = "Michael";
            person.LastName = "Tadyshak";
            person.PrintNamePublic();
            person.TestCallsFromPersonClass();

            //WATCH OUT!  May have access modifiers all set appropriately but then have a public method to go around it!!!+
            Dog dog = new Dog();
            //Public method Works with all access types
            Console.WriteLine("\nCall public method TestCallsFromDogClass() - All modifiers work");
            dog.TestCallsFromDogClass();

            Console.WriteLine("\nCall all 6 Dog methods individually from UI assembly.  Only public works.");
            dog.PublicSay();
            //dog.PrivateSay();
            //dog.ProtectedSay();
            //dog.InternalSay();
            //dog.ProtectedInternalSay();
            //dog.PrivateProtectedSay();

            Mutt mutt = new Mutt();
            // Public method works with all but private
            Console.WriteLine("\nTestCallsFromMuttClass() - from UI assembly (all but private works)");
            mutt.TestCallsFromMuttClass();

            // test #2 - Unrelated class - Can only call public methods directly
            Console.WriteLine("\nTestCallsFromMuttClass() - Call all 6 methods individually using Mutt object from UI assembly (only public works)");
            mutt.PublicSay();
            //mutt.PrivateSay();
            //mutt.ProtectedSay();
            //mutt.InternalSay();
            //mutt.ProtectedInternalSay();
            //mutt.PrivateProtectedSay();

            Dalmation dalmation = new Dalmation();
            Console.WriteLine("\nTestCallsFromDalmationClass() - Call all 6 methods from Dalmation class from UI assembly.");
            dalmation.TestCallsFromDalmationClass();

            Console.WriteLine("\nCall all 6 methods individually using Dalmation object from UI assembly (only public works)");
            dalmation.PublicSay();
            //dalmation.PrivateSay();
            //dalmation.ProtectedSay();
            //dalmation.InternalSay();
            //dalmation.ProtectedInternalSay();
            //dalmation.PrivateProtectedSay();
        }
    }
}
