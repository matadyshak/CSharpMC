

//bool isComplete = false;
//if (isComplete)
//{
//    Console.WriteLine("The task is complete.");
//}
//else
//{
//    Console.WriteLine("The task is not complete.");
//}

Console.Write("What is your first name? ");
string? firstName = Console.ReadLine();
string lastName;

// ToLower() does not change firstName, it returns a new string 
if (firstName.ToLower() == "tim")
{
    Console.WriteLine("Hello Mr. Corey");
    //string lastName = "Corey";
    lastName = "Corey";
}
else
{
    Console.WriteLine("Hello " + firstName);
    //string lastName = "Smith";
    lastName = "Smith";
}

// If lastName declared in the if statement,
// it would not be in scope after the if statement
// Gets a compiler error because lastName is not in scope
Console.WriteLine($"Lastname: {lastName}"); 

Console.WriteLine("End of program.");

