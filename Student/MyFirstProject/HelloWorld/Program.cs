using System;

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
float myFloat     = 9875.001F;
double myDouble   = 9876.000000000001D;
decimal myDecimal = 9877.000000000000000000001M;

Console.WriteLine("Printing variables starting with a blank line:");

Console.WriteLine(); // Blank line
Console.WriteLine("My bool: {0}", myBool);
Console.WriteLine("My char: {0}", myChar);
Console.WriteLine("My nullable buffer: {0}", new string(myNullableBuffer));
Console.WriteLine("My buffer: {0}", new string(myBuffer));
Console.WriteLine("My byte: {0}", myByte);
Console.WriteLine("My sbyte: {0}", mySbyte);
Console.WriteLine("My short: {0}", myShort);
Console.WriteLine("My ushort: {0}", myUshort);
Console.WriteLine("My int: {0}", myInt);
Console.WriteLine("My uint: {0}", myUint);
Console.WriteLine("My long: {0}", myLong);
Console.WriteLine("My ulong: {0}", myUlong);
Console.WriteLine("My float: {0}", myFloat);
Console.WriteLine("My double: {0}", myDouble);
Console.WriteLine("My decimal: {0}", myDecimal);

Console.WriteLine("\nMinimum and Maximum values for elementary data types:\n");

// Min = 0, Max = 65535, Size = 2 
Console.WriteLine("char: Min = {0}, Max = {1}, Size = {2}", (int)char.MinValue, (int)char.MaxValue, sizeof(char));

// Min = 0, Max = 255, Size = 1
Console.WriteLine("byte: Min = {0}, Max = {1}, Size = {2}", byte.MinValue, byte.MaxValue, sizeof(byte));

// Min = -128, Max = 127, Size = 1
Console.WriteLine("sbyte: Min = {0}, Max = {1}, Size = {2}", sbyte.MinValue, sbyte.MaxValue, sizeof(sbyte));

// Min = -32768, Max = 32767, Size = 2
Console.WriteLine("short: Min = {0}, Max = {1}, Size = {2}", short.MinValue, short.MaxValue, sizeof(short));

// Min = 0, Max = 65535, Size = 2
Console.WriteLine("ushort: Min = {0}, Max = {1}, Size = {2}", ushort.MinValue, ushort.MaxValue, sizeof(ushort));

// Min = -2,147,483,648, Max = 2,147,483,647, Size = 4
Console.WriteLine("int: Min = {0}, Max = {1}, Size = {2}", int.MinValue, int.MaxValue, sizeof(int));

// Min = 0, Max = 4,294,967,295, Size = 4
Console.WriteLine("uint: Min = {0}, Max = {1}, Size = {2}", uint.MinValue, uint.MaxValue, sizeof(uint));

// Min = -9,223,372,036,854,775,808, Max = 9,223,372,036,854,775,807, Size = 8
Console.WriteLine("long: Min = {0}, Max = {1}, Size = {2}", long.MinValue, long.MaxValue, sizeof(long));

// Min = 0, Max = 18,446,744,073,709,551,615, Size = 8
Console.WriteLine("ulong: Min = {0}, Max = {1}, Size = {2}", ulong.MinValue, ulong.MaxValue, sizeof(ulong));

// Min = -3.4028235E+38, Max = 3.4028235E+38, Size = 4
Console.WriteLine("float: Min = {0}, Max = {1}, Size = {2}", float.MinValue, float.MaxValue, sizeof(float));

// Min = -1.7976931348623157E+308, Max = 1.7976931348623157E+308, Size = 8
Console.WriteLine("double: Min = {0}, Max = {1}, Size = {2}", double.MinValue, double.MaxValue, sizeof(double));

// Min = -79,228,162,514,264,337,593,543,950,335  Max = 79,228,162,514,264,337,593,543,950,335, Size = 16
Console.WriteLine("decimal: Min = {0}, Max = {1}, Size = {2}", decimal.MinValue, decimal.MaxValue, sizeof(decimal));
