string firstName = "";

do
{
    Console.Write("Enter your first name (or type exit to end program)? ");
    firstName = Console.ReadLine();

    if (firstName.Length == 0)
    {
        continue;
    }

    if (firstName.ToLower() == "exit")
    {
        break;
    }

    if (firstName.ToLower() == "tim")
    {
        Console.WriteLine($"Hello Professor {firstName}!");
    }
    else
    {
        Console.WriteLine($"Hello student {firstName}!");
    }

} while (true);