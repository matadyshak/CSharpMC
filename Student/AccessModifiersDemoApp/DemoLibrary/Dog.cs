using System;

namespace DemoLibrary
{
    public class Dog
    {
        public string Breed { get; set; }

        public void TestCallsFromDogClass()
        {
            // Test #6 - public, private, protected all accessible from Dog class
            Console.WriteLine("\nTestCallsFromDogClass() - All 6 modifiers work.");
            PublicSay();
            PrivateSay();
            ProtectedSay();
            InternalSay();
            ProtectedInternalSay(); // Calling same assembly from Dog class
            PrivateProtectedSay();  // Calling same assembly not from Dog class
        }
        public void PublicSay()
        {
            Growl("Public");
        }
        private void PrivateSay()
        {
            Growl("Private");
        }
        protected void ProtectedSay()
        {
            Growl("Protected");
        }
        // Only callable from DemoLibrary
        internal void InternalSay()
        {
            Growl("Internal");
        }

        // Only within the same assembly AND within derived classes (which may be in another assembly)
        protected internal void ProtectedInternalSay()
        {
            Growl("Protected Internal");
        }

        // Only within same assembly AND only in derived classes
        private protected void PrivateProtectedSay()
        {
            Growl("Private Protected");
        }
        protected void Growl(string access)
        {
            Console.WriteLine($"Protected Growl! Access={access}.");
        }
    }
}