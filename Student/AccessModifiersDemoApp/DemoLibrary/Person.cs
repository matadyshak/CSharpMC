using System;

namespace DemoLibrary
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void PrintNamePublic()
        {
            Console.WriteLine($"{FirstName} {LastName}");
            SayMiddleName(); // Works
        }

        // Test #2 - Access a private method in the same class
        // Add a private method
        private void SayMiddleName()
        {
            Console.WriteLine("My middle name is Anthony.");
        }

        public void TestCallsFromPersonClass()
        {
            Console.WriteLine("\nTestCallsFromPersonClass()");
            Dog dog = new Dog();
            // Test #3 - Fails
            Console.WriteLine("Call a private method in the same file but in a different unrelated class FAILS.");
            //dog.PrivateSay();

            // test #4
            Console.WriteLine("Public function dog.TestCallsFromDogClass() is able to work with all six access modifiers.");
            dog.TestCallsFromDogClass();

            // Test #5
            Console.WriteLine("Calling them directly only works for public, internal and protected internal.");
            dog.PublicSay();
            //dog.PrivateSay();    - Inaccessible
            //dog.ProtectedSay();  - Inaccessible
            dog.InternalSay();           // OK - Same assembly
            dog.ProtectedInternalSay();  // OK - Same assembly
            //dog.PrivateProtectedSay();   //Fail - Same assembly but not in a class derived from Dog
        }
    }
}