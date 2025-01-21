

// Welcome user to app
Console.WriteLine("Welcome to the Greeting Application.");
Console.WriteLine("This application was built by Michael Tadyshak.");
Console.WriteLine("-------------------------------------------------------");
Console.WriteLine();

// Ask for first name
Console.Write("What is your first name? ");
string firstName;
firstName = Console.ReadLine();

// Greet user by name
Console.WriteLine("Hello " + firstName);

bool validEmail = false;
while (!validEmail)
{
    // Ask for email address
    Console.Write("What is your email address? ");
    string email = Console.ReadLine();
    // Check if valid using regular expression:
    if (System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
    {
        // If valid say I will send you an email and set validEmail flag to true
        Console.WriteLine("I will send you an email at {0}.", email);
        validEmail = true;
    }
    else
    {
        // If not valid, ask again
        Console.WriteLine("Invalid email address. Please try again.");
    }
}

bool validCell = false;
while (!validCell)
{
    // Ask for cell #
    Console.Write("What is your cell number? ");
    string cell = Console.ReadLine();
    // Check if valid using regular expression:
    if (System.Text.RegularExpressions.Regex.IsMatch(cell, @"^(\+?\d{1,2}\s?)?(\(?\d{3}\)?[\s.-]?)?\d{3}[\s.-]?\d{4}$"))
    {
        // If valid say I will send you text message and set validCell flag to true
        Console.WriteLine("I will send you a text message at {0}.", cell);
        validCell = true;
        //
        // Cell number inputs ending with a '+' matched the regex
        // Cell number inputs ending with an 'x' did NOT match the regex
        //

        // 469-555-1234 +
        // 469.555.1234 +
        // 469 555 1234 +
        // (469) 555-1234 +
        // (469)555-1234 +

        // +1 469 555 1234   +
        // +1 (469) 555-1234 +
        // +1 (469)555-1234 +
        // +1 469.555.1234 +
        // +1 469-555-1234 +
        // +14695551234 +
        // +1469-555-1234 +
        // +1469.555.1234 +
        // +1469 555 1234 +
        // +1469 555-1234 +
        // +1469 555.1234 +
        // +1469 5551234 +

        // 1469-555-1234 +
        // 1469.555.1234 +
        // 1469 555 1234  +
        // 1(469) 555-1234 +
        // 1(469)555-1234 +

        // +24 469-555-1234 +
    }
    else
    {
        // If not valid, ask again
        Console.WriteLine("Invalid cell number. Please try again.");
    }
}

Console.WriteLine("Thank you for using my application.");
Console.ReadLine();