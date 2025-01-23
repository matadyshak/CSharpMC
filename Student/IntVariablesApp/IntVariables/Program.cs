namespace IntVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////
            // Elementary Data Types - Min Value, Max Value, Size
            ///////////////////////////////////////////////////////////////////////////////

            // See https://aka.ms/new-console-template for more information about this template 

            bool myBool = true;
            char myChar = 'A';

            //    The ? symbol in C# is used to indicate that a type is nullable. 
            //    This means that the type can hold a value or be null.
            char[]? myNullableBuffer = "Nullable Hello".ToCharArray();

            char[] myBuffer = "Hello".ToCharArray();
            byte myByte = 123;
            sbyte mySbyte = -123;
            short myShort = -12345;
            ushort myUshort = 60123;
            int myInt = -1222111000;
            uint myUint = 3444555666;
            long myLong = -1222333444555666L;
            ulong myUlong = 1222333444555666UL;
            float myFloat = 9875.001F;
            double myDouble = 9876.000000000001D;
            decimal myDecimal = 9877.000000000000000000001M;

            Console.WriteLine("Printing variables starting with a blank line:");

            Console.WriteLine(); // Blank line
            Console.WriteLine($"My bool: {myBool}");
            Console.WriteLine($"My char: {myChar}");
            Console.WriteLine($"My nullable buffer: {new string(myNullableBuffer)}");
            Console.WriteLine($"My buffer: {new string(myBuffer)}");
            Console.WriteLine($"My byte: {myByte}");
            Console.WriteLine($"My sbyte: {mySbyte}");
            Console.WriteLine($"My short: {myShort}");
            Console.WriteLine($"My ushort: {myUshort}");
            Console.WriteLine($"My int: {myInt}");
            Console.WriteLine($"My uint: {myUint}");
            Console.WriteLine($"My long: {myLong}");
            Console.WriteLine($"My ulong: {myUlong}");
            Console.WriteLine($"My float: {myFloat}");
            Console.WriteLine($"My double: {myDouble}");
            Console.WriteLine($"My decimal: {myDecimal}");

            Console.WriteLine("\nMinimum and Maximum values for elementary data types:\n");

            // Min = 0, Max = 65535, Size = 2 
            Console.WriteLine($"char: Min = {(int)char.MinValue}, Max = {(int)char.MaxValue}, Size = {sizeof(char)}");

            // Min = 0, Max = 255, Size = 1
            Console.WriteLine($"byte: Min = {byte.MinValue}, Max = {byte.MaxValue}, Size = {sizeof(byte)}");

            // Min = -128, Max = 127, Size = 1
            Console.WriteLine($"sbyte: Min = {sbyte.MinValue}, Max = {sbyte.MaxValue}, Size = {sizeof(sbyte)}");

            // Min = -32768, Max = 32767, Size = 2
            Console.WriteLine($"short: Min = {short.MinValue}, Max = {short.MaxValue}, Size = {sizeof(short)}");

            // Min = 0, Max = 65535, Size = 2
            Console.WriteLine($"ushort: Min = {ushort.MinValue}, Max = {ushort.MaxValue}, Size = {sizeof(ushort)}");

            // Min = -2,147,483,648, Max = 2,147,483,647, Size = 4
            Console.WriteLine($"int: Min = {int.MinValue}, Max = {int.MaxValue}, Size = {sizeof(int)}");

            // Min = 0, Max = 4,294,967,295, Size = 4
            Console.WriteLine($"uint: Min = {uint.MinValue}, Max = {uint.MaxValue}, Size = {sizeof(uint)}");

            // Min = -9,223,372,036,854,775,808, Max = 9,223,372,036,854,775,807, Size = 8
            Console.WriteLine($"long: Min = {long.MinValue}, Max = {long.MaxValue}, Size = {sizeof(long)}");

            // Min = 0, Max = 18,446,744,073,709,551,615, Size = 8
            Console.WriteLine($"ulong: Min = {ulong.MinValue}, Max = {ulong.MaxValue}, Size = {sizeof(ulong)}");

            // Min = -3.4028235E+38, Max = 3.4028235E+38, Size = 4
            Console.WriteLine($"float: Min = {float.MinValue}, Max = {float.MaxValue}, Size = {sizeof(float)}");

            // Min = -1.7976931348623157E+308, Max = 1.7976931348623157E+308, Size = 8
            Console.WriteLine($"double: Min = {double.MinValue}, Max = {double.MaxValue}, Size = {sizeof(double)}");

            // Min = -79,228,162,514,264,337,593,543,950,335  Max = 79,228,162,514,264,337,593,543,950,335, Size = 16
            Console.WriteLine($"decimal: Min = {decimal.MinValue}, Max = {decimal.MaxValue}, Size = {sizeof(decimal)}");
        }
    }
}
