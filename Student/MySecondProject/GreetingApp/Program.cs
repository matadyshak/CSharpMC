

// Welcome user to app
Console.WriteLine("Welcome to the Greeting Application.");
Console.WriteLine("This application was built by Michael Anthony Tadyshak.");
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine();

// Ask for first name
Console.Write("What is your first name: ");
string firstName;
firstName = Console.ReadLine();

// Greet user by name
Console.WriteLine();
//Console.WriteLine("Greetings, {0}!  The Lord be with You!", firstName); 
Console.WriteLine("Hello " + firstName);

Console.WriteLine("Thank you for using my application.");
Console.ReadLine();