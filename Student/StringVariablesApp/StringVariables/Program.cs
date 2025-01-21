

string firstName = string.Empty;
string lastName = string.Empty;
string filePath = string.Empty; 
string filePath2 = string.Empty;

firstName = "Michael";
lastName = "Tadyshak";
//@ is a verbatim string literal, which means that the string should be used as is, without any special characters being processed.
filePath = @"C:\temp\demo";
filePath2 = "C:\\temp\\demo";

// The string is all literal except for the interpolated variable
// The $@ can be @$ as well
string testString = $@"The file for {firstName} is at c:\SampleFiles";
string testString2 = @$"The file for {firstName} is at c:\SampleFiles";

// String interpolation is a way to construct a new string value by including the value of variables within a string literal.
Console.WriteLine($"Hello {firstName} {lastName}");

// But I was doing this in project1 without the '$' sign ???
// But that was inserting indexes into the string and providing a list of variables
Console.WriteLine("Hello {0} {1}", firstName, lastName);
Console.WriteLine(filePath);
Console.WriteLine(filePath2);
Console.WriteLine(testString);
Console.WriteLine(testString2);
