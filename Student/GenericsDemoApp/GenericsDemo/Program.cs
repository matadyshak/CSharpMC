using System;
using UIHelperLibrary;

namespace GenericsDemo
{
    class Program
    {
        static void Main()
        {
            PersonModel person = new PersonModel();
            person.FirstName = person.RequestName("Enter your first name: ");
            person.LastName = person.RequestName("Enter your last name: ");

            AddressModel address = new AddressModel();
            address.AddressLine1 = address.RequestAddressLine1("Enter Address Line 1: ");
            address.AddressLine2 = address.RequestAddressLine2("Enter Address Line 2 (or Enter key to skip): ");
            address.City         = address.RequestCity("Enter City: ");
            address.State        = address.RequestState("Enter State (Abbreviation Code): ");
            address.ZipCode      = address.RequestZipCode("Enter ZIP Code: ");

            string word = "Enter a string: ".RequestString();
            int integer1 = "Enter an integer value from 0 to 100: ".RequestInt(0, 100);
            int integer2 = "Enter an integer value: ".RequestInt();
            double double1 = "Enter a double-precision floating-point value from 0.0 to 4.0: ".RequestDouble(0.0, 4.0);
            decimal decimal1 = "Enter a decimal value from 0.00 to 1_000_000m: ".RequestDecimal(0.0m, 1_000_000.00m);

            Console.WriteLine($"String: {word}");
            Console.WriteLine($"Integer 1: {integer1}");
            Console.WriteLine($"Integer 2: {integer2}");
            Console.WriteLine($"Double 1: {double1}");
            Console.WriteLine($"Decimal 1: {decimal1}");

            //bool myBool = true;
            //GenericToString<bool> myGenericBool = new GenericToString<bool>();
            //string myBoolString = myGenericBool.ConvertToString(myBool);
            //Console.WriteLine($"Bool: {myBool} converted to string: {myBoolString}");

            //int myInt = 62;
            //GenericToString<int> myGenericInt = new GenericToString<int>();
            //string myIntString = myGenericInt.ConvertToString(myInt);
            //Console.WriteLine($"Integer: {myInt} converted to string: {myIntString}");

            //double myDouble = 3.1415927d;
            //GenericToString<double> myGenericDouble = new GenericToString<double>();
            //string myDoubleString = myGenericDouble.ConvertToString(myDouble);
            //Console.WriteLine($"Double: {myDouble} converted to string: {myDoubleString}");

            //decimal myDecimal = 3.1415927m;
            //GenericToString<decimal> myGenericDecimal = new GenericToString<decimal>();
            //string myDecimalString = myGenericDecimal.ConvertToString(myDecimal);
            //Console.WriteLine($"Decimal: {myDecimal} converted to string: {myDecimalString}");

            GenericHelper<PersonModel> myGenericPersonModel = new GenericHelper<PersonModel>();
            string myPersonModelString = myGenericPersonModel.ConvertToString(person);
            Console.WriteLine($"PersonModel: {person} converted to string: {myPersonModelString}");
            myGenericPersonModel.GenericPrint(person);

            GenericHelper<AddressModel> myGenericAddressModel = new GenericHelper<AddressModel>();
            string myAddressModelString = myGenericAddressModel.ConvertToString(address);
            Console.WriteLine($"AddressModel: {address} converted to string: {myAddressModelString}");
            myGenericAddressModel.GenericPrint(address);

            // This is how to call if class is not generic but only the method is generic
            //GenericToString myGeneric = new GenericToString();
            //string myAddressModelString = myGeneric.ConvertToString<AddressModel>(address);
            //Console.WriteLine($"AddressModel: {address} converted to string: {myAddressModelString}");
        }
    }
}
