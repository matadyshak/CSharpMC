
Console.Write("What is your first name: ");
string firstName = Console.ReadLine();

Console.Write("What is your age: ");
string ageText = Console.ReadLine();

string formattedName;

if (int.TryParse(ageText, out int age) == false)
{
    Console.WriteLine("You did not provide a valid age.");
    return;
}

if (firstName.ToLower() == "bob" || firstName.ToLower() == "sue")
{
    formattedName = $"Professor {firstName}";
}
else
{
    formattedName = firstName;
}

if (age < 21)
{
    Console.WriteLine($"I recommend you wait {21 - age} years, {formattedName}");
}
else
{
    Console.WriteLine($"Welcome to class {formattedName}");
}

//if (int.TryParse(ageText, out int age))
//{
//    if (firstName.ToLower() == "bob" || firstName.ToLower() == "sue")
//    {
//        formattedName = $"Professor {firstName}";
//    }
//    else
//    {
//        formattedName = firstName;
//    }

//    if (age < 21)
//    {
//        Console.WriteLine($"I recommend you wait {21 - age} years, {formattedName}");
//    }
//    else
//    {
//        Console.WriteLine($"Welcome to class {formattedName}");
//    }
//}
//else
//{
//    Console.WriteLine("You did not provide a valid age.");
//}
