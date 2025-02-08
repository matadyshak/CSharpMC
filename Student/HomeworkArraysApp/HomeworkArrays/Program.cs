

string[] names = ["Peter", "James", "John"];
string input = "";
int index = 0;
bool isValid = false;

do
{
    Console.Write("Pick a name by entering an array index (0 | 1 | 2): ");
    input = Console.ReadLine();
    isValid = int.TryParse(input, out index) && index >= 0 && index < names.Length;
    if(!isValid)
    {
        Console.WriteLine($"Invalid input: \'{input}\'. Please try again.");
    }
} while (!isValid);

Console.Write($"You selected the name: \'{names[index]}\'");


//if (names.Contains(name))
//    {
//        Console.WriteLine("Name found");
//    }
//    else
//    {
//        Console.WriteLine("Name not found");
//    }
//} while (Console.ReadKey().Key != ConsoleKey.Escape);
//Console.WriteLine();
