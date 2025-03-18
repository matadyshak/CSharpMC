using DemoLibrary;
using System;

namespace AccessModifiersDemo
{
    // Derived class Dalmation not in the base class assembly
    public class Dalmation : Dog
    {
        public void TestCallsFromDalmationClass()
        {
            // Test #8 - Derived class not in same assembly
            Console.WriteLine("\nTestCallsFromDalmationClass() - Different assembly and derived class.  public, protected and protected internal work.");
            PublicSay();
            //PrivateSay();
            ProtectedSay();
            //InternalSay();
            ProtectedInternalSay(); // Accessible from the derived class (even though not in same assembly)
            //PrivateProtectedSay();  // Not Accessable because calling from the derived class (but not from the same assembly)
        }
    }
}
