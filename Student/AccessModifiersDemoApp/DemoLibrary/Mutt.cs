using System;

namespace DemoLibrary
{
    public class Mutt : Dog
    {
        public string LicenseNumber { get; set; }
        public void TestCallsFromMuttClass()
        {
            // Test #7 - public, protected only accessible from Mutt class
            Console.WriteLine("\nTestCallsFromMuttClass().  All modifiers work except private.");
            PublicSay();
            //PrivateSay();
            ProtectedSay();
            InternalSay();
            ProtectedInternalSay(); // Calling same assembly from derived Mutt class
            PrivateProtectedSay();  // Calling same assembly from derived Mutt class
        }
    }
}