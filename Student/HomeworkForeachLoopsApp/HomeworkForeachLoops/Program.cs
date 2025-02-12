List<string> firstNames = new List<string>();
bool isValid = false;
bool isDone = false;
string? input = null;
Regex regexFirstName = new Regex(@"^[A-Za-z-' ]+$");

while (!isDone)
{
    isValid = false;
    while (!isValid)
    {
        Console.Write("Enter a first name: ");
        input = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(input) || (regexFirstName.IsMatch(input) == false))
        {
            isValid = false;
            Console.WriteLine($"Name entered: \'{input}\' is invalid.");
        }
        else if (input.ToLower() == "exit")
        {
            isDone = true;
            break;
        }
        else
        {
            isValid = true;
            input = ConvertToTitleCase(input);
            try
            {
                firstNames.Add(input);
            }
            catch
            {
                Console.WriteLine($"Failed to add name: \'{input}\' to the list");
            }
        }
    } // while(!valid)
} // while(!isDone)

Console.WriteLine("\nThe names entered are: ");
foreach (string firstName in firstNames)
{
    Console.WriteLine($"Hello, {firstName}!");
}

static string ConvertToTitleCase(string mixedCase)
{
    mixedCase = mixedCase.Trim();
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string titleCase = textInfo.ToTitleCase(mixedCase.ToLower());

    return titleCase;
}