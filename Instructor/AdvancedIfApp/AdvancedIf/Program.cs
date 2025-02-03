

Console.Write("What is your first name: ");
string firstName = Console.ReadLine();

Console.Write("What is your last name: ");
string lastName = Console.ReadLine();

if (firstName.ToLower() == "tim" &&
    lastName.ToLower() == "corey")
{
    Console.WriteLine("Hello Professor Corey");
}
else if (firstName.ToLower() == "tim" ||
         lastName.ToLower() == "corey")
{
    Console.WriteLine("You have a great part in your name.");
}
else
{
    Console.WriteLine("Hello Student");
}

//if (firstName.ToLower() == "tim" &&
//    lastName.ToLower() == "corey")
//{
//    Console.WriteLine("Hello Mr. Corey");
//}
//else if (firstName.ToLower() == "tim")
//{
//    Console.WriteLine("Hello, you have a cool first name.");
//}
//else if (lastName.ToLower() == "corey")
//{
//    Console.WriteLine("You have a great last name.");
//}
//else
//{
//    Console.WriteLine("Sorry you don't have a cooler name!");
//}


//if (firstName.ToLower() == "tim")
//{
//    Console.WriteLine("You have a cool first name.");
//}

//if (lastName.ToLower() == "corey")
//{
//    Console.WriteLine("You have a great last name.");
//}
//else
//{
//    Console.WriteLine("Sorry your name isn't cooler.");
//}

int age = 73;


// ==, >, >=, <, <=, !=
//if (age != 43)
//{
//    Console.WriteLine("Sorry, you aren't a great age.");
//}

if ((age >= 40 && age < 50) ||
    (age >=70 && age < 80))
{
    Console.WriteLine("You are in your 40's or 70's");
}
