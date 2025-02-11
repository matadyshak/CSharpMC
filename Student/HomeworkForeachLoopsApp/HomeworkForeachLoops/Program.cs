List<string> firstNames = new List<string>();
bool isValid = false;
bool isDone = false;
string? input = null;

while (!isDone)
{
    isValid = false;
    while (!isValid)
    {
        Console.Write("Enter a first name: ");
        input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
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
    Console.WriteLine(firstName);
}